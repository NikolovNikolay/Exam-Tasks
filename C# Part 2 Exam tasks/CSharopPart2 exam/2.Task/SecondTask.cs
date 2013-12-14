using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    //static void Main()
    //{
    //    int numberOfWords = int.Parse(Console.ReadLine());
    //    //string[] words = new string[numberOfWords + 2];
    //    int maximalLength = int.MinValue;
        
    //    Dictionary<string, int> words = new Dictionary<string, int>();
    //    int bestLength = int.MinValue;

    //    for (int i = 0; i < numberOfWords; i++)
    //    {
    //        string currentLine = Console.ReadLine();
    //        int currentLength = currentLine.Length;
    //        int length = currentLine.Length % (numberOfWords + 1);
    //        if (currentLength > bestLength)
    //        {
    //            bestLength = currentLength;
    //        }
    //        words.Add(currentLine, length);
    //    }

    //    var sb = new StringBuilder();
    //    var result = words.OrderBy(word => word.Value).ThenByDescending(word => word.Key);
    //    //for (int i = 0; i < bestLength; i++)
    //    //{
    //        foreach (var word in result)
    //        {
    //            Console.WriteLine(word.Key);
    //           //if (i >= 0 && i < word.Key.Length)
    //           //{
    //           //    sb.Append(word.Key[i]);
    //           //}
    //        } 
    //    //}
    //}
    static void Main()
    {
        int numOfWords = int.Parse(Console.ReadLine());
        int best = int.MinValue;
        List<string> array = new List<string>();
        for (int i = 0; i < numOfWords; i++)
	    {
            array.Add(Console.ReadLine());
            int strlength = array[i].Length;

            if(strlength > best)
            {
                best = strlength;
            }
        }

        for (int i = 0; i < array.Count; i++)
        {
            int length = array[i].Length % (numOfWords + 1);
            array.Insert(length, array[i]);
            if (length < i)
                array.RemoveAt(i + 1);
            else
            {
                array.RemoveAt(i);
            }
           
            //array[length] = array[i];
            //array[i] = temp;
            
        }
       
        
        

        var sb = new StringBuilder();

        for (int symbol = 0; symbol < best; symbol++)
	    {
			for (int word = 0; word < array.Count; word++)
            {
                if (array[word] != null && symbol >= 0 && symbol < array[word].Length)
                {
                    sb.Append(array[word][symbol]);
                }
            } 
		}

        Console.WriteLine(sb);
    }
}
