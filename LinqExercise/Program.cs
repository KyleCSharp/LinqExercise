using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var sum = numbers.Sum();
            Console.WriteLine($"SUM = {sum}");
            //TODO: Print the Average of numbers
            var avg = numbers.Average();
            Console.WriteLine($"AVG = {avg}");
            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("----------ascending-----------------");
            var ascending = from num in numbers
                            orderby num ascending
                            select num;
            foreach (var num in ascending)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("----------descending-----------------");
            //TODO: Order numbers in decsending order and print to the console
            var descending = from num in numbers
                            orderby num descending
                            select num;
            foreach (var num in descending)
            {
                Console.WriteLine(num);
            }
            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("-------------greater than 6-----------");
            var order1 = from num in numbers
                         where num >6
                         select  num;
                         
            foreach (var num in order1)
            {
                Console.WriteLine(num);
            }

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("_-_-_-_only 4 _-_-_-_-_-");
            foreach (var num in descending.Take(4))
            {
                Console.WriteLine(num);
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("___change age at 4 then print in decsending_____");
            numbers[4] = 23;


            var ageNum = from num in numbers
                         orderby num descending
                         select num;
            foreach (var num in ageNum)
            {
                Console.WriteLine(num);
            }


            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending ");
            var employCorS = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person=> person.FirstName);
            foreach (Employee employee in employCorS)
            {
                Console.WriteLine(employee.FullName);
            }


            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName");

            var overTwentySix = employees.Where(emp => emp.Age > 26)
                .OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName)
                .ThenBy(emp => emp.YearsOfExperience);
            foreach (var person in overTwentySix)
            {
                Console.WriteLine($"age={person.Age} fullname={person.FullName} YOE = {person.YearsOfExperience}");
            }
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.");
            var years =employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine($"total yoe :{years.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Avg Yoe {years.Average(x=> x.YearsOfExperience)}");
            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Add an employee to the end of the list without using employees.Add");
            employees.Append(new Employee("first", "LastName", 64, 23)).ToList();
            foreach (var item in employees)
            {
                Console.WriteLine($" name= {item.FirstName} age= {item.Age}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
