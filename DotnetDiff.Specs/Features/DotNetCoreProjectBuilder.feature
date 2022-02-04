Feature: DotNetCoreProjectBuilder

The feature should build provided .NET Core project files

@ProjectBuilder
Scenario Outline: Build dot NET Core project file
	Given the <projectFiles>
	When builder builds projects
	Then result should be true

Examples: 
| projectFiles |
| "DotnetDiff.TestProject1\DotnetDiff.TestProject1.csproj" |
| "DotnetDiff.TestProject1\DotnetDiff.TestProject2.csproj" |
| "DotnetDiff.TestProject1\DotnetDiff.TestProject3.csproj" |
| "DotnetDiff.TestProject1\DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject2\DotnetDiff.TestProject2.csproj"	|
| "DotnetDiff.TestProject1\DotnetDiff.TestProject2.csproj, DotnetDiff.TestProject2\DotnetDiff.TestProject3.csproj"	|
| "DotnetDiff.TestProject1\DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject2\DotnetDiff.TestProject3.csproj"	|
| "DotnetDiff.TestProject2\DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject3\DotnetDiff.TestProject2.csproj, DotnetDiff.TestProject3\DotnetDiff.TestProject3.cspro"	|