using Microsoft.Data.Sqlite;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;

namespace PracticeApp1.Services;

public sealed class DatabaseService : IDatabaseService, IDisposable
{
    private readonly SqliteConnection connection;

    public DatabaseService(string connectionString)
    {
        this.connection = new SqliteConnection(connectionString);
    }

    public void InitializeDatabase()
    {
        this.connection.Open();
        
    }

    public void Dispose()
    {
        this.connection.Dispose();
    }

    private static void ExecuteScript(SqliteConnection connection, TextReader reader)
    {
        using var transaction = connection.BeginTransaction();

        try
        {
            int lineNumber = 1;
            string? line;

            while ((line = reader.ReadLine()) is not null)
            {
                lineNumber++;

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                try
                {
                    using var command = new SqliteCommand(line, connection, transaction);
                    _ = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                   throw new Exception($"Exception during executing an SQL command on line {lineNumber}: \"{line}\".", e);
                }
            }
            transaction.Commit();
        }
        catch(Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    private void CreateTables()
    {
        using var reader = new StringReader(Resources.CreateTables);
        ExecuteScript(this.connection, reader);
    }
}
