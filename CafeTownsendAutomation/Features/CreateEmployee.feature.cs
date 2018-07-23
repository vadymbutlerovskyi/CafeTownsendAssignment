﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace CafeTownsendAutomation.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("CreateEmployeeSteps", Description="\tAs a user\r\n\tI want to be able to create a new employee", SourceFile="Features\\CreateEmployee.feature", SourceLine=0)]
    public partial class CreateEmployeeStepsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CreateEmployee.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CreateEmployeeSteps", "\tAs a user\r\n\tI want to be able to create a new employee", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
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
        
        public virtual void CreateANewEmployee(string username, string password, string firstname, string lastname, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "regression",
                    "CreateEmployee"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a new employee", @__tags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I open browser and go to CafeTownsend home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.Then(string.Format("I enter \'{0}\' into the \'username\' field", username), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
  testRunner.And(string.Format("I enter \'{0}\' into the \'password\' field", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When("I click on the Login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then(string.Format("I remove all employees such as \'{0}\' plus \'{1}\'", firstname, lastname), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
  testRunner.And("I see Edit button disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
  testRunner.And("I see Delete button disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
  testRunner.And("I click on the Create button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
  testRunner.And("I click on the Cancel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
  testRunner.And("I click on the Create button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table1.AddRow(new string[] {
                        "First name",
                        string.Format("{0}", firstname)});
            table1.AddRow(new string[] {
                        "Last name",
                        string.Format("{0}", lastname)});
            table1.AddRow(new string[] {
                        "Start date",
                        "Today"});
            table1.AddRow(new string[] {
                        "Email",
                        "m@m.com"});
#line 18
 testRunner.When("I fill in new employee data with the following:", ((string)(null)), table1, "When ");
#line 25
 testRunner.Then("I click on the Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
  testRunner.And("I see and select the new employee listed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
  testRunner.And("I close browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Create a new employee, Luke", new string[] {
                "regression",
                "CreateEmployee"}, SourceLine=30)]
        public virtual void CreateANewEmployee_Luke()
        {
#line 7
this.CreateANewEmployee("Luke", "Skywalker", "Robo", "Cop", ((string[])(null)));
#line hidden
        }
        
        public virtual void CreateANewEmployeeWithInvalidData(string username, string password, string alert, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "regression",
                    "CreateEmployee"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a new employee with invalid data", @__tags);
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given("I open browser and go to CafeTownsend home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.Then(string.Format("I enter \'{0}\' into the \'username\' field", username), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
  testRunner.And(string.Format("I enter \'{0}\' into the \'password\' field", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.When("I click on the Login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then("I click on the Create button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table2.AddRow(new string[] {
                        "First name",
                        "Robo"});
            table2.AddRow(new string[] {
                        "Last name",
                        "Cop"});
            table2.AddRow(new string[] {
                        "Start date",
                        "2000-13-32"});
            table2.AddRow(new string[] {
                        "Email",
                        "m@m.com"});
#line 43
 testRunner.When("I fill in new employee data with the following:", ((string)(null)), table2, "When ");
#line 50
 testRunner.Then("I click on the Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
  testRunner.And("I wait for \'3\' second(s)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
  testRunner.And(string.Format("I see the alert message \'{0}\'", alert), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.When("I \'accept\' the alert", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.Then("I see \'Start date\' field invalid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
  testRunner.And("I see Add button disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table3.AddRow(new string[] {
                        "First name",
                        "Robo"});
            table3.AddRow(new string[] {
                        "Last name",
                        "Cop"});
            table3.AddRow(new string[] {
                        "Start date",
                        "7/22/2018"});
            table3.AddRow(new string[] {
                        "Email",
                        "@mcom"});
#line 56
 testRunner.When("I fill in new employee data with the following:", ((string)(null)), table3, "When ");
#line 62
 testRunner.Then("I see \'Start date\' field invalid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 63
  testRunner.And("I see \'Email\' field invalid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
  testRunner.Then("I see Add button disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table4.AddRow(new string[] {
                        "First name",
                        "Robo"});
            table4.AddRow(new string[] {
                        "Last name",
                        "Cop"});
            table4.AddRow(new string[] {
                        "Start date",
                        "Today"});
            table4.AddRow(new string[] {
                        "Email",
                        "m@mcom"});
#line 65
 testRunner.When("I fill in new employee data with the following:", ((string)(null)), table4, "When ");
#line 71
 testRunner.Then("I see Add button disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
  testRunner.And("I click on the Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
  testRunner.And("I see \'Email\' field invalid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
  testRunner.And("I close browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Create a new employee with invalid data, Luke", new string[] {
                "regression",
                "CreateEmployee"}, SourceLine=78)]
        public virtual void CreateANewEmployeeWithInvalidData_Luke()
        {
#line 37
this.CreateANewEmployeeWithInvalidData("Luke", "Skywalker", "Error trying to create a new employee: {\"start_date\":[\"can\'t be blank\"]})", ((string[])(null)));
#line hidden
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
