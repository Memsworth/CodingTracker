namespace CodingTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database.CreateDB();
            var controller = new SessionController();
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
                        controller.Insert();
                        break;
                    case 2:
                        controller.Update();
                        break;
                    case 3:
                        controller.Delete();
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
            throw new NotImplementedException();
        }
    }
    
}