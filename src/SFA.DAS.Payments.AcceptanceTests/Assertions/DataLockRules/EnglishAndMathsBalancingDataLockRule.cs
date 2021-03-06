﻿using System.Collections.Generic;
using System.Linq;
using SFA.DAS.Payments.AcceptanceTests.ResultsDataModels;

namespace SFA.DAS.Payments.AcceptanceTests.Assertions.DataLockRules
{
    public class EnglishAndMathsBalancingDataLockRule : DataLockRuleBase
    {
        public EnglishAndMathsBalancingDataLockRule() : base("english and maths balancing")
        {
        }

        protected override IEnumerable<DataLockResult> FilterPeriodStatuses(DataLockPeriodResults periodStatuses)
        {
            return periodStatuses.Matches.Where(m => m.TransactionType == ReferenceDataModels.TransactionType.BalancingMathsAndEnglish);
        }
    }
}
