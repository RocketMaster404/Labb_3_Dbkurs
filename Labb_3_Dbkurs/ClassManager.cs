using Labb_3_Dbkurs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3_Dbkurs
{
    internal class ClassManager
    {

        public static void ShowClasses()
        {
            using (var context = new Labb2ErikDbContext())
            {
                var classes = context.Classes.ToList();
                Console.WriteLine($"{"Id",-5}{"Klass",10}\n");
                foreach(var c in classes)
                {
                    Console.WriteLine($"{c.Id,-5}{c.ClassName,-10}");
                }
            }
        }

        public static void ShowStudentsInClass()
        {
            using (var context = new Labb2ErikDbContext())
            {
                int input;
                ShowClasses();
                Console.WriteLine("Ange Id för klassen du vill se: ");
                while(!int.TryParse(Console.ReadLine(),out input) || !context.Classes.Any(c => c.Id == input))
                {
                    Console.WriteLine("Du måste ange ett giltigt klass Id");
                }

                var studentInClass = context.Classes.Join(context.Students,
                    c => c.Id,
                    s => s.ClassId,
                    (c, s) => new
                    {
                        s.FirstName,
                        s.LastName,
                        c.ClassName,
                        c.Id
                    }
                    ).Where(c => c.Id == input).ToList();

               

                foreach(var s in studentInClass)
                {
                    Console.WriteLine($"{s.FirstName,-20}{s.LastName,-20}{s.ClassName}");
                }

                
            }

        }
    }
}
