using System;

class FighterAttack
{
    static void Main(string[] args)
    {
        int rectangleDownLeft = int.Parse(Console.ReadLine());
        int rectangleTopLeft = int.Parse(Console.ReadLine());
        int rectangleTopRigth = int.Parse(Console.ReadLine());
        int rectangleDownRight = int.Parse(Console.ReadLine());

        int fighterX = int.Parse(Console.ReadLine());
        int fighterY = int.Parse(Console.ReadLine());

        int distance = int.Parse(Console.ReadLine());

        int hitPointX = fighterX + distance;
        int hitpointY = fighterY;


        int minX = Math.Min(rectangleDownLeft, rectangleTopRigth);
        int maxX = Math.Max(rectangleDownLeft, rectangleTopRigth);
        int minY = Math.Min(rectangleTopLeft, rectangleDownRight);
        int maxY = Math.Max(rectangleTopLeft, rectangleDownRight);

        int damage = 0;

        if ((hitPointX >= minX && hitPointX <= maxX) &&
                (hitpointY >= minY && hitpointY <= maxY))
        {
            damage += 100;
        }
        if ((hitPointX + 1 >= minX && hitPointX + 1 <= maxX) &&
                     (hitpointY >= minY && hitpointY <= maxY))
        {
            damage += 75;
        }
        if ((hitPointX >= minX && hitPointX <= maxX) &&
                     (hitpointY + 1 >= minY && hitpointY + 1 <= maxY))
        {
            damage += 50;
        }
        if ((hitPointX >= minX && hitPointX <= maxX) &&
                    (hitpointY - 1 >= minY && hitpointY - 1 <= maxY))
        {
            damage += 50;
        }
        Console.WriteLine(damage + "%");
    }
}
