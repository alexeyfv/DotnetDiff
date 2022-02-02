Feature: Git

@mytag
Scenario: Get changed files with Git
	Given the first commit is "56964225a0b7229e3ae836784cc5fdd628596865"
	And the second commit is "8e3dac791cbb9eab6b0cf438f6506ef209c47b0f"
	When Git returns changed files
	Then the result should be "DotnetDiff.TestProject1/Class1.cs"