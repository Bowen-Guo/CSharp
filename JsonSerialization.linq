<Query Kind="Program">
  <Namespace>System.Text.Json</Namespace>
</Query>

public class Apple1
{
	private string _color;
	public string Color { get; set; }
}

public class Apple2
{
	private string _color;
	public string Color
	{
		get
		{
			Console.WriteLine($"Color in Apple2 = {_color}.");
			return _color;
		}
		
		set
		{
			Console.WriteLine($"Color in Apple2 is set as {value}.");
			_color = value;
		}
	}
}

void Main()
{
	// 1. Private field is not json-serialized.
	// 2. Set method is called when deserializing an object.
	var apple = new Apple1 { Color = "Red" };
	var serialized = JsonSerializer.Serialize(apple);
	Console.WriteLine(serialized);  // Output: {"Color":"Red"}
	var apple2 = JsonSerializer.Deserialize<Apple2>(serialized);  // Output: Color in Apple2 is set as Red.
}
