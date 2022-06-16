<Query Kind="Program" />

public class AppleEnumerator : IEnumerator
{
	private int _index = -1;
	private string[] _array;
	
	public AppleEnumerator(string[] array)
	{
		_array = array;
	}

	object IEnumerator.Current => _array[_index];

	public bool MoveNext()
	{
		_index += 1;
		Console.WriteLine("Moving next...");
		if (_index < _array.Count())
		{
			return true;
		}
		
		return false;
	}

	public void Reset()
	{
		_index = -1;
	}
}

public class Apples : IEnumerable
{ 
	private AppleEnumerator _appleEnumerator;
	
	public Apples(string[] array)
	{
		_appleEnumerator = new AppleEnumerator(array);	
	}
	
	public IEnumerator GetEnumerator()
	{
		return _appleEnumerator;
	}
}

void Main()
{
	var list = new string[] {"a", "b", "c", "d"};
	var apples = new Apples(list);
	foreach (var a in apples)
	{
		Console.WriteLine(a);
	}

	// Expected output:
	/*
	Moving next...
	a
	Moving next...
	b
	Moving next...
	c
	Moving next...
	d
	Moving next...
	*/
}
