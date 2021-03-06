﻿using System.Linq;
using SFA.DAS.Payments.AcceptanceTests.Assertions;
using SFA.DAS.Payments.AcceptanceTests.Contexts;
using SFA.DAS.Payments.AcceptanceTests.ExecutionManagers;
using SFA.DAS.Payments.AcceptanceTests.ReferenceDataModels;
using SFA.DAS.Payments.AcceptanceTests.TableParsers;
using TechTalk.SpecFlow;
using System;
using SFA.DAS.Payments.AcceptanceTests.Refactoring.ExecutionManagers;

namespace SFA.DAS.Payments.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class EarningAndPaymentSteps
    {
        public EarningAndPaymentSteps(EmployerAccountContext employerAccountContext, 
                                      EarningsAndPaymentsContext earningsAndPaymentsContext,
                                      DataLockContext dataLockContext,
                                      SubmissionContext submissionContext, 
                                      LookupContext lookupContext,
                                    CommitmentsContext commitmentsContext)
        {
            EmployerAccountContext = employerAccountContext;
            EarningsAndPaymentsContext = earningsAndPaymentsContext;
            DataLockContext = dataLockContext;
            SubmissionContext = submissionContext;
            LookupContext = lookupContext;
            CommitmentsContext = commitmentsContext;
        }
        public EmployerAccountContext EmployerAccountContext { get; }
        public DataLockContext DataLockContext { get; }
        public EarningsAndPaymentsContext EarningsAndPaymentsContext { get; }
        public SubmissionContext SubmissionContext { get; }
        public LookupContext LookupContext { get; }
        public CommitmentsContext CommitmentsContext { get; }



        [Then("the provider earnings and payments break down as follows:")]
        public void ThenProviderEarningAndPaymentsBreakDownTo(Table earningAndPayments)
        {
            ThenProviderEarningAndPaymentsBreakDownTo(Defaults.ProviderIdSuffix, earningAndPayments);
        }

        [Then("the earnings and payments break down for provider (.*) is as follows:")]
        public void ThenProviderEarningAndPaymentsBreakDownTo(string providerIdSuffix, Table earningAndPayments)
        {
            if (!SubmissionContext.HaveSubmissionsBeenDone)
            {
                SubmissionContext.SubmissionResults = SubmissionManager.SubmitIlrAndRunMonthEndAndCollateResults(SubmissionContext.IlrLearnerDetails, SubmissionContext.FirstSubmissionDate,
                    LookupContext, EmployerAccountContext.EmployerAccounts, SubmissionContext.ContractTypes, SubmissionContext.EmploymentStatus, SubmissionContext.LearningSupportStatus);
                SubmissionContext.HaveSubmissionsBeenDone = true;
            }

            var providerBreakdown = EarningsAndPaymentsContext.OverallEarningsAndPayments.SingleOrDefault(x => x.ProviderId == "provider " + providerIdSuffix);
            if (providerBreakdown == null)
            {
                providerBreakdown = new EarningsAndPaymentsBreakdown { ProviderId = "provider " + providerIdSuffix };
                EarningsAndPaymentsContext.OverallEarningsAndPayments.Add(providerBreakdown);
            }

            EarningAndPaymentTableParser.ParseEarningsAndPaymentsTableIntoContext(providerBreakdown, earningAndPayments);
            AssertResults();
        }

        [Then("the transaction types for the payments are:")]
        public void ThenTheTransactionTypesForEarningsAre(Table earningBreakdown)
        {
            ThenTheTransactionTypesForNamedProviderEarningsAre(Defaults.ProviderIdSuffix, earningBreakdown);
        }

        [Then("the transaction types for the payments for provider (.*) are:")]
        public void ThenTheTransactionTypesForNamedProviderEarningsAre(string providerIdSuffix, Table transactionTypes)
        {
            if (!SubmissionContext.HaveSubmissionsBeenDone)
            {
                SubmissionContext.SubmissionResults = SubmissionManager.SubmitIlrAndRunMonthEndAndCollateResults(SubmissionContext.IlrLearnerDetails, SubmissionContext.FirstSubmissionDate,
                    LookupContext, EmployerAccountContext.EmployerAccounts, SubmissionContext.ContractTypes, SubmissionContext.EmploymentStatus, SubmissionContext.LearningSupportStatus);
                SubmissionContext.HaveSubmissionsBeenDone = true;
            }

            TransactionTypeTableParser.ParseTransactionTypeTableIntoContext(EarningsAndPaymentsContext, $"provider {providerIdSuffix}", transactionTypes);
            AssertResults();
        }

        [Then(@"the provider earnings and payments break down for ULN (.*) as follows:")]
        public void ThenTheProviderEarningsAndPaymentsBreakDownForUlnAsFollows(string learnerId, Table earningAndPayments)
        {
            if (!SubmissionContext.HaveSubmissionsBeenDone)
            {
                SubmissionContext.SubmissionResults = SubmissionManager.SubmitIlrAndRunMonthEndAndCollateResults(SubmissionContext.IlrLearnerDetails, SubmissionContext.FirstSubmissionDate,
                    LookupContext, EmployerAccountContext.EmployerAccounts, SubmissionContext.ContractTypes, SubmissionContext.EmploymentStatus, SubmissionContext.LearningSupportStatus);
                SubmissionContext.HaveSubmissionsBeenDone = true;
            }

            var breakdown = new LearnerEarningsAndPaymentsBreakdown
            {
                ProviderId = Defaults.ProviderId, // This may not be true in every case, need to check specs
                LearnerId = learnerId
            };
            EarningsAndPaymentsContext.LearnerOverallEarningsAndPayments.Add(breakdown);
            EarningAndPaymentTableParser.ParseEarningsAndPaymentsTableIntoContext(breakdown, earningAndPayments);
            AssertResults();
        }

        private void AssertResults()
        {
            PaymentsAndEarningsAssertions.AssertPaymentsAndEarningsResults(EarningsAndPaymentsContext, SubmissionContext, EmployerAccountContext);
            TransactionTypeAssertions.AssertPaymentsAndEarningsResults(EarningsAndPaymentsContext, SubmissionContext, EmployerAccountContext);
            //DataLockAssertions.AssertPaymentsAndEarningsResults(DataLockContext, SubmissionContext);
        }

        [Given(@"the following earnings and payments have been made to the provider for (.*):")]
        public void GivenTheFollowingEarningsAndPaymentsHaveBeenMadeToTheProviderForLearner(string learnerName, Table table)
        {

            var learnerBreakdown = new EarningsAndPaymentsBreakdown { ProviderId = "provider " + Defaults.ProviderIdSuffix };
            EarningAndPaymentTableParser.ParseEarningsAndPaymentsTableIntoContext(learnerBreakdown, table);

            var learner = LookupContext.AddOrGetUln(learnerName);
            var provider = LookupContext.AddOrGetUkprn(learnerBreakdown.ProviderId);


            var commitment = CommitmentsContext.Commitments.FirstOrDefault();
            foreach (var earned in learnerBreakdown.ProviderEarnedTotal)
            {
                var requiredPaymentId = Guid.NewGuid().ToString();
                var month = int.Parse(earned.PeriodName.Substring(0, 2));
                var year = int.Parse(earned.PeriodName.Substring(3, 2)) + 2000;
                var date = new DateTime(year, month, 1);
                var periodNumber = date.GetPeriodNumber();
                var periodName = $"1718-R" + periodNumber.ToString("00");

                if (earned.Value > 0)
                {
                    PaymentsManager.SavePaymentDue(requiredPaymentId, provider, learner, null, null, null, Defaults.StandardCode,
                                                        commitment, learnerName, periodName,
                                                        month, year,
                                                        (int)TransactionType.OnProgram,
                                                        commitment == null ? ContractType.ContractWithSfa : ContractType.ContractWithEmployer,
                                                        earned.Value);
                    var levyPayment = learnerBreakdown.SfaLevyBudget.Where(x => x.PeriodName == earned.PeriodName).SingleOrDefault();
                    if (levyPayment != null && levyPayment.Value > 0)
                    {
                        PaymentsManager.SavePayment(requiredPaymentId, periodName, month, year,
                                                          (int)TransactionType.OnProgram, FundingSource.Levy, levyPayment.Value);
                    }

                    var earnedFromEmployer = learnerBreakdown.ProviderEarnedFromEmployers.Where(x => x.PeriodName == earned.PeriodName).SingleOrDefault();
                    if (earnedFromEmployer != null && earnedFromEmployer.Value > 0)
                    {
                        PaymentsManager.SavePayment(requiredPaymentId, periodName, month, year,
                                                          (int)TransactionType.OnProgram, FundingSource.CoInvestedEmployer, earnedFromEmployer.Value);
                    }

                    var coInvestedBySfaLevy = learnerBreakdown.SfaLevyCoFundBudget.Where(x => x.PeriodName == earned.PeriodName).SingleOrDefault();
                    if (coInvestedBySfaLevy != null && coInvestedBySfaLevy.Value > 0)
                    {
                        PaymentsManager.SavePayment(requiredPaymentId, periodName, month, year,
                                                          (int)TransactionType.OnProgram, FundingSource.CoInvestedSfa, coInvestedBySfaLevy.Value);
                    }

                    var coInvestedBySfaNonLevy = learnerBreakdown.SfaNonLevyCoFundBudget.Where(x => x.PeriodName == earned.PeriodName).SingleOrDefault();
                    if (coInvestedBySfaNonLevy != null && coInvestedBySfaNonLevy.Value > 0)
                    {
                        PaymentsManager.SavePayment(requiredPaymentId, periodName, month, year,
                                                          (int)TransactionType.OnProgram, FundingSource.CoInvestedSfa, coInvestedBySfaNonLevy.Value);
                    }

                }
            }

          
        }
    }
}
