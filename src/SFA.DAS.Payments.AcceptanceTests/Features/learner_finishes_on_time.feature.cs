﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SFA.DAS.Payments.AcceptanceTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Provider earnings and payments where learner completes on time and is funded by l" +
        "evy")]
    public partial class ProviderEarningsAndPaymentsWhereLearnerCompletesOnTimeAndIsFundedByLevyFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "learner_finishes_on_time.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-GB"), "Provider earnings and payments where learner completes on time and is funded by l" +
                    "evy", @"    For earnings, the total cost of training for an apprentice is split between:
    - 80% of the total cost split into equal monthly instalments
    - 20% of the total cost held back until completion

    For payments, where there is no lag in ILR submission, payments follow these rules:
    - Provider payment follows the month after earnings
    - This is due to the fact that activity relating to earnings is captured for funding purposes on the fourth working day of the next calendar month
    - The levy account is debited in the same month as payment is made (although at different times in the month)
    - Spend against budget is represented against the month in which funding is earned
    - Where a levy account is used for funding, payments are made against the SFA Levy budget
    - Levy funds are used until they run out, and then co-funding is used
    - The order in which learners are funded is derived from the priorities of the commitments", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 16
    #line 17
        testRunner.Given("the apprenticeship funding band maximum for each learner is 17000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A DAS learner, levy available, learner finishes on time")]
        public virtual void ADASLearnerLevyAvailableLearnerFinishesOnTime()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A DAS learner, levy available, learner finishes on time", ((string[])(null)));
#line 19
    this.ScenarioSetup(scenarioInfo);
#line 16
    this.FeatureBackground();
#line 20
        testRunner.Given("levy balance > agreed price for all months", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "learner type",
                        "agreed price",
                        "start date",
                        "planned end date",
                        "actual end date",
                        "completion status"});
            table5.AddRow(new string[] {
                        "programme only DAS",
                        "15000",
                        "01/09/2017",
                        "08/09/2018",
                        "08/09/2018",
                        "completed"});
#line 21
        testRunner.When("an ILR file is submitted with the following data:", ((string)(null)), table5, "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "09/17",
                        "10/17",
                        "11/17",
                        "...",
                        "08/18",
                        "09/18",
                        "10/18"});
            table6.AddRow(new string[] {
                        "Provider Earned Total",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "3000",
                        "0"});
            table6.AddRow(new string[] {
                        "Provider Earned from SFA",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "3000",
                        "0"});
            table6.AddRow(new string[] {
                        "Provider Paid by SFA",
                        "0",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "1000",
                        "3000"});
            table6.AddRow(new string[] {
                        "Levy account debited",
                        "0",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "1000",
                        "3000"});
            table6.AddRow(new string[] {
                        "SFA Levy employer budget",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "3000",
                        "0"});
            table6.AddRow(new string[] {
                        "SFA Levy co-funding budget",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0"});
#line 24
        testRunner.Then("the provider earnings and payments break down as follows:", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A DAS learner, no levy available, learner finishes on time")]
        public virtual void ADASLearnerNoLevyAvailableLearnerFinishesOnTime()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A DAS learner, no levy available, learner finishes on time", ((string[])(null)));
#line 34
    this.ScenarioSetup(scenarioInfo);
#line 16
    this.FeatureBackground();
#line 35
        testRunner.Given("levy balance = 0 for all months", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "learner type",
                        "agreed price",
                        "start date",
                        "planned end date",
                        "actual end date",
                        "completion status"});
            table7.AddRow(new string[] {
                        "programme only DAS",
                        "15000",
                        "01/09/2017",
                        "08/09/2018",
                        "08/09/2018",
                        "completed"});
#line 36
        testRunner.When("an ILR file is submitted with the following data:", ((string)(null)), table7, "When ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "09/17",
                        "10/17",
                        "11/17",
                        "...",
                        "08/18",
                        "09/18",
                        "10/18"});
            table8.AddRow(new string[] {
                        "Provider Earned Total",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "3000",
                        "0"});
            table8.AddRow(new string[] {
                        "Provider Earned from SFA",
                        "900",
                        "900",
                        "900",
                        "...",
                        "900",
                        "2700",
                        "0"});
            table8.AddRow(new string[] {
                        "Provider Earned from Employer",
                        "100",
                        "100",
                        "100",
                        "...",
                        "100",
                        "300",
                        "0"});
            table8.AddRow(new string[] {
                        "Provider Paid by SFA",
                        "0",
                        "900",
                        "900",
                        "...",
                        "900",
                        "900",
                        "2700"});
            table8.AddRow(new string[] {
                        "Payment due from Employer",
                        "0",
                        "100",
                        "100",
                        "...",
                        "100",
                        "100",
                        "300"});
            table8.AddRow(new string[] {
                        "Levy account debited",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0"});
            table8.AddRow(new string[] {
                        "SFA Levy employer budget",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0"});
            table8.AddRow(new string[] {
                        "SFA Levy co-funded budget",
                        "900",
                        "900",
                        "900",
                        "...",
                        "900",
                        "2700",
                        "0"});
            table8.AddRow(new string[] {
                        "SFA non-Levy co-funding budget",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        ""});
#line 39
        testRunner.Then("the provider earnings and payments break down as follows:", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("2 DAS learners, only enough levy to cover 1")]
        public virtual void _2DASLearnersOnlyEnoughLevyToCover1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("2 DAS learners, only enough levy to cover 1", ((string[])(null)));
#line 52
    this.ScenarioSetup(scenarioInfo);
#line 16
    this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "09/17",
                        "10/17",
                        "11/17",
                        "...",
                        "08/18",
                        "09/18",
                        "10/18"});
            table9.AddRow(new string[] {
                        "0",
                        "500",
                        "500",
                        "500",
                        "500",
                        "1500",
                        "1500"});
#line 53
        testRunner.Given("the employer\'s levy balance is:", ((string)(null)), table9, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "ULN",
                        "priority"});
            table10.AddRow(new string[] {
                        "learner a",
                        "1"});
            table10.AddRow(new string[] {
                        "learner b",
                        "2"});
#line 56
        testRunner.And("the following commitments exist:", ((string)(null)), table10, "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "ULN",
                        "agreed price",
                        "learner type",
                        "start date",
                        "planned end date",
                        "actual end date",
                        "completion status"});
            table11.AddRow(new string[] {
                        "learner a",
                        "7500",
                        "programme only DAS",
                        "01/09/2017",
                        "08/09/2018",
                        "08/09/2018",
                        "completed"});
            table11.AddRow(new string[] {
                        "learner b",
                        "15000",
                        "programme only DAS",
                        "01/09/2017",
                        "08/09/2018",
                        "08/09/2018",
                        "completed"});
#line 60
        testRunner.When("an ILR file is submitted with the following data:", ((string)(null)), table11, "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "09/17",
                        "10/17",
                        "11/17",
                        "...",
                        "08/18",
                        "09/18",
                        "10/18"});
            table12.AddRow(new string[] {
                        "Provider Earned Total",
                        "1500",
                        "1500",
                        "1500",
                        "...",
                        "1500",
                        "4500",
                        "0"});
            table12.AddRow(new string[] {
                        "Provider Earned from SFA",
                        "1350",
                        "1400",
                        "1400",
                        "...",
                        "1400",
                        "4200",
                        "0"});
            table12.AddRow(new string[] {
                        "Provider Earned from Employer",
                        "150",
                        "100",
                        "100",
                        "...",
                        "100",
                        "300",
                        "0"});
            table12.AddRow(new string[] {
                        "Provider Paid by SFA",
                        "0",
                        "1400",
                        "1400",
                        "...",
                        "1400",
                        "1400",
                        "4200"});
            table12.AddRow(new string[] {
                        "Payment due from Employer",
                        "0",
                        "100",
                        "100",
                        "...",
                        "100",
                        "100",
                        "300"});
            table12.AddRow(new string[] {
                        "Levy account debited",
                        "0",
                        "0",
                        "500",
                        "...",
                        "500",
                        "500",
                        "1500"});
            table12.AddRow(new string[] {
                        "SFA Levy employer budget",
                        "0",
                        "500",
                        "500",
                        "...",
                        "500",
                        "1500",
                        "0"});
            table12.AddRow(new string[] {
                        "SFA Levy co-funded budget",
                        "1350",
                        "900",
                        "900",
                        "...",
                        "900",
                        "2700",
                        "0"});
            table12.AddRow(new string[] {
                        "SFA non-Levy co-funding budget",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        ""});
