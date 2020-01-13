#load "MyData.cs"
#load "MyTemplate.generated.cs"
#nullable enable

// Template class
// This class has data/processes used from text template.
// To generate TemplateBase class, write tt(text template) file and run T4 engine. (cf. gen.sh)

public partial class MyTemplate : MyTemplateBase
{
    MyData data { get; }

    public string filename { get => data.id.ToString(); }

    public MyTemplate(MyData data) => this.data = data;
}
