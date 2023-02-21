<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task<int> PrintAsync()
{
	await Task.Delay(1000).ConfigureAwait(false);
	Console.WriteLine("Test");
	return 1;
}

async Task Main()
{
	/*
		PrintAsync method will be invoked twice. 
	*/
	var l = new List<int> {1, 2, 3, 4};
	var taskList = l.Select(l=>PrintAsync());
	/*
		First time to invoke PrintAsync method.
		PrintAsync is invoked concurrently.
	*/
	await Task.WhenAll(taskList).ConfigureAwait(false);
	/*
		Second time to invoke PrintAsync method.
		PrintAsync is invoked synchronously.
	*/
	var a = taskList.Select(i => PrintAsync().Result).ToList();
}