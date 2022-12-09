namespace CodingTracker;

public class SessionModel 
{
    public int Id { get; }
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
    
    public TimeSpan Duration => EndTime - StartTime;

    public SessionModel()
    {
        
    }
    public SessionModel(int id, DateTime startTime, DateTime endTime) : this(startTime, endTime)
    {
        Id = id;
    }
    public SessionModel(DateTime startTime, DateTime endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }

}