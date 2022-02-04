﻿// ------------------------------------------------------------------------------
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
    public partial class DotNetCoreProjectSearcherFeature : object, Xunit.IClassFixture<DotNetCoreProjectSearcherFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "DotNetCoreProjectSearcher.feature"
#line hidden
        
        public DotNetCoreProjectSearcherFeature(DotNetCoreProjectSearcherFeature.FixtureData fixtureData, DotnetDiff_Specs_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "DotNetCoreProjectSearcher", "The feature should find .NET Core project file (if exists) for provided files ", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Find dot NET Core project file")]
        [Xunit.TraitAttribute("FeatureTitle", "DotNetCoreProjectSearcher")]
        [Xunit.TraitAttribute("Description", "Find dot NET Core project file")]
        [Xunit.TraitAttribute("Category", "tag1")]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject1\\Class1.cs\"", "\"DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj\"", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject1\\Class2.cs\"", "\"DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj\"", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject1\\Class3.cs\"", "\"DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj\"", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject1\\Class1.cs, DotnetDiff.TestProject1\\Class2.cs\"", "\"DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj\"", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject1\\Class1.cs, DotnetDiff.TestProject1\\Class3.cs\"", "\"DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj\"", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject1\\Class1.cs, DotnetDiff.TestProject1\\Class3.cs, DotnetDiff" +
            ".TestProject2\\Class1.cs\"", "\"DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject2\\" +
            "DotnetDiff.TestProject2.csproj\"", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject1\\Class1.cs, DotnetDiff.TestProject1\\Class3.cs, DotnetDiff" +
            ".TestProject2\\Class1.cs, DotnetDiff.TestProject2\\Class2.cs\"", "\"DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject2\\" +
            "DotnetDiff.TestProject2.csproj\"", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject2\\ClassOne.cs, DotnetDiff.TestProject2\\ClassTwo.cs\"", "\"DotnetDiff.TestProject2\\DotnetDiff.TestProject2.csproj\"", new string[0])]
        [Xunit.InlineDataAttribute("\"DotnetDiff.TestProject2\\ClassOne.cs, DotnetDiff.TestProject3\\Class1.cs, DotnetDi" +
            "ff.TestProject3\\Class2.cs, DotnetDiff.TestProject3\\Class3.cs, DotnetDiff.TestPro" +
            "ject3\\Class4.cs\"", "\"DotnetDiff.TestProject2\\DotnetDiff.TestProject2.csproj, DotnetDiff.TestProject3\\" +
            "DotnetDiff.TestProject3.csproj\"", new string[0])]
        public virtual void FindDotNETCoreProjectFile(string sourceFiles, string projects, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "tag1"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("sourceFiles", sourceFiles);
            argumentsOfScenario.Add("projects", projects);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Find dot NET Core project file", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
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
 testRunner.Given(string.Format("the {0}", sourceFiles), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.When("searcher returns project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 9
 testRunner.Then(string.Format("the projects should be {0}", projects), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
                DotNetCoreProjectSearcherFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                DotNetCoreProjectSearcherFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion