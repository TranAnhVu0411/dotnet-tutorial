public class Cuboid : Polygon, I2DShape, I3DShape
{
    public Cuboid(int width, int height, int length){
        Width = width;
        Height = height;
        Length = length;
    }
    public int Length { get; set; }
    public int Height { get; set; }
    public override int Area()
    {
        return 2*((Width*Height)+(Height*Length)+(Length*Width));
    }

    public int Perimeter()
    {
        return 4*(Width+Height+Length);
    }

    public int Volume()
    {
        return Width*Height*Length;
    }
}