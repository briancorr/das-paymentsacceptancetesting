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
    [NUnit.Framework.DescriptionAttribute("Provider earnings and payments where learner completes later than planned")]
    public partial class ProviderEarningsAndPaymentsWhereLearnerCompletesLaterThanPlannedFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "learner_finishes_late.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-GB"), "Provider earnings and payments where learner completes later than planned", "    The earnings and payment rules for late completions are the same as for learn" +
                    "ers finishing on time, except that the completion payment is held back until com" +
                    "pletion.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 5
    #line 6
        testRunner.Given("the apprenticeship funding band maximum for each learner is 17000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A DAS learner, levy available, learner finishes late")]
        public virtual void ADASLearnerLevyAvailableLearnerFinishesLate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A DAS learner, levy available, learner finishes late", ((string[])(null)));
#line 8
    this.ScenarioSetup(scenarioInfo);
#line 5
    this.FeatureBackground();
#line 9
        testRunner.Given("levy balance > agreed price for all months", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table465 = new TechTalk.SpecFlow.Table(new string[] {
                        "ULN",
                        "priority",
                        "start date",
                        "end date",
                        "agreed price"});
            table465.AddRow(new string[] {
                        "learner a",
                        "1",
                        "01/09/2017",
                        "08/09/2018",
                        "15000"});
#line 10
  testRunner.And("the following commitments exist:", ((string)(null)), table465, "And ");
#line hidden
            TechTalk.SpecFlow.Table table466 = new TechTalk.SpecFlow.Table(new string[] {
                        "learner type",
                        "agreed price",
                        "start date",
                        "planned end date",
                        "actual end date",
                        "completion status"});
            table466.AddRow(new string[] {
                        "programme only DAS",
                        "15000",
                        "01/09/2017",
                        "08/09/2018",
                        "08/10/2018",
                        "completed"});
#line 13
        testRunner.When("an ILR file is submitted with the following data:", ((string)(null)), table466, "When ");
#line hidden
            TechTalk.SpecFlow.Table table467 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "09/17",
                        "10/17",
                        "11/17",
                        "...",
                        "08/18",
                        "09/18",
                        "10/18",
                        "11/18"});
            table467.AddRow(new string[] {
                        "Provider Earned Total",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "0",
                        "3000",
                        "0"});
            table467.AddRow(new string[] {
                        "Provider Earned from SFA",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "0",
                        "3000",
                        "0"});
            table467.AddRow(new string[] {
                        "Provider Paid by SFA",
                        "0",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "1000",
                        "0",
                        "3000"});
            table467.AddRow(new string[] {
                        "Levy account debited",
                        "0",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "1000",
                        "0",
                        "3000"});
            table467.AddRow(new string[] {
                        "SFA Levy employer budget",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "0",
                        "3000",
                        "0"});
            table467.AddRow(new string[] {
                        "SFA Levy co-funding budget",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0"});
#line 16
        testRunner.Then("the provider earnings and payments break down as follows:", ((string)(null)), table467, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A non-DAS learner, learner finishes late")]
        public virtual void ANon_DASLearnerLearnerFinishesLate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A non-DAS learner, learner finishes late", ((string[])(null)));
#line 26
    this.ScenarioSetup(scenarioInfo);
#line 5
    this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table468 = new TechTalk.SpecFlow.Table(new string[] {
                        "learner type",
                        "agreed price",
                        "start date",
                        "planned end date",
                        "actual end date",
                        "completion status"});
            table468.AddRow(new string[] {
                        "programme only non-DAS",
                        "15000",
                        "01/09/2017",
                        "08/09/2018",
                        "08/12/2018",
                        "completed"});
#line 27
        testRunner.When("an ILR file is submitted with the following data:", ((string)(null)), table468, "When ");
#line hidden
            TechTalk.SpecFlow.Table table469 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "09/17",
                        "10/17",
                        "11/17",
                        "...",
                        "08/18",
                        "09/18",
                        "10/18",
                        "11/18",
                        "12/18",
                        "01/19"});
            table469.AddRow(new string[] {
                        "Provider Earned Total",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "0",
                        "0",
                        "0",
                        "3000",
                        "0"});
            table469.AddRow(new string[] {
                        "Provider Earned from SFA",
                        "900",
                        "900",
                        "900",
                        "...",
                        "900",
                        "0",
                        "0",
                        "0",
                        "2700",
                        "0"});
            table469.AddRow(new string[] {
                        "Provider Earned from Employer",
                        "100",
                        "100",
                        "100",
                        "...",
                        "100",
                        "0",
                        "0",
                        "0",
                        "300",
                        "0"});
            table469.AddRow(new string[] {
                        "Provider Paid by SFA",
                        "0",
                        "900",
                        "900",
                        "...",
                        "900",
                        "900",
                        "0",
                        "0",
                        "0",
                        "2700"});
            table469.AddRow(new string[] {
                        "Payment due from Employer",
                        "0",
                        "100",
                        "100",
                        "...",
                        "100",
                        "100",
                        "0",
                        "0",
                        "0",
                        "300"});
            table469.AddRow(new string[] {
                        "Levy account debited",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table469.AddRow(new string[] {
                        "SFA Levy employer budget",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table469.AddRow(new string[] {
                        "SFA Levy co-funding budget",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table469.AddRow(new string[] {
                        "SFA non-Levy co-funding budget",
                        "900",
                        "900",
                        "900",
                        "...",
                        "900",
                        "0",
                        "0",
                        "0",
                        "2700",
                        "0"});
#line 30
        testRunner.Then("the provider earnings and payments break down as follows:", ((string)(null)), table469, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table470 = new TechTalk.SpecFlow.Table(new string[] {
                        "Payment type",
                        "10/17",
                        "11/17",
                        "12/17",
                        "01/18",
                        "...",
                        "09/18",
                        "10/18",
                        "11/18",
                        "12/18",
                        "01/19"});
            table470.AddRow(new string[] {
                        "On-program",
                        "900",
                        "900",
                        "900",
                        "900",
                        "...",
                        "900",
                        "0",
                        "0",
                        "0",
                        "0"});
            table470.AddRow(new string[] {
                        "Completion",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0",
                        "2700"});
            table470.AddRow(new string[] {
                        "Balancing",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table470.AddRow(new string[] {
                        "Employer 16-18 incentive",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table470.AddRow(new string[] {
                        "Provider 16-18 incentive",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
#line 41
        testRunner.And("the transaction types for the payments are:", ((string)(null)), table470, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A non-DAS learner, learner withdraws after planned end date")]
        public virtual void ANon_DASLearnerLearnerWithdrawsAfterPlannedEndDate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A non-DAS learner, learner withdraws after planned end date", ((string[])(null)));
#line 50
    this.ScenarioSetup(scenarioInfo);
#line 5
    this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table471 = new TechTalk.SpecFlow.Table(new string[] {
                        "agreed price",
                        "learner type",
                        "start date",
                        "planned end date",
                        "actual end date",
                        "completion status"});
            table471.AddRow(new string[] {
                        "15000",
                        "programme only non-DAS",
                        "01/09/2017",
                        "08/09/2018",
                        "08/12/2018",
                        "withdrawn"});
#line 52
        testRunner.When("an ILR file is submitted with the following data:", ((string)(null)), table471, "When ");
#line hidden
            TechTalk.SpecFlow.Table table472 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "09/17",
                        "10/17",
                        "11/17",
                        "...",
                        "08/18",
                        "09/18",
                        "10/18",
                        "11/18",
                        "12/18",
                        "01/19"});
            table472.AddRow(new string[] {
                        "Provider Earned Total",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "1000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table472.AddRow(new string[] {
                        "Provider Earned from SFA",
                        "900",
                        "900",
                        "900",
                        "...",
                        "900",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table472.AddRow(new string[] {
                        "Provider Earned from Employer",
                        "100",
                        "100",
                        "100",
                        "...",
                        "100",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table472.AddRow(new string[] {
                        "Provider Paid by SFA",
                        "0",
                        "900",
                        "900",
                        "...",
                        "900",
                        "900",
                        "0",
                        "0",
                        "0",
                        "0"});
            table472.AddRow(new string[] {
                        "Payment due from Employer",
                        "0",
                        "100",
                        "100",
                        "...",
                        "100",
                        "100",
                        "0",
                        "0",
                        "0",
                        "0"});
            table472.AddRow(new string[] {
                        "Levy account debited",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table472.AddRow(new string[] {
                        "SFA Levy employer budget",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table472.AddRow(new string[] {
                        "SFA Levy co-funding budget",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table472.AddRow(new string[] {
                        "SFA non-Levy co-funding budget",
                        "900",
                        "900",
                        "900",
                        "...",
                        "900",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
#line 56
        testRunner.Then("the provider earnings and payments break down as follows:", ((string)(null)), table472, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table473 = new TechTalk.SpecFlow.Table(new string[] {
                        "Payment type",
                        "10/17",
                        "11/17",
                        "12/17",
                        "01/18",
                        "...",
                        "09/18",
                        "10/18",
                        "11/18",
                        "12/18",
                        "01/19"});
            table473.AddRow(new string[] {
                        "On-program",
                        "900",
                        "900",
                        "900",
                        "900",
                        "...",
                        "900",
                        "0",
                        "0",
                        "0",
                        "0"});
            table473.AddRow(new string[] {
                        "Completion",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table473.AddRow(new string[] {
                        "Balancing",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table473.AddRow(new string[] {
                        "Employer 16-18 incentive",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table473.AddRow(new string[] {
                        "Provider 16-18 incentive",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
#line 68
        testRunner.And("the transaction types for the payments are:", ((string)(null)), table473, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
