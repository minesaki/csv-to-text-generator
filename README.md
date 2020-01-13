# csv-to-text-generator
Utility script to generate texts using CSV data.

## Characteristics
- read/parse CSV file data.
- generate text by the data.
- .NET Core 3.x / C# 8 (scripting) / T4 (Text Template Transformation Toolkit)

## How to use

### Setup
".NET Core SDK 3.x", "dotnet-script" and "dotnet-t4" are required.  
If they are not installed on your machine, run setup.sh.
```
$ ./setup.sh
```

### Run with sample data
```
$ ./script.sh
```

### Customize text template
1. Edit template. (MyTemplate.tt)  
   Variables defined in MyData.cs and any C# code can be used in the template.

### Customize CSV data format
1. Edit model definition. (MyData.cs)
1. Edit parser. (MyDataParser.cs)
1. Edit template. (MyTemplate.tt, MyTemplate.cs)
1. Place mydata.csv of new format.
1. Run.
