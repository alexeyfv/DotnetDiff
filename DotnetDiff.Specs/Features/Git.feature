Feature: Git

@mytag
Scenario Outline: Get changed file with Git
	Given the first commit is <firstCommitSha>
	And the second commit is <secondCommitSha>
	When Git returns changed file
	Then the file should be <pathes>

Examples: 
| firstCommitSha							 | secondCommitSha							  | pathes								|

# Change DotnetDiff.TestProject1/Class1.cs
| "56964225a0b7229e3ae836784cc5fdd628596865" | "8e3dac791cbb9eab6b0cf438f6506ef209c47b0f" | "DotnetDiff.TestProject1/Class1.cs" |

# Change DotnetDiff.TestProject1/Class2.cs
| "957c843d48abd7bc7e013e9a5a8b803d7e76ddda" | "63035a6538821277cab1fb5143370e7e8430983d" | "DotnetDiff.TestProject1/Class2.cs" |

# Rename DotnetDiff.TestProject1/Class2.cs to DotnetDiff.TestProject1/Class3.cs
| "957c843d48abd7bc7e013e9a5a8b803d7e76ddda" | "35df4f2fca35b5ffd9a7c677b8448fa3cd52e6c5" | "DotnetDiff.TestProject1/Class3.cs" |

# Change DotnetDiff.TestProject1/Class1.cs,
# Add DotnetDiff.TestProject1/Class2.cs
| "56964225a0b7229e3ae836784cc5fdd628596865" | "957c843d48abd7bc7e013e9a5a8b803d7e76ddda" | "DotnetDiff.TestProject1/Class1.cs, DotnetDiff.TestProject1/Class2.cs" |

# Change DotnetDiff.TestProject1/Class1.cs
# Add DotnetDiff.TestProject1/Class2.cs
# Rename DotnetDiff.TestProject1/Class2.cs to DotnetDiff.TestProject1/Class3.cs,
# Delete DotnetDiff.TestProject1/Class1.cs
| "56964225a0b7229e3ae836784cc5fdd628596865" | "188ee75c77d4124ca3f2054eab5eecc5d8dd06a3" | "DotnetDiff.TestProject1/Class1.cs, DotnetDiff.TestProject1/Class3.cs" | 

# Change DotnetDiff.TestProject1/Class1.cs
# Add DotnetDiff.TestProject1/Class2.cs
# Rename DotnetDiff.TestProject1/Class2.cs to DotnetDiff.TestProject1/Class3.cs,
# Delete DotnetDiff.TestProject1/Class1.cs
# Change DotnetDiff.TestProject2/Class1.cs
| "56964225a0b7229e3ae836784cc5fdd628596865" | "dbd11c8c8b055db8c2b2251aab7ccf60fdf9c9a3" | "DotnetDiff.TestProject1/Class1.cs, DotnetDiff.TestProject1/Class3.cs, DotnetDiff.TestProject2/Class1.cs" |

# Change DotnetDiff.TestProject1/Class1.cs
# Add DotnetDiff.TestProject1/Class2.cs
# Rename DotnetDiff.TestProject1/Class2.cs to DotnetDiff.TestProject1/Class3.cs,
# Delete DotnetDiff.TestProject1/Class1.cs
# Change DotnetDiff.TestProject2/Class1.cs
# Add DotnetDiff.TestProject2/Class2.cs
| "56964225a0b7229e3ae836784cc5fdd628596865" | "d913d54f4af58d4fe98f7a03af188b7190421a99" | "DotnetDiff.TestProject1/Class1.cs, DotnetDiff.TestProject1/Class3.cs, DotnetDiff.TestProject2/Class1.cs, DotnetDiff.TestProject2/Class2.cs" | 

# Change DotnetDiff.TestProject2/Class1.cs
# Add DotnetDiff.TestProject2/Class2.cs
# Rename both of them
| "d913d54f4af58d4fe98f7a03af188b7190421a99" | "5aeb8bb21a2ccb16800332196a63642becf54ea7" | "DotnetDiff.TestProject2/ClassOne.cs, DotnetDiff.TestProject2/ClassTwo.cs" | 

# Change DotnetDiff.TestProject2/Class1.cs
# Add DotnetDiff.TestProject2/Class2.cs
# Rename both of them
# Remove DotnetDiff.TestProject2/ClassTwo.cs"
# Change DotnetDiff.TestProject3/Class1.cs
# Add DotnetDiff.TestProject3/Class2.cs
# Add DotnetDiff.TestProject3/Class3.cs
# Add DotnetDiff.TestProject3/Class4.cs
| "d913d54f4af58d4fe98f7a03af188b7190421a99" | "744da2da6691a15cce7c4d5fb9f534aecf58960c" | "DotnetDiff.TestProject2/ClassOne.cs, DotnetDiff.TestProject3/Class1.cs, DotnetDiff.TestProject3/Class2.cs, DotnetDiff.TestProject3/Class3.cs, DotnetDiff.TestProject3/Class4.cs" |