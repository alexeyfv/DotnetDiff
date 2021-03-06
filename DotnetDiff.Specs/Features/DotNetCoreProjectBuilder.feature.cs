// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace DotnetDiff.Specs.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class DotNetCoreProjectBuilderFeature : object, Xunit.IClassFixture<DotNetCoreProjectBuilderFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "DotNetCoreProjectBuilder.feature"
#line hidden
        
        public DotNetCoreProjectBuilderFeature(DotNetCoreProjectBuilderFeature.FixtureData fixtureData, DotnetDiff_Specs_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "DotNetCoreProjectBuilder", "The feature should build provided .NET Core project files", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Build dot NET Core project file")]
        [Xunit.TraitAttribute("FeatureTitle", "DotNetCoreProjectBuilder")]
        [Xunit.TraitAttribute("Description", "Build dot NET Core project file")]
        [Xunit.TraitAttribute("Category", "ProjectBuilder")]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj\"", "\"TestFolder\"", "true", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject2\\DotnetDiff.TestProject2.csproj\"", "\"TestFolder\"", "true", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject3\\DotnetDiff.TestProject3.csproj\"", "\"TestFolder\"", "true", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject2\\" +
            "DotnetDiff.TestProject2.csproj\"", "\"TestFolder\"", "true", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject2\\DotnetDiff.TestProject2.csproj, DotnetDiff.TestProject3\\" +
            "DotnetDiff.TestProject3.csproj\"", "\"TestFolder\"", "true", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject3\\" +
            "DotnetDiff.TestProject3.csproj\"", "\"TestFolder\"", "true", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject2\\" +
            "DotnetDiff.TestProject2.csproj, DotnetDiff.TestProject3\\DotnetDiff.TestProject3." +
            "csproj\"", "\"TestFolder\"", "true", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject2\\DotnetDiff.TestProject123.csproj\"", "\"TestFolder\"", "false", new string[0])]
        public virtual void BuildDotNETCoreProjectFile(string projectFiles, string outputFolder, string result, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ProjectBuilder"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("projectFiles", projectFiles);
            argumentsOfScenario.Add("outputFolder", outputFolder);
            argumentsOfScenario.Add("result", result);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Build dot NET Core project file", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
 testRunner.Given(string.Format("the {0}", projectFiles), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.When(string.Format("builder builds projects to {0}", outputFolder), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 9
 testRunner.Then(string.Format("result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 10
 testRunner.And(string.Format("output files are exist shoukd be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                DotNetCoreProjectBuilderFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                DotNetCoreProjectBuilderFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
