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
    [NUnit.Framework.DescriptionAttribute("Provider earnings and payments for a learner with a negotiated price above the fu" +
        "nding band cap")]
    public partial class ProviderEarningsAndPaymentsForALearnerWithANegotiatedPriceAboveTheFundingBandCapFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "capping.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-GB"), "Provider earnings and payments for a learner with a negotiated price above the fu" +
                    "nding band cap", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("640-AC01-Payment for a DAS learner with a negotiated price above the funding band" +
            " cap")]
        public virtual void _640_AC01_PaymentForADASLearnerWithANegotiatedPriceAboveTheFundingBandCap()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("640-AC01-Payment for a DAS learner with a negotiated price above the funding band" +
                    " cap", ((string[])(null)));
#line 3
this.ScenarioSetup(scenarioInfo);
#line 4
    testRunner.Given("levy balance > agreed price for all months", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
    testRunner.And("the apprenticeship funding band maximum is 15000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table84 = new TechTalk.SpecFlow.Table(new string[] {
                        "commitment Id",
                        "version Id",
                        "provider",
                        "ULN",
                        "start date",
                        "end date",
                        "agreed price",
                        "standard code",
                        "status",
                        "effective from",
                        "effective to"});
            table84.AddRow(new string[] {
                        "1",
                        "1",
                        "provider a",
                        "learner a",
                        "01/08/2017",
                        "01/08/2018",
                        "18000",
                        "50",
                        "active",
                        "01/08/2017",
                        ""});
#line 6
    testRunner.And("the following commitments exist:", ((string)(null)), table84, "And ");
#line hidden
            TechTalk.SpecFlow.Table table85 = new TechTalk.SpecFlow.Table(new string[] {
                        "provider",
                        "ULN",
                        "learner type",
                        "agreed price",
                        "start date",
                        "planned end date",
                        "actual end date",
                        "completion status",
                        "standard code"});
            table85.AddRow(new string[] {
                        "provider a",
                        "learner a",
                        "programme only DAS",
                        "18000",
                        "06/08/2017",
                        "08/08/2018",
                        "",
                        "continuing",
                        "50"});
#line 9
    testRunner.When("an ILR file is submitted with the following data:", ((string)(null)), table85, "When ");
#line hidden
            TechTalk.SpecFlow.Table table86 = new TechTalk.SpecFlow.Table(new string[] {
                        "provider",
                        "price episode",
                        "negotiated price",
                        "funding cap",
                        "previous funding paid",
                        "price above cap",
                        "effective price for SFA payments"});
            table86.AddRow(new string[] {
                        "provider a",
                        "08/17 - 08/18",
                        "18000",
                        "15000",
                        "0",
                        "3000",
                        "15000"});
#line 12
    testRunner.Then("the following capping will apply to the price episodes:", ((string)(null)), table86, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table87 = new TechTalk.SpecFlow.Table(new string[] {
                        "Type",
                        "08/17",
                        "09/17",
                        "10/17",
                        "11/17",
                        "12/17"});
            table87.AddRow(new string[] {
                        "Provider Earned Total",
                        "1000",
                        "1000",
                        "1000",
                        "1000",
                        "1000"});
            table87.AddRow(new string[] {
                        "Provider Earned from SFA",
                        "1000",
                        "1000",
                        "1000",
                        "1000",
                        "1000"});
            table87.AddRow(new string[] {
                        "Provider Earned from Employer",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table87.AddRow(new string[] {
                        "Provider Paid by SFA",
                        "0",
                        "1000",
                        "1000",
                        "1000",
                        "1000"});
            table87.AddRow(new string[] {
                        "Payment due from Employer",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table87.AddRow(new string[] {
                        "Levy account debited",
                        "0",
                        "1000",
                        "1000",
                        "1000",
                        "1000"});
            table87.AddRow(new string[] {
                        "SFA Levy employer budget",
                        "1000",
                        "1000",
                        "1000",
                        "1000",
                        "1000"});
            table87.AddRow(new string[] {
                        "SFA Levy co-funding budget",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table87.AddRow(new string[] {
                        "SFA Levy additional payments budget",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table87.AddRow(new string[] {
                        "SFA non-Levy co-funding budget",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
#line 15
    testRunner.And("the provider earnings and payments break down as follows:", ((string)(null)), table87, "And ");
#line hidden
            TechTalk.SpecFlow.Table table88 = new TechTalk.SpecFlow.Table(new string[] {
                        "Payment type",
                        "09/17",
                        "10/17",
                        "11/17",
                        "12/17"});
            table88.AddRow(new string[] {
                        "On-program",
                        "1000",
                        "1000",
                        "1000",
                        "1000"});
            table88.AddRow(new string[] {
                        "Completion",
                        "0",
                        "0",
                        "0",
                        "0"});
            table88.AddRow(new string[] {
                        "Balancing",
                        "0",
                        "0",
                        "0",
                        "0"});
            table88.AddRow(new string[] {
                        "Employer 16-18 incentive",
                        "0",
                        "0",
                        "0",
                        "0"});
            table88.AddRow(new string[] {
                        "Provider 16-18 incentive",
                        "0",
                        "0",
                        "0",
                        "0"});
#line 27
    testRunner.And("the transaction types for the payments are:", ((string)(null)), table88, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
