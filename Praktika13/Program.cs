using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Praktika13
{
    internal class Program
    {
        static void Exemple01()
        {
            List<int> numbers = new List<int> { 10, 5, 8, 20, 15 };

            int secondMaxValue = numbers.OrderByDescending(x => x).Distinct().Skip(1).First();
            int secondMaxIndex = numbers.FindIndex(x => x == secondMaxValue);

            Console.WriteLine($"Position: {secondMaxIndex}, Value: {secondMaxValue}");

            numbers = numbers.Where(x => x % 2 == 0).ToList();
        }
        static void Exemple02()
        {
            List<double> doubles = new List<double> { 10.5, 15.2, 8.7, 20.1, 12.3 };

            double average = doubles.Average();
            var result = doubles.Where(x => x > average);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        static void Exemple03()
        {
            string inputFilePath = "input.txt";
            string outputFilePath = "output.txt";

            string[] lines = File.ReadAllLines(inputFilePath);
            Array.Reverse(lines);
            File.WriteAllLines(outputFilePath, lines);
        }
        class Employee
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Patronymic { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public decimal Salary { get; set; }
        }
        static void Exemple04()
        {
            string filePath = "employees.txt";
            List<Employee> employees = File.ReadAllLines(filePath)
                .Select(line => line.Split(','))
                .Select(parts => new Employee
                {
                    LastName = parts[0],
                    FirstName = parts[1],
                    Patronymic = parts[2],
                    Gender = parts[3],
                    Age = int.Parse(parts[4]),
                    Salary = decimal.Parse(parts[5])
                })
                .ToList();

            var under10k = employees.Where(e => e.Salary < 10000);
            var over10k = employees.Where(e => e.Salary >= 10000);

            foreach (var employee in under10k)
            {
                Console.WriteLine($"{employee.LastName}, {employee.FirstName}, {employee.Patronymic}, {employee.Gender}, {employee.Age}, {employee.Salary}");
            }

            foreach (var employee in over10k)
            {
                Console.WriteLine($"{employee.LastName}, {employee.FirstName}, {employee.Patronymic}, {employee.Gender}, {employee.Age}, {employee.Salary}");
            }
        }
        static void Main(string[] args)
        {
            //Exemple01();
            //Exemple02();
            //Exemple03();
            Exemple04();

            Console.ReadKey();
        }
    }
}
