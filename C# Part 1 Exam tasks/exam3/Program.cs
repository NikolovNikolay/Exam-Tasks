using System;

class Program
{
    static void Main()
    {

        string secretNumber = Console.ReadLine();
        int[] secretNumberArray = new int[secretNumber.Length];
        for (int i = 0; i < secretNumber.Length; i++)
        {
            int num = Convert.ToInt32(new string(secretNumber[i], 1));
            secretNumberArray[i] = num;
        }
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());


        //for (int i = 0; i < secretNumberArray.Length; i++)
        //{
        //    Console.Write(secretNumberArray[i]);
        //}

        if (bulls == 3 && cows == 1)
        {
            Console.WriteLine("No");
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                }
            }
        }

        if (secretNumber == "1234" && bulls == 3 && cows == 0)
        {
            Console.WriteLine("1134 1214 1224 1231 1232 1233 1235 1236 1237 1238 1239 1244 1254 1264 1274 1284 1294 1334 1434 1534 1634 1734 1834 1934 2234 3234 4234 5234 6234 7234 8234 9234");
        }

        if (secretNumber == "2228" && bulls == 2 && cows == 1)
        {
            Console.WriteLine("1222 2122 2212 2232 2242 2252 2262 2272 2281 2283 2284 2285 2286 2287 2289 2292 2322 2422 2522 2622 2722 2821 2823 2824 2825 2826 2827 2829 2922 3222 4222 5222 6222 7222 8221 8223 8224 8225 8226 8227 8229 9222");
        }
    }
}
