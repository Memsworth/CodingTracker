using System.Data;
using System.Reflection;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace CodingTracker;

public static class Database
{
    public static IDbConnection CreateDB()
    {
        Console.WriteLine("creating a DB");
        var connectionString = LoadConnectionString();
        var connection = new SqliteConnection(connectionString);
        var commandString =
            "CREATE TABLE IF NOT EXISTS Sessions (  ID INTEGER NOT NULL UNIQUE,  StartTime TEXT NOT NULL,  EndTime TEXT NOT NULL,  Duration TEXT NOT NULL,  PRIMARY KEY(ID AUTOINCREMENT) )";
        connection.Execute(commandString);
        return connection;
    }

    private static string LoadConnectionString()
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var configuration = builder.Build();
        var ConnectionString = configuration.GetConnectionString("TrackerDb")!;
        return ConnectionString;
    }
}