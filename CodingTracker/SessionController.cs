using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CodingTracker;

public class SessionController
{
    public void Insert()
    {
        
    }

    public void Delete()
    {
        
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