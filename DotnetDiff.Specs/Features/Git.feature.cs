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
    public partial class GitFeature : object, Xunit.IClassFixture<GitFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Git.feature"
#line hidden
        
        public GitFeature(GitFeature.FixtureData fixtureData, DotnetDiff_Specs_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Git", "The feature should return changed files between commits", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Get changed file with Git")]
        [Xunit.TraitAttribute("FeatureTitle", "Git")]
        [Xunit.TraitAttribute("Description", "Get changed file with Git")]
        [Xunit.TraitAttribute("Category", "Git")]
        [Xunit.InlineDataAttribute("\"56964225a0b7229e3ae836784cc5fdd628596865\"", "\"8e3dac791cbb9eab6b0cf438f6506ef209c47b0f\"", "\"DotnetDiff.TestProject1/Class1.cs\"", new string[0])]
        [Xunit.InlineDataAttribute("\"957c843d48abd7bc7e013e9a5a8b803d7e76ddda\"", "\"63035a6538821277cab1fb5143370e7e8430983d\"", "\"DotnetDiff.TestProject1/Class2.cs\"", new string[0])]
        [Xunit.InlineDataAttribute("\"957c843d48abd7bc7e013e9a5a8b803d7e76ddda\"", "\"35df4f2fca35b5ffd9a7c677b8448fa3cd52e6c5\"", "\"DotnetDiff.TestProject1/Class3.cs\"", new string[0])]
        [Xunit.InlineDataAttribute("\"56964225a0b7229e3ae836784cc5fdd628596865\"", "\"957c843d48abd7bc7e013e9a5a8b803d7e76ddda\"", "\"DotnetDiff.TestProject1/Class1.cs, DotnetDiff.TestProject1/Class2.cs\"", new string[0])]
        [Xunit.InlineDataAttribute("\"56964225a0b7229e3ae836784cc5fdd628596865\"", "\"188ee75c77d4124ca3f2054eab5eecc5d8dd06a3\"", "\"DotnetDiff.TestProject1/Class1.cs, DotnetDiff.TestProject1/Class3.cs\"", new string[0])]
        [Xunit.InlineDataAttribute("\"56964225a0b7229e3ae836784cc5fdd628596865\"", "\"dbd11c8c8b055db8c2b2251aab7ccf60fdf9c9a3\"", "\"DotnetDiff.TestProject1/Class1.cs, DotnetDiff.TestProject1/Class3.cs, DotnetDiff" +
            ".TestProject2/Class1.cs\"", new string[0])]
        [Xunit.InlineDataAttribute("\"56964225a0b7229e3ae836784cc5fdd628596865\"", "\"d913d54f4af58d4fe98f7a03af188b7190421a99\"", "\"DotnetDiff.TestProject1/Class1.cs, DotnetDiff.TestProject1/Class3.cs, DotnetDiff" +
            ".TestProject2/Class1.cs, DotnetDiff.TestProject2/Class2.cs\"", new string[0])]
        [Xunit.InlineDataAttribute("\"d913d54f4af58d4fe98f7a03af188b7190421a99\"", "\"5aeb8bb21a2ccb16800332196a63642becf54ea7\"", "\"DotnetDiff.TestProject2/ClassOne.cs, DotnetDiff.TestProject2/ClassTwo.cs\"", new string[0])]
        [Xunit.InlineDataAttribute("\"d913d54f4af58d4fe98f7a03af188b7190421a99\"", "\"744da2da6691a15cce7c4d5fb9f534aecf58960c\"", "\"DotnetDiff.TestProject2/ClassOne.cs, DotnetDiff.TestProject3/Class1.cs, DotnetDi" +
            "ff.TestProject3/Class2.cs, DotnetDiff.TestProject3/Class3.cs, DotnetDiff.TestPro" +
            "ject3/Class4.cs\"", new string[0])]
        public virtual void GetChangedFileWithGit(string firstCommitSha, string secondCommitSha, string pathes, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Git"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("firstCommitSha", firstCommitSha);
            argumentsOfScenario.Add("secondCommitSha", secondCommitSha);
            argumentsOfScenario.Add("pathes", pathes);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get changed file with Git", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
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
 testRunner.Given(string.Format("the first commit is {0}", firstCommitSha), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.And(string.Format("the second commit is {0}", secondCommitSha), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 9
 testRunner.When("Git returns changed file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
 testRunner.Then(string.Format("the file should be {0}", pathes), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
                GitFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GitFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
