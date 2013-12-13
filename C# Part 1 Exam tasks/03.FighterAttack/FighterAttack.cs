using System;

class FighterAttack
{
    static void Main()
    {
        int pX1 = int.Parse(Console.ReadLine());
        int pY1 = int.Parse(Console.ReadLine());
        int pX2 = int.Parse(Console.ReadLine());
        int pY2 = int.Parse(Console.ReadLine());
        int fX = int.Parse(Console.ReadLine());
        int fY = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int damage = 0;

        fX += d;

        if (fX >= pX1 && fX <= pX2)
        {
            if (fY <= pY1 && fY >= pY2)
            {
                damage += 100;
            }

            if (fY + 1 <= pY1 && fY + 1 >= pY2)
            {
                damage += 50;
            }

            if (fY - 1 <= pY1 && fY - 1 >= pY2)
            {
                damage += 50;
            }
        }

        if (fX + 1 >= pX1 && fX + 1 <= pX2)
        {
            if (fY <= pY1 && fY >= pY2)
            {
                damage += 75;
            }
        }

        Console.WriteLine("{0}%",damage);
    }
}
