<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\dotnet\sdk\7.0.103\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\dotnet\shared\Microsoft.NETCore.App\7.0.3\System.Private.DataContractSerialization.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\dotnet\shared\Microsoft.NETCore.App\7.0.3\System.Runtime.Serialization.Json.dll</Reference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>System.Runtime.Serialization.Json</Namespace>
</Query>

void Main()
{
	var jsonString = """{"food":{"fruit":{"apple":{"colour":"red","size":"small"},"orange":{"colour":"orange","size":"large"}}}}""";
	JObject foodJsonObj = JObject.Parse(jsonString);
	Console.WriteLine(foodJsonObj);
	// JObject object is also a JToken object.
	Console.WriteLine(foodJsonObj is JToken);  // Expect output: True
	// JObject inherits JToken.
	Console.WriteLine(typeof(JObject).IsSubclassOf(typeof(JToken)));  // Expect output: True
	
	// A field of JObject object is JValue
	Console.WriteLine(foodJsonObj["food"]["fruit"]["apple"]["colour"].GetType());  // Expect output: Newtonsoft.Json.Linq.JValue
	// JObject can also be a field of JObject.
	Console.WriteLine(foodJsonObj["food"].GetType());  // Expect output: Newtonsoft.Json.Linq.JObject
	
	// Serialize jsonObject with Newtonsoft JsonConvert.
	var serialized = JsonConvert.SerializeObject(foodJsonObj);
	Console.WriteLine(serialized);

	// Serialize jsonObject with DataContractJsonSerializer.
	// This should fail.
	var serializer = new DataContractJsonSerializer(typeof(JObject));
	using (var ms = new MemoryStream())
    {
		try
		{
    		serializer.WriteObject(ms, foodJsonObj);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Faied to serialize JObject with DataContractJsonSerializer. Exception message: {ex.Message}");
		}
    }
}
