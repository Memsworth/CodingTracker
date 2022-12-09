using ConsoleTableExt;

namespace CodingTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var db = Database.CreateDB();
            
            var controller = new SessionController(db);
            var appEnd = false;
            var sessions = new Session();
            while (appEnd != true)
            {
                ShowMenu();
                int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 0:
                        appEnd = true;
                        break;
                    case 1:
                        ConsoleTableBuilder.From(controller.Load()).ExportAndWriteLine();
                        break;
                    case 2:
                        controller.Insert(sessions.GetSession());
                        break;
                    case 3:
                        //change this later for better error handling
                        var key = int.Parse(Console.ReadLine());
                        controller.Delete(key);
                        Console.WriteLine($"Entry: {key} deleted");
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
        private static void ShowMenu()
        {
            Console.WriteLine("\nMAIN MENU");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("Type 0 to Close Application.");
            Console.WriteLine("Type 1 to View All Records.");
            Console.WriteLine("Type 2 to Insert Record.");
            Console.WriteLine("Type 3 to Delete Record.");
            Console.WriteLine("---------------------------------------------");
        }
    }
    
}