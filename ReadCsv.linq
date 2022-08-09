<Query Kind="Program">
  <NuGetReference>CsvHelper</NuGetReference>
  <Namespace>CsvHelper.Configuration</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>CsvHelper</Namespace>
</Query>

/* test.csv
Id,Name
1,one
2,two
*/

public class Foo
{
	public int Id { get; set; }
	public string Name { get; set; }
}

public class FooNull
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string NullProperty { get; set; }
}

void Main()
{
	var config = new CsvConfiguration(CultureInfo.InvariantCulture)
	{
		NewLine = Environment.NewLine,
	};
	
	var path = Path.GetDirectoryName(Util.CurrentQueryPath);
	using (var reader = new StreamReader(Path.Join(path, "test.csv")))
	using (var csv = new CsvReader(reader, config))
	{
		var records = csv.GetRecords<Foo>();
		Console.WriteLine(records.First().Id);
	}

	// Get dynamic records
	using (var reader = new StreamReader(Path.Join(path, "test.csv")))
	using (var csv = new CsvReader(reader, config))
	{
		var records = csv.GetRecords<dynamic>();
		Console.WriteLine(records.First().Id);
	}

	// Read csv file with missing column.
	var newConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
	{
		NewLine = Environment.NewLine,
		HeaderValidated = null,
		MissingFieldFound = null,
	};
	
	using (var reader = new StreamReader(Path.Join(path, "test.csv")))
	using (var csv = new CsvReader(reader, newConfig))
	{
		var records = csv.GetRecords<FooNull>();
		Console.WriteLine(records.First().Id);
		Console.WriteLine(records.First().NullProperty);
	}
}

// You can define other methods, fields, classes and namespaces here