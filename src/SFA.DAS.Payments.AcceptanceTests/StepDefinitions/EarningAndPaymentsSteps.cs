﻿using System;
using System.Collections.Generic;
using System.Linq;
using IlrGenerator;
using NUnit.Framework;
using ProviderPayments.TestStack.Core;
using ProviderPayments.TestStack.Core.Domain;
using SFA.DAS.Payments.AcceptanceTests.Contexts;
using SFA.DAS.Payments.AcceptanceTests.DataHelpers;
using SFA.DAS.Payments.AcceptanceTests.DataHelpers.Entities;
using SFA.DAS.Payments.AcceptanceTests.ExecutionEnvironment;
using SFA.DAS.Payments.AcceptanceTests.Translators;
using TechTalk.SpecFlow;
using IlrBuilder = SFA.DAS.Payments.AcceptanceTests.Builders.IlrBuilder;
using LearningDelivery = SFA.DAS.Payments.AcceptanceTests.Contexts.LearningDelivery;

namespace SFA.DAS.Payments.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class EarningAndPaymentsSteps
    {
        public EarningAndPaymentsSteps(EarningAndPaymentsContext earningAndPaymentsContext)
        {
            EarningAndPaymentsContext = earningAndPaymentsContext;
        }

        public EarningAndPaymentsContext EarningAndPaymentsContext { get; set; }


        [When(@"an ILR file is submitted with the following data:")]
        public void WhenAnIlrFileIsSubmittedWithTheFollowingData(Table table)
        {
            // Store spec values in context
            EarningAndPaymentsContext.Learners = new Contexts.Learner[table.RowCount];

            for (var rowIndex = 0; rowIndex < table.RowCount; rowIndex++)
            {
                EarningAndPaymentsContext.Learners[rowIndex] = new Contexts.Learner
                {
                    Name = table.Rows[rowIndex].ContainsKey("ULN") ? table.Rows[rowIndex]["ULN"] : string.Empty,
                    Uln = long.Parse(IdentifierGenerator.GenerateIdentifier(10, false)),
                    LearningDelivery = new LearningDelivery
                    {
                        AgreedPrice = decimal.Parse(table.Rows[rowIndex]["agreed price"]),
                        LearnerType = LearnerType.ProgrammeOnlyDas,
                        StartDate = DateTime.Parse(table.Rows[rowIndex]["start date"]),
                        PlannedEndDate = DateTime.Parse(table.Rows[rowIndex]["planned end date"]),
                        ActualEndDate = string.IsNullOrWhiteSpace(table.Rows[rowIndex]["actual end date"]) ? null : (DateTime?)DateTime.Parse(table.Rows[rowIndex]["actual end date"]),
                        CompletionStatus = IlrTranslator.TranslateCompletionStatus(table.Rows[rowIndex]["completion status"])
                    }
                };
            }

            // Setup reference data
            var environmentVariables = EnvironmentVariablesFactory.GetEnvironmentVariables();
            var accountId = IdentifierGenerator.GenerateIdentifier();
            var ukprn = int.Parse(IdentifierGenerator.GenerateIdentifier(8, false));

            EarningAndPaymentsContext.Ukprn = ukprn;

            AccountDataHelper.CreateAccount(accountId, accountId, 0.00m, environmentVariables);

            foreach (var learner in EarningAndPaymentsContext.Learners)
            {
                var commitment = EarningAndPaymentsContext.ReferenceDataContext.Commitments?.SingleOrDefault(c => c.Learner == learner.Name);

                if (commitment != null)
                {
                    CommitmentDataHelper.CreateCommitment(commitment.Id, ukprn, learner.Uln, accountId, learner.LearningDelivery.StartDate,
                        learner.LearningDelivery.PlannedEndDate, learner.LearningDelivery.AgreedPrice, IlrBuilder.Defaults.StandardCode,
                        IlrBuilder.Defaults.FrameworkCode, IlrBuilder.Defaults.ProgrammeType, IlrBuilder.Defaults.PathwayCode, commitment.Priority, "1", environmentVariables);
                }
                else
                {
                    var commitmentId = int.Parse(IdentifierGenerator.GenerateIdentifier(6, false));

                    CommitmentDataHelper.CreateCommitment(commitmentId, ukprn, learner.Uln, accountId, learner.LearningDelivery.StartDate,
                        learner.LearningDelivery.PlannedEndDate, learner.LearningDelivery.AgreedPrice, IlrBuilder.Defaults.StandardCode,
                        IlrBuilder.Defaults.FrameworkCode, IlrBuilder.Defaults.ProgrammeType, IlrBuilder.Defaults.PathwayCode, 1, "1", environmentVariables);
                }
            }

            // Process months
            var processService = new ProcessService(new TestLogger());
            var earnedByPeriod = new Dictionary<string, decimal>();

            var periodId = 1;
            var date = EarningAndPaymentsContext.IlrStartDate.NextCensusDate();
            var endDate = EarningAndPaymentsContext.IlrEndDate;
            var lastCensusDate = endDate.NextCensusDate();

            while (date <= lastCensusDate)
            {
                var period = date.GetPeriod();
                var levyBalance = GetAccountBalanceForPeriod(period, EarningAndPaymentsContext.ReferenceDataContext);
                AccountDataHelper.UpdateAccountBalance(accountId, levyBalance, environmentVariables);

                var academicYear = date.GetAcademicYear();

                SetupEnvironmentVariablesForMonth(date, academicYear, environmentVariables, ref periodId);

                SubmitIlr(ukprn, EarningAndPaymentsContext.Learners, academicYear, date, environmentVariables, processService, earnedByPeriod);

                SubmitMonthEnd(date, environmentVariables, processService);

                date = date.AddDays(15).NextCensusDate();
            }
            EarningAndPaymentsContext.EarnedByPeriod = earnedByPeriod;
        }

        [Then(@"the provider earnings and payments break down as follows:")]
        public void ThenTheProviderEarningsBreakDownAsFollows(Table table)
        {
            var environmentVariables = EnvironmentVariablesFactory.GetEnvironmentVariables();

            var earnedRow = table.Rows.RowWithKey(RowKeys.Earnings);
            var levyPaidRow = table.Rows.RowWithKey(RowKeys.LevyPayment);
            var govtCofundRow = table.Rows.RowWithKey(RowKeys.CoFinanceGovernmentPayment);
            var employerCofundRow = table.Rows.RowWithKey(RowKeys.CoFinanceEmployerPayment);

            for (var colIndex = 1; colIndex < table.Header.Count; colIndex++)
            {
                var periodName = table.Header.ElementAt(colIndex);
                if (periodName == "...")
                {
                    continue;
                }

                var periodMonth = int.Parse(periodName.Substring(0, 2));
                var periodYear = int.Parse(periodName.Substring(3)) + 2000;


                VerifyEarningsForPeriod(periodName, colIndex, earnedRow);
                VerifyLevyPayments(periodName, periodYear, periodMonth, colIndex, levyPaidRow, environmentVariables);
                VerifyCofinancePayments(periodName, periodYear, periodMonth, colIndex, govtCofundRow, employerCofundRow, environmentVariables);
            }
        }



        private void SetupEnvironmentVariablesForMonth(DateTime date, string academicYear, EnvironmentVariables environmentVariables, ref int periodId)
        {
            environmentVariables.CurrentYear = academicYear;
            environmentVariables.SummarisationPeriod = new SummarisationCollectionPeriod
            {
                PeriodId = periodId++,
                CollectionPeriod = "R" + (new DateTime(date.Year, date.Month, 1)).GetPeriodNumber().ToString("00"),
                CalendarMonth = date.Month,
                CalendarYear = date.Year,
                ActualsSchemaPeriod = date.Year + date.Month.ToString("00"),
                CollectionOpen = 1
            };
        }
        private void SubmitIlr(long ukprn, Contexts.Learner[] learners, string academicYear, DateTime date,
            EnvironmentVariables environmentVariables, ProcessService processService, Dictionary<string, decimal> earnedByPeriod)
        {
            var submissionLearners = learners.Select(l => new Contexts.Learner
            {
                Name = l.Name,
                Uln = l.Uln,
                LearningDelivery = new LearningDelivery
                {
                    AgreedPrice = l.LearningDelivery.AgreedPrice,
                    LearnerType = l.LearningDelivery.LearnerType,
                    StartDate = l.LearningDelivery.StartDate,
                    PlannedEndDate = l.LearningDelivery.PlannedEndDate,
                    ActualEndDate = date >= l.LearningDelivery.ActualEndDate ? l.LearningDelivery.ActualEndDate : null,
                    CompletionStatus = l.LearningDelivery.CompletionStatus
                }
            }).ToArray();

            IlrSubmission submission = IlrBuilder.CreateAIlrSubmission()
                .WithUkprn(ukprn)
                .WithMultipleLearners()
                    .WithLearners(submissionLearners);

            AcceptanceTestDataHelper.AddCurrentActivePeriod(date.Year, date.Month, environmentVariables);

            var ilrStatusWatcher = new TestStatusWatcher(environmentVariables, $"Submit ILR to {date:dd/MM/yy}");
            processService.RunIlrSubmission(submission, environmentVariables, ilrStatusWatcher);

            var periodEarnings = EarningsDataHelper.GetPeriodisedValuesForUkprn(ukprn, environmentVariables).LastOrDefault() ?? new PeriodisedValuesEntity();
            earnedByPeriod.AddOrUpdate("08/" + academicYear.Substring(0, 2), periodEarnings.Period_1);
            earnedByPeriod.AddOrUpdate("09/" + academicYear.Substring(0, 2), periodEarnings.Period_2);
            earnedByPeriod.AddOrUpdate("10/" + academicYear.Substring(0, 2), periodEarnings.Period_3);
            earnedByPeriod.AddOrUpdate("11/" + academicYear.Substring(0, 2), periodEarnings.Period_4);
            earnedByPeriod.AddOrUpdate("12/" + academicYear.Substring(0, 2), periodEarnings.Period_5);
            earnedByPeriod.AddOrUpdate("01/" + academicYear.Substring(2), periodEarnings.Period_6);
            earnedByPeriod.AddOrUpdate("02/" + academicYear.Substring(2), periodEarnings.Period_7);
            earnedByPeriod.AddOrUpdate("03/" + academicYear.Substring(2), periodEarnings.Period_8);
            earnedByPeriod.AddOrUpdate("04/" + academicYear.Substring(2), periodEarnings.Period_9);
            earnedByPeriod.AddOrUpdate("05/" + academicYear.Substring(2), periodEarnings.Period_10);
            earnedByPeriod.AddOrUpdate("06/" + academicYear.Substring(2), periodEarnings.Period_11);
            earnedByPeriod.AddOrUpdate("07/" + academicYear.Substring(2), periodEarnings.Period_12);
        }
        private void SubmitMonthEnd(DateTime date, EnvironmentVariables environmentVariables, ProcessService processService)
        {
            var summarisationStatusWatcher = new TestStatusWatcher(environmentVariables, $"Summarise {date:dd/MM/yy}");
            processService.RunSummarisation(environmentVariables, summarisationStatusWatcher);
        }

        private void VerifyEarningsForPeriod(string periodName, int colIndex, TableRow earnedRow)
        {
            if (earnedRow == null)
            {
                return;
            }

            if (!EarningAndPaymentsContext.EarnedByPeriod.ContainsKey(periodName))
            {
                Assert.Fail($"Expected value for period {periodName} but none found");
            }

            var expectedEarning = decimal.Parse(earnedRow[colIndex]);
            Assert.IsTrue(EarningAndPaymentsContext.EarnedByPeriod.ContainsKey(periodName), $"Expected earning for period {periodName} but none found");
            Assert.AreEqual(expectedEarning, EarningAndPaymentsContext.EarnedByPeriod[periodName], $"Expected earning of {expectedEarning} for period {periodName} but found {EarningAndPaymentsContext.EarnedByPeriod[periodName]}");
        }
        private void VerifyLevyPayments(string periodName, int periodYear, int periodMonth, int colIndex,
            TableRow levyPaidRow, EnvironmentVariables environmentVariables)
        {
            if (levyPaidRow == null)
            {
                return;
            }

            var levyPayments = LevyPaymentDataHelper.GetLevyPaymentsForPeriod(EarningAndPaymentsContext.Ukprn, periodYear, periodMonth - 1, environmentVariables)
                    ?? new LevyPaymentEntity[0];

            var actualLevyPayment = levyPayments.Length == 0 ? 0m : levyPayments.Sum(p => p.Amount);
            var expectedLevyPayment = decimal.Parse(levyPaidRow[colIndex]);
            Assert.AreEqual(expectedLevyPayment, actualLevyPayment, $"Expected a levy payment of {expectedLevyPayment} but made a payment of {actualLevyPayment} for {periodName}");
        }
        private void VerifyCofinancePayments(string periodName, int periodYear, int periodMonth, int colIndex,
            TableRow govtCofundRow, TableRow employerCofundRow, EnvironmentVariables environmentVariables)
        {
            if (govtCofundRow == null && employerCofundRow == null)
            {
                return;
            }

            var cofinancePayments = CoFinancePaymentsDataHelper.GetCoInvestedPaymentsForPeriod(EarningAndPaymentsContext.Ukprn, periodYear, periodMonth, environmentVariables);

            var actualGovtPayment = cofinancePayments.Where(p => p.FundingSource == 2).Sum(p => p.Amount);
            var expectedGovtPayment = govtCofundRow == null ? 0 : decimal.Parse(govtCofundRow[colIndex]);
            Assert.AreEqual(expectedGovtPayment, actualGovtPayment, $"Expected a government co-finance payment of {expectedGovtPayment} but made a payment of {actualGovtPayment} for {periodName}");

            var actualEmployerPayment = cofinancePayments.Where(p => p.FundingSource == 3).Sum(p => p.Amount);
            var expectedEmployerPayment = employerCofundRow == null ? 0 : decimal.Parse(employerCofundRow[colIndex]);
            Assert.AreEqual(expectedGovtPayment, actualGovtPayment, $"Expected a employer co-finance payment of {expectedEmployerPayment} but made a payment of {actualEmployerPayment} for {periodName}");
        }

        private decimal GetAccountBalanceForPeriod(string period, ReferenceDataContext context)
        {
            if (context.MonthlyAccountBalance.ContainsKey("All"))
            {
                return context.MonthlyAccountBalance["All"];
            }

            if (context.MonthlyAccountBalance.ContainsKey(period))
            {
                return context.MonthlyAccountBalance[period];
            }

            return context.MonthlyAccountBalance["..."];
        }
    }
}
