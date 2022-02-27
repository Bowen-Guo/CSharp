<Query Kind="Program" />

// Deferred execution of linq query: https://www.tutorialsteacher.com/linq/linq-deferred-execution
void Main()
{
	var array = new int[] {1, 2, 3};
	// The query does not execute in select.
	var array2 = array.Select(a => {Console.WriteLine("[array2] Select is executed."); return (a + 1); });
	
	Console.WriteLine($"Before enumearting.");
	// The query executes when array2 is iterated.
	foreach (var a in array2)
	{
		Console.WriteLine($"Enumerating {a}...");
	}
	
	// The query executes when invoking ToList().
	var array3 = array.Select(a => {Console.WriteLine("[array3] Select is executed."); return (a + 1); }).ToList();
}

