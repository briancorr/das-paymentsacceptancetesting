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
    [NUnit.Framework.DescriptionAttribute("Employer stops payments on a commitment")]
    public partial class EmployerStopsPaymentsOnACommitmentFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "employer_stops_payments.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-GB"), "Employer stops payments on a commitment", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Commitment payments are stopped midway through the learning episode")]
        public virtual void CommitmentPaymentsAreStoppedMidwayThroughTheLearningEpisode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Commitment payments are stopped midway through the learning episode", ((string[])(null)));
#line 3
    this.ScenarioSetup(scenarioInfo);
#line 4
        testRunner.Given("levy balance > agreed price for all months", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ULN",
                        "agreed price",
                        "status",
                        "stopped on"});
            table2.AddRow(new string[] {
                        "learner a",
                        "15000",
                        "stopped",
                        "11/17"});
#line 5
        testRunner.And("the following commitments exist:", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ULN",
                        "agreed price",
                        "learner type",
                        "start date",
                        "planned end date",
                        "completion status"});
            table3.AddRow(new string[] {
                        "learner a",
                        "15000",
                        "programme only DAS",
                        "01/09/2017",
                        "08/09/2018",
                        "continuing"});
#line 8
        testRunner.When("an ILR file is submitted every month with the following data:", ((string)(null)), table3, "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "09/17",
                        "10/17",
                        "11/17",
                        "12/17",
                        "...",
                        "03/18"});
            table4.AddRow(new string[] {
                        "Provider Earned Total",
                        "1000",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "1000"});
            table4.AddRow(new string[] {
                        "Provider Earned from SFA",
                        "1000",
                        "1000",
                        "0",
                        "0",
                        "...",
                        "0"});
            table4.AddRow(new string[] {
                        "Provider Earned from Employer",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0"});
            table4.AddRow(new string[] {
                        "Provider Paid by SFA",
                        "0",
                        "1000",
                        "1000",
                        "0",
                        "...",
                        "0"});
            table4.AddRow(new string[] {
                        "Payment due from Employer",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0"});
            table4.AddRow(new string[] {
                        "Levy account debited",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0"});
            table4.AddRow(new string[] {
                        "SFA Levy employer budget",
                        "0",
                        "1000",
                        "1000",
                        "0",
                        "...",
                        "0"});
            table4.AddRow(new string[] {
                        "SFA Levy co-funded budget",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0"});
            table4.AddRow(new string[] {
                        "SFA non-Levy co-funding budget",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0"});
#line 11
        testRunner.Then("the provider earnings and payments break down as follows:", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The provider submits the first ILR file after the commitment payments have been s" +
            "topped")]
        public virtual void TheProviderSubmitsTheFirstILRFileAfterTheCommitmentPaymentsHaveBeenStopped()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The provider submits the first ILR file after the commitment payments have been s" +
                    "topped", ((string[])(null)));
#line 24
    this.ScenarioSetup(scenarioInfo);
#line 25
        testRunner.Given("levy balance > agreed price for all months", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "ULN",
                        "agreed price",
                        "status",
                        "stopped on"});
            table5.AddRow(new string[] {
                        "learner a",
                        "15000",
                        "stopped",
                        "11/17"});
#line 26
        testRunner.And("the following commitments exist:", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "ULN",
                        "agreed price",
                        "learner type",
                        "start date",
                        "planned end date",
                        "completion status"});
            table6.AddRow(new string[] {
                        "learner a",
                        "15000",
                        "programme only DAS",
                        "01/09/2017",
                        "08/09/2018",
                        "continuing"});
#line 29
        testRunner.When("an ILR file is submitted for the first time in 12/17 with the following data:", ((string)(null)), table6, "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "09/17",
                        "10/17",
                        "11/17",
                        "12/17",
                        "...",
                        "03/18"});
            table7.AddRow(new string[] {
                        "Provider Earned Total",
                        "1000",
                        "1000",
                        "1000",
                        "1000",
                        "...",
                        "1000"});
            table7.AddRow(new string[] {
                        "Provider Earned from SFA",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0"});
            table7.AddRow(new string[] {
                        "Provider Earned from Employer",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0"});
            table7.AddRow(new string[] {
                        "Provider Paid by SFA",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0"});
            table7.AddRow(new string[] {
                        "Payment due from Employer",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0"});
            table7.AddRow(new string[] {
                        "Levy account debited",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0"});
            table7.AddRow(new string[] {
                        "SFA Levy employer budget",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0"});
            table7.AddRow(new string[] {
                        "SFA Levy co-funded budget",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0"});
            table7.AddRow(new string[] {
                        "SFA non-Levy co-funding budget",
                        "0",
                        "0",
                        "0",
                        "0",
                        "...",
                        "0"});
#line 32
        testRunner.Then("the provider earnings and payments break down as follows:", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
