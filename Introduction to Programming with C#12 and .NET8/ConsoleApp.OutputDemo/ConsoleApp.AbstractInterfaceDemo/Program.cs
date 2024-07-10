// See https://aka.ms/new-console-template for more information

// Polygon polygon = new Polygon(); // complier error
Rectangle rectangle = new Rectangle(10, 20);
var rectangleArea = rectangle.Area();
Console.WriteLine("Rectangle area = {0}", rectangleArea);

Square square = new Square(50);
var squareArea = square.Area();
Console.WriteLine("Square area = {0}", squareArea);

Cuboid cuboid = new Cuboid(1, 2, 3);
var cuboidArea = cuboid.Area();
var cuboidVolume = cuboid.Volume();
var cuboidPerimeter = cuboid.Perimeter();
Console.WriteLine("Cuboid perimeter = {0}", cuboidPerimeter);
Console.WriteLine("Cuboid volume = {0}", cuboidVolume);
Console.WriteLine("Cuboid area = {0}", cuboidArea);