Feature: DotNetCoreProjectBuilder

The feature should build provided .NET Core project files

@ProjectBuilder
Scenario Outline: Build dot NET Core project file
	Given the <projectFiles>
	When builder builds projects to <outputFolder>
	Then result should be <result>
	And output files are exist shoukd be <result>

Examples: 
| projectFiles                                                                                                                                                                | outputFolder | result |
| "DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj"                                                                                                                   | "TestFolder" | true   |
| "DotnetDiff.TestProject2\\DotnetDiff.TestProject2.csproj"                                                                                                                   | "TestFolder" | true   |
| "DotnetDiff.TestProject3\\DotnetDiff.TestProject3.csproj"                                                                                                                   | "TestFolder" | true   |
| "DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject2\\DotnetDiff.TestProject2.csproj"                                                          | "TestFolder" | true   |
| "DotnetDiff.TestProject2\\DotnetDiff.TestProject2.csproj, DotnetDiff.TestProject3\\DotnetDiff.TestProject3.csproj"                                                          | "TestFolder" | true   |
| "DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject3\\DotnetDiff.TestProject3.csproj"                                                          | "TestFolder" | true   |
| "DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject2\\DotnetDiff.TestProject2.csproj, DotnetDiff.TestProject3\\DotnetDiff.TestProject3.csproj" | "TestFolder" | true   |
| "DotnetDiff.TestProject2\\DotnetDiff.TestProject123.csproj"                                                                                                                 | "TestFolder" | false  |