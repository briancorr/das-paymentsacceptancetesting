﻿using TechTalk.SpecFlow;

namespace SFA.DAS.Payments.AcceptanceTests.Refactoring.StepDefinitions
{
    [Binding]
    public class UntestedSteps
    {
        [Given("the apprenticeship funding band maximum for each learner is (.*)")]
        [Given(@"the apprenticeship funding band maximum is (.*)")] // Duplicate?
        public void GivenFundingBandMax(int fundingBandMax)
        {
        }

        [Given("The learner is programme only DAS")]
        [Given("Two learners are programme only DAS")]
        public void GivenTheLearnerIsProgrammeOnlyDas()
        {
        }

        [Given("the learner changes employers")]
        public void GivenTheLearnerChangesEmployers(Table employmentDates)
        {
        }
    }
}