namespace CodingTracker;

public static class Session
{
    public static SessionModel GetSession()
    {
        DateTime startTime = DateTime.Now;
        Console.WriteLine("Session has started. Press q to quit");
        while (Console.ReadKey().Key != ConsoleKey.Q)
        { }
        var endTime = DateTime.Now;
        return new SessionModel(startTime, endTime);
    }
}