#line 64
        testRunner.Then("the provider earnings and payments break down as follows:", ((string)(null)), table12, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A non-DAS learner, learner finishes on time")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void ANon_DASLearnerLearnerFinishesOnTime()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A non-DAS learner, learner finishes on time", new string[] {
                        "ignore"});
#line 78
    this.ScenarioSetup(scenarioInfo);
#line 16
    this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "agreed price",
                        "learner type",
                        "start date",
                        "planned end date",
                        "actual end date",
                        "completion status"});
            table13.AddRow(new string[] {
                        "15000",
                        "programme only non-DAS",
                        "01/09/2017",
                        "08/09/2018",
                        "08/09/2018",
                        "completed"});
#line 79
        testRunner.When("an ILR file is submitted with the following data:", ((string)(null)), table13, "When ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "09/17",
                        "10/17",
                        "11/17",
                        "...",
                        "08/18",
                        "09/18",
                        "10/18"});
            table14.AddRow(new string[] {
                        "Provider Earned Total",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "3000",
                        "0"});
            table14.AddRow(new string[] {
                        "Provider Earned from SFA",
                        "900",
                        "900",
                        "900",
                        "...",
                        "900",
                        "2700",
                        "0"});
            table14.AddRow(new string[] {
                        "Provider Earned from Employer",
                        "100",
                        "100",
                        "100",
                        "...",
                        "100",
                        "300",
                        "0"});
            table14.AddRow(new string[] {
                        "Provider Paid by SFA",
                        "0",
                        "900",
                        "900",
                        "...",
                        "900",
                        "900",
                        "2700"});
            table14.AddRow(new string[] {
                        "Payment due from Employer",
                        "0",
                        "100",
                        "100",
                        "...",
                        "100",
                        "100",
                        "300"});
            table14.AddRow(new string[] {
                        "Levy account debited",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0"});
            table14.AddRow(new string[] {
                        "SFA Levy employer budget",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0"});
            table14.AddRow(new string[] {
                        "SFA Levy co-funded budget",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0"});
            table14.AddRow(new string[] {
                        "SFA non-Levy co-funding budget",
                        "900",
                        "900",
                        "900",
                        "...",
                        "900",
                        "2700",
                        "0"});
#line 82
        testRunner.Then("the provider earnings and payments break down as follows:", ((string)(null)), table14, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
