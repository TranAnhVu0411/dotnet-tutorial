using ConsoleApp.NameSpaceDemo.Interface;

namespace ConsoleApp.NameSpaceDemo.Class.ShapeDemo;
public class Rectangle : Polygon, I2DShape{
    public Rectangle(int width, int length){
        Width = width;
        Length = length;
    }
    public int Length { get; set; }

    public override int Area()
    {
        return Length*Width;
    }

    public int Perimeter()
    {
        return 2 * (Length + Width);
    }
}