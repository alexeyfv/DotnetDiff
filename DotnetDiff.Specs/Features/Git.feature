Feature: Git

@mytag
Scenario: Get changed files with Git
	Given the first commit is "aebec361a1e2bdf6930020dbd0469c1307c952d6"
	And the second commit is "477497b4538668a81b58b5dd599d43f5e5af34e3"
	When the version control system gets changed files
	Then the result should be "TestProject3/Class1.cs"