namespace CodingTracker
{
    internal abstract class Program
    {
        static void Main(string[] args)
        {
            var db = new Database();
            
            var controller = new SessionController(db.CreateDB());
            var appEnd = false;
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
                        var viewer = new RecordViewer(controller.Load());
                        viewer.PromptView();
                        break;
                    case 2:
                        controller.Insert(Session.GetSession());
                        break;
                    case 3:
                        //change this later for better error handling
                        int.TryParse(Console.ReadLine(), out int key);
                        controller.Delete(key);
                        Console.WriteLine($"Entry: {key} deleted");
                        break;
                    case 4:
                        controller.Reset();
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
            Console.WriteLine("Type 1 to View Records.");
            Console.WriteLine("Type 2 to Insert Record.");
            Console.WriteLine("Type 3 to Delete Record.");
            Console.WriteLine("Type 4 to Reset Records.");
            Console.WriteLine("---------------------------------------------");
        }
    }
    
}