Feature: Git

@mytag
Scenario Outline: Get changed file with Git
	Given the first commit is <firstCommitSha>
	And the second commit is <secondCommitSha>
	When Git returns changed file
	Then the file should be <filePath>

Examples: 
| firstCommitSha							 | secondCommitSha							  | filePath							|
| "56964225a0b7229e3ae836784cc5fdd628596865" | "8e3dac791cbb9eab6b0cf438f6506ef209c47b0f" | "DotnetDiff.TestProject1/Class1.cs" |
| "957c843d48abd7bc7e013e9a5a8b803d7e76ddda" | "37ac3eaf035bb66a95fff66f104268a1b2536605" | "DotnetDiff.TestProject1/Class2.cs" |
| "63035a6538821277cab1fb5143370e7e8430983d" | "35df4f2fca35b5ffd9a7c677b8448fa3cd52e6c5" | "DotnetDiff.TestProject1/Class2.cs" |