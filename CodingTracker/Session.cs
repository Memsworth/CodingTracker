using System.Diagnostics;

namespace CodingTracker;

public class Session
{
    public SessionState SessionState { get; private set; }

    public Session()
    {
        SessionState = SessionState.Inuse;
    }


    public SessionModel GetSession()
    {
        DateTime startTime = DateTime.Now;
        var stopWa = Stopwatch.StartNew();
        Console.WriteLine("Session has started. Press q to quit");
        while (Console.ReadKey().Key != ConsoleKey.Q)
        { }

        stopWa.Stop();
        Console.WriteLine(stopWa.Elapsed.Duration());
        var endTime = DateTime.Now;
        SessionState = SessionState.Free;
        return new SessionModel(startTime, endTime);
    }
}