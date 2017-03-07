﻿using System;
using System.Collections.Generic;
using System.Linq;
using SFA.DAS.Payments.AcceptanceTests.Refactoring.Contexts;
using SFA.DAS.Payments.AcceptanceTests.Refactoring.ExecutionManagers;
using SFA.DAS.Payments.AcceptanceTests.Refactoring.ReferenceDataModels;
using TechTalk.SpecFlow;

namespace SFA.DAS.Payments.AcceptanceTests.Refactoring.StepDefinitions
{
    [Binding]
    public class EmployerAccountSteps
    {
        public EmployerAccountSteps(EmployerAccountContext employerAccountContext)
        {
            EmployerAccountContext = employerAccountContext;
        }
        public EmployerAccountContext EmployerAccountContext { get; }

        [Given("levy balance > agreed price for all months")]
        public void GivenUnnamedEmployersLevyBalanceIsMoreThanPrice()
        {
            GivenNamedEmployersLevyBalanceIsMoreThanPrice(Defaults.EmployerAccountId.ToString());
        }

        [Given("the employer (.*) has a levy balance > agreed price for all months")]
        public void GivenNamedEmployersLevyBalanceIsMoreThanPrice(string employerNumber)
        {
            int id;
            if (!int.TryParse(employerNumber, out id))
            {
                throw new ArgumentException($"Employer number '{employerNumber}' is not a valid number");
            }

            AddEmployerAccount(id, int.MaxValue);
        }

        [Given("levy balance = 0 for all months")]
        public void GivenLevyBalanceIsZero()
        {
            AddEmployerAccount(Defaults.EmployerAccountId, 0m);
        }

        [Given("the employer's levy balance is:")]
        public void GivenUnnamedEmployersLevyBalanceIsDifferentPerMonth(Table employerBalancesTable)
        {
            GivenNamedEmployersLevyBalanceIsDifferentPerMonth(Defaults.EmployerAccountId.ToString(), employerBalancesTable);
        }

        [Given("the employer (.*) has a levy balance of:")]
        public void GivenNamedEmployersLevyBalanceIsDifferentPerMonth(string employerNumber, Table employerBalancesTable)
        {
            int id;
            if (!int.TryParse(employerNumber, out id))
            {
                throw new ArgumentException($"Employer number '{employerNumber}' is not a valid number");
            }
            if (employerBalancesTable.RowCount > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(employerBalancesTable), "Balances table can only contain a single row");
            }

            var periodBalances = new List<PeriodValue>();
            for (var c = 0; c < employerBalancesTable.Header.Count; c++)
            {
                var periodName = employerBalancesTable.Header.ElementAt(c);
                if (periodName == "...")
                {
                    continue;
                }
                if (!Validations.IsValidPeriodName(periodName))
                {
                    throw new ArgumentException($"'{periodName}' is not a valid period name format. Expected MM/YY");
                }

                int periodBalance;
                if (!int.TryParse(employerBalancesTable.Rows[0][c], out periodBalance))
                {
                    throw new ArgumentException($"Balance '{employerBalancesTable.Rows[0][c]}' is not a value balance");
                }

                periodBalances.Add(new PeriodValue
                {
                    PeriodName = periodName,
                    Value = periodBalance
                });
            }

            AddEmployerAccount(id, 0m, periodBalances);
        }


        private void AddEmployerAccount(int id, decimal balance, List<PeriodValue> periodBalances = null)
        {
            var account = new EmployerAccountReferenceData
            {
                Id = id,
                Balance = balance,
                PeriodBalances = periodBalances ?? new List<PeriodValue>()
            };

            EmployerAccountManager.AddAccount(account);

            EmployerAccountContext.EmployerAccounts.Add(account);
        }
    }
}
