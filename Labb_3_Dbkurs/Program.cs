namespace Labb_3_Dbkurs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (Menu.Run)
            {
                Menu.PrintMainMenu();
                Menu.MainMenuChoice();
                if (Menu.Run)
                {
                    Console.WriteLine("Tryck enter får att återgå till meny");
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }
    }
}
