<Query Kind="Program" />

void Main()
{
	// For empty list, All always returns true.
	var stringList = new List<string> ();
	Console.WriteLine(stringList.All(s => s == "e"));
	// OUTPUT: true
	
	Console.WriteLine(stringList.All(s => s != "e"));
	// OUTPUT: true
}
