Feature: DotNetCoreProjectBuilder

The feature should build provided .NET Core project files

@ProjectBuilder
Scenario Outline: Build dot NET Core project file
	Given the <projectFiles>
	When builder builds projects
	Then result should be <result>

Examples: 
| projectFiles                                                                                                                                                                | result |
| "DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj"                                                                                                                   | true   |
| "DotnetDiff.TestProject2\\DotnetDiff.TestProject2.csproj"                                                                                                                   | true   |
| "DotnetDiff.TestProject3\\DotnetDiff.TestProject3.csproj"                                                                                                                   | true   |
| "DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject2\\DotnetDiff.TestProject2.csproj"                                                          | true   |
| "DotnetDiff.TestProject2\\DotnetDiff.TestProject2.csproj, DotnetDiff.TestProject3\\DotnetDiff.TestProject3.csproj"                                                          | true   |
| "DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject3\\DotnetDiff.TestProject3.csproj"                                                          | true   |
| "DotnetDiff.TestProject1\\DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject2\\DotnetDiff.TestProject2.csproj, DotnetDiff.TestProject3\\DotnetDiff.TestProject3.csproj" | true   |
| "DotnetDiff.TestProject2\\DotnetDiff.TestProject123.csproj"                                                                                                                 | false  |