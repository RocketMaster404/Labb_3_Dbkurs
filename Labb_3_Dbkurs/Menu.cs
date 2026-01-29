using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3_Dbkurs
{
    internal class Menu
    {
        public static bool Run { get; set; } = true;

        public static void PrintMainMenu()
        {
            Console.WriteLine("1. Hämta studenter");
            Console.WriteLine("2. Se klasser");
            Console.WriteLine("3. Lägg till Personal");
            Console.WriteLine("4. Avsluta");
            Console.Write("Ange val: ");
        }

        public static void PrintStudentSortMenu()
        {
            Console.WriteLine("Välj sorteringsordning");
            Console.WriteLine("1. Stigande - Förnamn");
            Console.WriteLine("2. Fallande - Förnamn");
            Console.WriteLine("3. Stigande - Efternamn");
            Console.WriteLine("4. Fallande Efternamn");
            Console.WriteLine("Ange val: ");
        }

        public static void StudentSortMenuChoice()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 4 )
            {
                Console.WriteLine("Du måste ange heltal mellan 1-4");
            }

            switch (input)
            {
                case 1:
                    StudentManager.SortStudentASCFirstName();
                    break;
                case 2:
                    StudentManager.SortStudentDESCFirstName();
                    break;
                case 3:
                    StudentManager.SortStudentLastNameASC();
                    break;
                case 4:
                    StudentManager.SortStudentLastNameDESC();
                    break;
            }

        }

        public static void MainMenuChoice()
        {
            int input;
            while(!int.TryParse(Console.ReadLine(),out input))
            {
                Console.WriteLine("Du måste ange heltal");
            }

            switch (input)
            {
                case 1:
                    Console.Clear();
                    PrintStudentSortMenu();
                    StudentSortMenuChoice();
                    break;
                case 2:
                    Console.Clear();
                    ClassManager.ShowStudentsInClass();
                    
                    break;
                case 3:
                    Console.Clear();
                    EmployeeManager.AddEmployeeWithUi();
                    break;
                case 4:
                    Menu.Run = false;
                    Console.WriteLine("Programmet avslutas - Tryck enter");
                    Console.ReadKey();
                    break;
            }

            
        }
    }
}
