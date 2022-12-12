using ConsoleTableExt;

namespace CodingTracker;

public class RecordViewer
{
    private List<SessionModel> Records { get; }

    public RecordViewer(List<SessionModel> records)
    {
        Records = records;
    }

    public void PromptView()
    {
        ViewMenu();
        int.TryParse(Console.ReadLine(), out int choice);
        switch (choice)
        {
            case 1:
                ViewAllRecords();
                break;
            case 2:
                Console.Write("Enter key: ");
                int.TryParse(Console.ReadLine(), out int key);
                ViewSpecificRecord(key);
                break;
            case 3:
                TotalTimeSpent();
                break;
            case 4:
                DateTime.TryParse(Console.ReadLine(), out DateTime dateInput);
                ViewByDate(dateInput);
                break;
            default:
                Console.WriteLine("Wrong input");
                break;
        }
    }
    private void ViewMenu()
    {
        Console.WriteLine("\nRecord Viewer");
        Console.WriteLine("What would you like to do?\n");
        Console.WriteLine("Type 1 to View All Records.");
        Console.WriteLine("Type 2 to view specific Record.");
        Console.WriteLine("Type 3 to view total time spent.");
        Console.WriteLine("Type 4 to view Record by date");
        Console.WriteLine("---------------------------------------------");
    }
    
    private void ViewAllRecords() => ConsoleTableBuilder.From(Records).ExportAndWriteLine();

    private void ViewSpecificRecord(int key)
    {
        ConsoleTableBuilder.From(Records.Where(x => x.Id == key).ToList()).ExportAndWriteLine();
    }

    private void TotalTimeSpent()
    {
        TimeSpan totalTime = Records.Aggregate(TimeSpan.Zero, (current, record) => current + record.Duration);
        var display = new List<object>() { "Total Time spent", totalTime };
        ConsoleTableBuilder.From(display).ExportAndWriteLine();
    }

    private void ViewByDate(DateTime date)
    {
        var records = Records.Where(x => x.StartTime.Date == date.Date).ToList();
        ConsoleTableBuilder.From(records).ExportAndWriteLine();
    }
}