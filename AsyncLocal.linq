<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

public static class TestAsyncLocal
{
	private static AsyncLocal<int> _asyncLocal = new AsyncLocal<int> ();
	
	public static void SetValue(int value)
	{
		_asyncLocal.Value = value;
	}
	
	public static async Task PrintAsyncLocalValue()
	{
		Console.WriteLine($"Asynclocal value before await: {_asyncLocal.Value}");
		await Task.Delay(500).ConfigureAwait(false);
		Console.WriteLine($"Asynclocal value after await: {_asyncLocal.Value}");
	}
}

void Main()
{
	for (var i=0; i<3; i++)
	{
		var a = i;
		Task.Run(async () => {
			await Task.Delay(500);
			TestAsyncLocal.SetValue(a);
			await TestAsyncLocal.PrintAsyncLocalValue();
		});
	}
}

//Expected output:
//Asynclocal value before await: 2
//Asynclocal value before await: 1
//Asynclocal value before await: 0
//Asynclocal value after await: 2
//Asynclocal value after await: 0
//Asynclocal value after await: 1
