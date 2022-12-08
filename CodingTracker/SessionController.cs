using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CodingTracker;

public class SessionController
{
    public void Insert(SessionModel sessionModel)
    {
        using (IDbConnection connection = new SqliteConnection(Database.LoadConnectionString()))
        {
            connection.Execute(
                "insert into Sessions (StartTime, EndTime, Duration) values (@StartTime, @EndTime, @Duration)",
                sessionModel);
        }
    }

    public void Delete(int key)
    {
        using (IDbConnection connection = new SqliteConnection(Database.LoadConnectionString()))
        {
            try
            {
                connection.Execute("Delete from Sessions WHERE id = @key", key);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }

    public void Update()
    {
        
    }

    public List<SessionModel> Load()
    {
        var list = new List<SessionModel>();

        using (IDbConnection connection = new SqliteConnection(Database.LoadConnectionString()))
        {
            var output = connection.Query<SessionModel>(@"select * from Sessions", new DynamicParameters());
            return output.ToList();
        }
    }
}