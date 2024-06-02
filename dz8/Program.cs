using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Task1 ----------------------------------------------------------------------------
            List<Employee> employees = new List<Employee>()
            {
                new Employee
                {
                    Salary = 500,
                    CurrentDepatrament = Departament.Sale,
                    CurrentLevel = PositionLevel.Junior
                },
                new Employee
                {
                    Salary = 1000,
                    CurrentDepatrament = Departament.Develop,
                    CurrentLevel = PositionLevel.Middle
                },
                new Employee
                {
                    Salary = 1500,
                    CurrentDepatrament = Departament.Management,
                    CurrentLevel = PositionLevel.Senior
                },
                new Employee
                {
                    Salary = 5000,
                    CurrentDepatrament = Departament.Develop,
                    CurrentLevel = PositionLevel.Junior
                },
                new Employee
                {
                    Salary = 1300,
                    CurrentDepatrament = Departament.Management,
                    CurrentLevel = PositionLevel.Junior
                },
                new Employee
                {
                    Salary = 3100,
                    CurrentDepatrament = Departament.Sale,
                    CurrentLevel = PositionLevel.Senior
                },

            };

            //расчет средней зп
            int midSalary = 0;
            employees.ForEach((e) => midSalary += e.Salary);
            midSalary /= employees.Count;
            Console.WriteLine($"Средняя зп всех отделов: {midSalary}");

            //отдел с самой высокой средней зарпалтой
            Dictionary<Departament, int> salaryData = new Dictionary<Departament, int>();
            employees.ForEach((e) =>
            {
                if (!salaryData.ContainsKey(e.CurrentDepatrament))
                {
                    salaryData.Add(e.CurrentDepatrament, 0);
                }
                salaryData[e.CurrentDepatrament] += e.Salary;
            });

            //Дeпартамент с самой высокой зп
            foreach (Departament item in salaryData.Keys.ToList())
            {
                Console.WriteLine($"Суммарная зп в отделе {item} = {salaryData[item]}");
                salaryData[item] /= employees.FindAll((e) => e.CurrentDepatrament == item).Count;
            }
            Console.WriteLine($"Дeпартамент с самой высокой зп: {salaryData.OrderByDescending((s)=>s.Value).First().Key}");

            //Работники с зп выше средней
            List<Employee> maxSalaryEmp = employees.FindAll((e) => e.Salary > midSalary);
            Console.WriteLine($"Количества раотников с зп выше средней {maxSalaryEmp.Count}");

            Console.ReadKey();

        }
    }

    public class Employee
    {
        public int Salary { get; set; }
        public Departament CurrentDepatrament { get; set; }
        public PositionLevel CurrentLevel { get; set; }

    }
    public enum Departament
    {
        Sale,
        Develop,
        Management
    }

    public enum PositionLevel
    {
        Junior,
        Middle,
        Senior
    }
}
