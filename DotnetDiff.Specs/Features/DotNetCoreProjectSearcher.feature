Feature: DotNetCoreProjectSearcher

The feature should find .NET Core project file (if exists) for provided files 

@tag1
Scenario Outline: Find dot NET Core project file
	Given the <files>
	When searcher returns project
	Then the projects should be <projects>

Examples: 
| sourceFiles							| projects													|
| "DotnetDiff.TestProject1/Class1.cs"	| "DotnetDiff.TestProject1/DotnetDiff.TestProject1.csproj"	|
| "DotnetDiff.TestProject1/Class2.cs"	| "DotnetDiff.TestProject1/DotnetDiff.TestProject1.csproj"	|
| "DotnetDiff.TestProject1/Class3.cs"	| "DotnetDiff.TestProject1/DotnetDiff.TestProject1.csproj"	|
| "DotnetDiff.TestProject1/Class1.cs, DotnetDiff.TestProject1/Class2.cs"	| "DotnetDiff.TestProject1/DotnetDiff.TestProject1.csproj"	|
| "DotnetDiff.TestProject1/Class1.cs, DotnetDiff.TestProject1/Class3.cs"	| "DotnetDiff.TestProject1/DotnetDiff.TestProject1.csproj"	|
| "DotnetDiff.TestProject1/Class1.cs, DotnetDiff.TestProject1/Class3.cs, DotnetDiff.TestProject2/Class1.cs"	| "DotnetDiff.TestProject1/DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject2/DotnetDiff.TestProject2.csproj"	|
| "DotnetDiff.TestProject1/Class1.cs, DotnetDiff.TestProject1/Class3.cs, DotnetDiff.TestProject2/Class1.cs, DotnetDiff.TestProject2/Class2.cs"	| "DotnetDiff.TestProject1/DotnetDiff.TestProject1.csproj, DotnetDiff.TestProject2/DotnetDiff.TestProject2.csproj"	|
| "DotnetDiff.TestProject2/ClassOne.cs, DotnetDiff.TestProject2/ClassTwo.cs"	| "DotnetDiff.TestProject2/DotnetDiff.TestProject2.csproj"	|
| "DotnetDiff.TestProject2/ClassOne.cs, DotnetDiff.TestProject3/Class1.cs, DotnetDiff.TestProject3/Class2.cs, DotnetDiff.TestProject3/Class3.cs, DotnetDiff.TestProject3/Class4.cs"	| "DotnetDiff.TestProject2/DotnetDiff.TestProject2.csproj, DotnetDiff.TestProject3/DotnetDiff.TestProject3.csproj"	|