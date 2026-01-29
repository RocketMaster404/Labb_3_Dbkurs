using Labb_3_Dbkurs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3_Dbkurs
{
    internal class StudentManager
    {



        public static void SortStudentASCFirstName()
        {
            Console.Clear();
            using (var context = new Labb2ErikDbContext())
            {
                var studentsASC = context.Students.ToList().OrderBy(s => s.FirstName);
                Console.WriteLine($"{"Förnamn",-20}{"Efternamn"}\n");
                foreach (var student in studentsASC)
                {
                    Console.WriteLine($"{student.FirstName,-20}{student.LastName}");
                }
            }
        }

        public static void SortStudentDESCFirstName()
        {
            Console.Clear();
            using (var context = new Labb2ErikDbContext())
            {
                var studentsDesc = context.Students.ToList().OrderByDescending( s => s.FirstName);
                
                Console.WriteLine($"{"Förnamn",-20}{"Efternamn"}\n");
                foreach (var student in studentsDesc)
                {
                    Console.WriteLine($"{student.FirstName,-20}{student.LastName}");
                }
            }
        }

        public static void SortStudentLastNameDESC()
        {
            Console.Clear();
            using (var context = new Labb2ErikDbContext())
            {
                var studentsDesc = context.Students.ToList().OrderByDescending(s => s.LastName);

                Console.WriteLine($"{"Efternamn",-20}{"Förnamn"}\n");
                foreach (var student in studentsDesc)
                {
                    Console.WriteLine($"{student.LastName,-20}{student.FirstName}");
                }
            }
        }

        public static void SortStudentLastNameASC()
        {
            Console.Clear();
            using (var context = new Labb2ErikDbContext())
            {
                var studentsASC = context.Students.ToList().OrderBy(s => s.LastName);
                Console.WriteLine($"{"Efternamn",-20}{"Förnamn"}\n");
                foreach (var student in studentsASC)
                {
                    Console.WriteLine($"{student.LastName,-20}{student.FirstName}");
                }
            }
        }

    }
}
