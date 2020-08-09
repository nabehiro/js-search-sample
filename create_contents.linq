<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <NuGetReference>System.Interactive</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

class Article
{
	public string Id { get; set; }
	public string Sentence { get; set; }
}

void Main()
{
	var inputPath = @"C:\Users\HiroyukiWatanabe\Desktop\794_ruby_4237\sanshiro.txt";
	var outputPath = @"C:\Users\HiroyukiWatanabe\Desktop\sanshiro.json";
	
	var lines = File.ReadAllLines(inputPath, Encoding.UTF8);
	
	var list = new List<Article>();
	foreach (var sub in lines.Buffer(10))
	{
		var first = sub.First() ?? "";
		var id = $"{list.Count + 1}. {first.Substring(0, Math.Min(15, first.Length))}";
		
		list.Add(new Article
		{
			Id = id,
			Sentence = string.Join('\n', sub)
		});
	}
	
	var json = JsonConvert.SerializeObject(list);
	File.WriteAllText(outputPath, json);
}

// Define other methods, classes and namespaces here
