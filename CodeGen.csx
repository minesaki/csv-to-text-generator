#r "nuget: System.CodeDom, 4.0.2.0"
#load "MyDataParser.cs"
#load "MyTemplate.cs"
#nullable enable

// arguments
string csv = Args.Count() > 0 ? Args[0] : string.Empty;
string outputDir = Args.Count() > 1 ? Args[1] : string.Empty;

// error if csv file not exists
if (!File.Exists(csv))
{
    Console.WriteLine(
  @"Usage: dotnet script codegen.csx -- [csvfile] [outputdir]
  Generated text will be output in console if outputdir is not specified.");
    return;
}

// create output dir if not exists
bool isDirInput = !string.IsNullOrWhiteSpace(outputDir);
if (isDirInput && !Directory.Exists(outputDir))
    Directory.CreateDirectory(outputDir);

// define output process
Action<string, string> output = isDirInput switch
{
    true => ((outputFile, text) =>
    {
        File.WriteAllText(Path.Combine(outputDir, outputFile), text);
        Console.WriteLine(text);
    }),
    false => (_, text) => Console.WriteLine(text)
};

// output template-generated text
foreach (var data in new MyDataParser(csv, Encoding.UTF8).GetMyData())
{
    var template = new MyTemplate(data);
    output(template.filename, template.TransformText());
}

if (isDirInput)
{
    Console.WriteLine($"Generated texts are saved in \"{outputDir}\"");
}
