#r "nuget: CsvHelper, 12.3.2"
#load "MyData.cs"
#nullable enable

using CsvHelper;
using CsvHelper.Configuration;

class MyDataClassMap : ClassMap<MyData>
{
    public MyDataClassMap()
    {
        // If CSV has header, mapping will be resolved by name.
        Map(m => m.id);
        Map(m => m.message);
        Map(m => m.date).TypeConverterOption.Format("yyyyMMddHHmmss");

        // If CSV has no header, index can be specified.
        // Map(m => m.id).Index(0);
    }
}

class MyDataParser
{
    const bool HasHeaderRecord = true;

    public string csv { get; }
    public Encoding encoding { get; }

    public MyDataParser(string csv, Encoding encoding)
      => (this.csv, this.encoding) = (csv, encoding);

    public IEnumerable<MyData> GetMyData()
    {
        using var sr = new StreamReader(csv, encoding);

        var reader = new CsvReader(sr);
        reader.Configuration.HasHeaderRecord = MyDataParser.HasHeaderRecord;
        reader.Configuration.RegisterClassMap<MyDataClassMap>();

        var data = reader.GetRecords<MyData>().ToList();
        return data;
    }
}
