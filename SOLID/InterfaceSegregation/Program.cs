using System;

namespace InterfaceSegregation{
public class Program{
    static void Main(string[] args){
        Photocopier photocopier = new Photocopier();
        Document document = new Document("SOLID Principles", 300);
        photocopier.Print(document);
        photocopier.Scan(document);

    }

}

public class Document{
    public string Name { get; set; }
    public int Pages { get; set; }

    public Document(string name, int pages)
    {
        this.Name = name;
        this.Pages = pages;
    }

    public override string ToString(){
        return $"Document {Name} has {Pages} pages";
    }
}

public interface IScanner{
    public void Scan(Document document);
}

public interface IPrinter{
    public void Print(Document document);
}

public class Photocopier: IScanner, IPrinter{
    public void Scan(Document document){
        Console.WriteLine($"{document.ToString()} is scanned.");
    }

    public void Print(Document document){
        Console.WriteLine($"{document.ToString()} is printed.");
    }
}

}