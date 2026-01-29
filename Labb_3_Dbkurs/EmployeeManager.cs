using Labb_3_Dbkurs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3_Dbkurs
{
    internal class EmployeeManager
    {

        public static void AddEmployeeWithUi()
        {
            bool emailCheck = false;
            string email = "";
            Console.WriteLine("Lägg till användare");
            Console.Write("Ange Förnamn: ");
            string firstName = Console.ReadLine();
            Console.Write("Ange efternamn: ");
            string lastName = Console.ReadLine();
            while (!emailCheck)
            {
                Console.Write("Ange e-post: ");
                email = Console.ReadLine();
                if (email.Contains("@"))
                {
                    emailCheck = true;
                }
                else
                {
                    Console.WriteLine("Din e-post måste innehålla @ tecken");
                }
            }

            AddEmployee(firstName, lastName, email);   
        }

        public static void AddEmployee(string firstName, string lastName,string email)
        {
            using (var context = new Labb2ErikDbContext())
            {
                Employee employee = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

    }
}
