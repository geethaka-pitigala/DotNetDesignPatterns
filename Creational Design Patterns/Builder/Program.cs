using System.Text;
using static System.Console;

namespace Builder;
public class Program{
    public static void Main(string[] args){
        HTMLBuilder hb = new HTMLBuilder("body");
        hb.AddChild("li").AddChild("li").AddChild("li");
        WriteLine(hb);

    }

}

public class HTMLElement{
    public string? Name;
    public string? Text;
    public List<HTMLElement> children = new List<HTMLElement>();

    public HTMLElement(){}
    public HTMLElement(string Name){this.Name = Name;}
    public HTMLElement(string Name, string Text){this.Name = Name; this.Text = Text;}

    private readonly int _IndentSize = 5;

    public string ToStringImpl(int Indentation)
    {
        var sb = new StringBuilder();
        sb.Append(new string(' ', Indentation * _IndentSize));
        sb.AppendFormat("<{0}>{1}\n", Name, Text);

        // children
        foreach(var el in children){
            sb.AppendLine(el.ToStringImpl(Indentation+1));
        }
        
        sb.Append(new string(' ', Indentation * _IndentSize));
        sb.AppendFormat("</{0}>\n", Name);

        return sb.ToString();
    }

    public override string ToString()
    {
        return ToStringImpl(0);
    }

}

public class HTMLBuilder{
    private HTMLElement Root;

    public HTMLBuilder(string Name)
    {
        this.Root = new HTMLElement(Name);
    }

    public HTMLBuilder AddChild(HTMLElement child){
        this.Root.children.Add(child);
        return this;
    }

    public HTMLBuilder AddChild(string childName){
        this.AddChild(new HTMLElement(childName));
        return this;
    }

    public HTMLBuilder AddChildren(List<HTMLElement> children){
        foreach(var child in children){
            this.AddChild(child);
        }
            return this;
    }

    public override string ToString()
    {
        return Root.ToString();
    }
}
