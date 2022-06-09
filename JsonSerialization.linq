<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\NuGetPackages\newtonsoft.json\9.0.1\lib\net45\Newtonsoft.Json.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Text.Json</Namespace>
</Query>

public class Apple1
{
	private string Weight;
	
	public string Color { get; set; }
}

public class Apple2
{
	public string Weight {get; set;}
	
	public string Color {get; set;}

	[JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
	public string Height {get; set;}
}


void Main()
{
	// 1. Private field is not json-serialized.
	// 2. Set method is called when deserializing an object.
	// 3. If no property matches the key, no exception will be thrown.
	// 4. Null property will also be serialized, except for properties with attribute 
	//	  [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
	var apple = new Apple1 { Color = "Red" };
	var serialized = JsonConvert.SerializeObject(apple);
	Console.WriteLine(serialized);  // Output: {"Color":"Red"}
	
	var apple2 = new Apple2 { Color = "Red", Weight = "500g" };
	serialized = JsonConvert.SerializeObject(apple2);
	var apple1 = JsonConvert.DeserializeObject<Apple1>(serialized);
	Console.WriteLine(apple1.Color);  // Output: Red.
	
	var apple3 = new Apple2 { Color = "Red" };
	Console.WriteLine(JsonConvert.SerializeObject(apple3));  // Output: {"Weight":null,"Color":"Red"}
}
