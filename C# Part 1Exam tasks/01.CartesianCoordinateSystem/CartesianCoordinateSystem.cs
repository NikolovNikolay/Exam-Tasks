using System;

class CartesianCoordinateSystem
{
    static void Main()
    {
        double coordinateX = double.Parse(Console.ReadLine());
        double coordinateY = double.Parse(Console.ReadLine());
        int result = 0;

        if (coordinateX > 0 && coordinateY > 0)
        {
            result = 1;
        }
        if (coordinateX > 0 && coordinateY < 0)
        {
            result = 4;
        }
        if (coordinateX < 0 && coordinateY < 0)
        {
            result = 3;
        }
        if (coordinateX < 0 && coordinateY > 0)
        {
            result = 2;
        }
        if (coordinateX == 0 && coordinateY == 0)
        {
            result = 0;
        }
        if (coordinateX == 0 && coordinateY != 0)
        {
            result = 5;
        }
        if (coordinateX != 0 && coordinateY == 0)
        {
            result = 6;
        }
        Console.WriteLine(result);
    }
}