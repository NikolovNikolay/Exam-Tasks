using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static char[] letters = new char[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O','P', 'Q', 'R', 'S' , 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

    static void Main()
    {
        string message = Console.ReadLine();
        string cypher = Console.ReadLine();

        char cypherText = Encrypt(message, cypher);
        Console.WriteLine(cypherText);
        //Console.WriteLine((char)((0^15) + 'A'));

    }

    private static char Encrypt(string message, string cypher)
    {
        char result = '\0' ;
        var builder = new StringBuilder();

        for (int i = 0; i < cypher.Length; i++)
        {
            result = (char)(((message[i]) ^ (cypher[i])) + 'A');
        }

        return result;
    }
}
