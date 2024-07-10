using ConsoleApp.NameSpaceDemo.Interface;

namespace ConsoleApp.NameSpaceDemo.Class.ShapeDemo;
public class Square : Polygon, I2DShape{
    public Square(int width){
        Width = width;
    }
    public override int Area()
    {
        return Width*Width;
    }

    public int Perimeter()
    {
        return 4 * Width;
    }
}