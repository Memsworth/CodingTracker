using System.Data;
using Dapper;

namespace CodingTracker;

public class SessionController
{
    private readonly IDbConnection _dbConnection;

    public SessionController(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public void Insert(SessionModel sessionModel)
    {
        _dbConnection.Execute(
            "insert into Sessions (StartTime, EndTime, Duration) values (@StartTime, @EndTime, @Duration)",
            sessionModel);
    }

    public void Delete(int key)
    {
        try
        {
            _dbConnection.Execute("Delete from Sessions WHERE id = @Id", new {Id = key});
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public void Reset()
    {
        try
        {
            _dbConnection.Execute("Delete from Sessions");
            _dbConnection.Execute("Delete from  sqlite_sequence where name='Sessions'");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<SessionModel> Load()
    {
        return _dbConnection.Query<SessionModel>(@"select * from Sessions").ToList();
    }
    
}