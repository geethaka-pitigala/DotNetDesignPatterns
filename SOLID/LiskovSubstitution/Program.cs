using System;


namespace Liskov;
public class Liskov {
    static void Main(string[] args){
        Rectangle square = new Square();
        square.Height = 4;

        Console.WriteLine(square.toString());
    }

}

public class Rectangle{
    public virtual int Height { get; set; }
    public virtual int Width { get; set; }

    public Rectangle(){}

    public Rectangle(int height, int width){
        this.Height = height;
        this.Width = width;
    }

    public int area(){
        return this.Height * this.Width;
    }

    public string toString(){
        return $"A rectangle with Height {Height} and Width {Width} with Area {area()}";
    }

}

public class Square: Rectangle{
    public Square(){}

    public Square(int sideLength)
    {
        base.Height = base.Width = sideLength;
    }

    public override int Width { 
        set{
            base.Height = base.Width = value;
        }
     }
    public override int Height { 
        set{
            base.Height = base.Width = value;
        }
    }

}