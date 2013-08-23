using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 30/100  , shall try again soon
class SegmentDisplay
{

    private static int[] binary = { 1111110, 0110000, 1101101, 1111001, 0110011, 1011011, 1011111, 1110000, 1111111, 1111011, 1010101, 0101010, 0000000,
                                  };
    private static int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    static List<List<int>> list = new List<List<int>>();

    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());

        int[] numbs = new int[lines];

        for (int i = 0; i < lines; i++)
		{
            numbs[i] = int.Parse(Console.ReadLine());
            list.Add(FindNumbers(numbs[i]));
            
		}

        int count = 1;
        for (int i = 0; i < list.Count; i++)
        {
            count *= list[i].Count;
        }
        var sb = new StringBuilder();
        var result = Testing(list);
        sb.AppendLine(count.ToString());

        for (int i = result.Count - count; i < result.Count; i++)
        {
            string str = "";
            for (int j = 0; j < result[i].Count; j++)
            {
                str = str + result[i][j];
            }
            sb.AppendLine(str);
        }

        Console.WriteLine(sb.ToString().Trim());
    }

    private static  List<List<int>> Testing(List<List<int>> lists)
    {
        List<List<int>> ret = new List<List<int>>();
        ret.AddRange(from first in lists[0] select new List<int>(new int[] { first }));

        List<List<int>> inner = new List<List<int>>();
        inner.AddRange(from first in lists[0] select new List<int>(new int[] { first }));

        for (int i = 1; i < lists.Count; i++)
        {
            List<int> l = lists[i];

            var newElements =
              from first in inner
              from second in l
              select new List<int>(first.Concat<int>(new int[] { second }));

            ret.AddRange(newElements);
            inner = newElements.ToList();
        }

        return ret;
    }

    static List<int>  FindNumbers(int number)
    {
        var internalList = new List<int>();

        if ((number | binary[12]) == binary[12])
        {
            internalList.Add(numbers[0]); internalList.Add(numbers[1]); internalList.Add(numbers[2]);
            internalList.Add(numbers[3]); internalList.Add(numbers[4]); internalList.Add(numbers[5]);
            internalList.Add(numbers[6]); internalList.Add(numbers[7]); internalList.Add(numbers[8]);
            internalList.Add(numbers[9]);

        }
        else if ((number | binary[0]) == binary[0])
        {
            internalList.Add(numbers[0]);
            internalList.Add(numbers[8]);

        }
        else if ((number | binary[1]) == binary[1])
        {
            internalList.Add(numbers[0]); internalList.Add(numbers[1]); internalList.Add(numbers[3]); internalList.Add(numbers[4]); internalList.Add(numbers[7]);
            internalList.Add(numbers[8]); internalList.Add(numbers[9]);
        }
        else if ((number | binary[2]) == binary[2])
        {
            internalList.Add(numbers[2]); internalList.Add(numbers[6]); internalList.Add(numbers[8]);
        }
        else if ((number | binary[3]) == binary[3])
        {
            internalList.Add(numbers[3]); internalList.Add(numbers[8]); internalList.Add(numbers[9]);
        }
        else if ((number | binary[4]) == binary[4])
        {
            internalList.Add(numbers[4]); internalList.Add(numbers[8]); internalList.Add(numbers[9]);
        }
        else if ((number | binary[5]) == binary[5])
        {
            internalList.Add(numbers[5]); internalList.Add(numbers[8]); internalList.Add(numbers[9]);
        }
        else if ((number | binary[6]) == binary[6])
        {
            internalList.Add(numbers[6]); internalList.Add(numbers[8]);
        }
        else if ((number | binary[7]) == binary[7])
        {
            internalList.Add(numbers[0]); internalList.Add(numbers[3]); internalList.Add(numbers[8]);
            internalList.Add(numbers[9]);
        }
        else if ((number | binary[8]) == binary[8])
        {
            internalList.Add(numbers[8]);
        }
        else if ((number | binary[9]) == binary[9])
        {
            internalList.Add(numbers[8]); internalList.Add(numbers[9]);
        }
        else if ((number | binary[10]) == binary[10])
        {
            internalList.Add(numbers[2]); internalList.Add(numbers[3]); internalList.Add(numbers[5]);
            internalList.Add(numbers[6]); internalList.Add(numbers[8]); internalList.Add(numbers[9]);
        }
        else if ((number | binary[11]) == binary[11])
        {
            internalList.Add(numbers[0]); internalList.Add(numbers[8]); internalList.Add(numbers[9]);
           
        }
        

        return internalList;
    }
   
}
