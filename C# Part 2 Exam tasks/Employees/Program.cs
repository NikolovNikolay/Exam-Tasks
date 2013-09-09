using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using System.Collections;

class Program
{
    static void Main()
    {
        int pos = int.Parse(Console.ReadLine());
        Dictionary<string, int> positions = new Dictionary<string, int>();

        for (int i = 0; i < pos; i++)
        {
            string[] line = Console.ReadLine().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            if (!positions.ContainsKey(line[0]))
            {
                positions.Add(line[0], int.Parse(line[1]));
            }
        }

        int employees = int.Parse(Console.ReadLine());
        List<Employee> workers = new List<Employee>(employees);

        for (int i = 0; i < employees; i++)
        {
            string[] namePosition = Console.ReadLine().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            string[] names = namePosition[0].Split();
            string firstName = names[0];
            string secondName = names[1];
            string position = namePosition[1];
            Employee current = new Employee();
            current.FirstName = firstName;
            current.LastName = secondName;
            current.Position = position;
            current.Rank = positions[position];
            workers.Add(current);
        }

        var orderedEmps = workers.OrderByDescending(em => em.Rank).ThenBy(em => em.LastName).ThenBy(em => em.FirstName);
        foreach (var employee in orderedEmps)
        {
            Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
        }
    }
}

class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Rank { get; set; }
    public string Position { get; set; }
}