using System.Runtime.InteropServices.JavaScript;
using Microsoft.Data.Sqlite;

namespace Phexor_Task_Manager.MVVM.Model;

public static class Datenbank
{
    private static SqliteConnection OpenOrCreate()
    {
        var connection = new SqliteConnection("Data Source=Task-Manager.db");
        connection.Open();
        var tabel = connection.CreateCommand();
        tabel.CommandText =
            @"CREATE TABLE IF NOT EXISTS tasks (id INTEGER PRIMARY KEY AUTOINCREMENT, title TEXT NOT NULL, description TEXT, created_at TEXT NOT NULL, due_date TEXT NOT NULL, status INTEGER NOT NULL DEFAULT 0);";
        tabel.ExecuteNonQuery();
        return connection;
    }
    
    public static List<(int id, string title, string description, DateTime created_at, DateTime due_date, bool status)> ReadTasks()
    {
        var content = new List<(int id, string title, string description, DateTime created_at, DateTime due_date, bool status)>();
        var connection = OpenOrCreate();
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM tasks;";
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                content.Add((reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetBoolean(5)));
            }
        }

        return content;
    }
    
    public static List<(int id, string title, string description, DateTime created_at, DateTime due_date, bool status)> ReadTasks(string sortVariables)
    {
        var content = new List<(int id, string title, string description, DateTime created_at, DateTime due_date, bool status)>();
        var connection = OpenOrCreate();
        var command = connection.CreateCommand();

        var sortVariable = sortVariables switch
        {
            "id" => "id",
            "title" => "title",
            "created_at" => "created_at",
            "due_date" => "due_date",
            "status" => "status",
            _ => "id"
        };
        
        command.CommandText = "SELECT * FROM tasks ORDER BY $sortVariables;";
        
        command.Parameters.AddWithValue("$sortVariables", sortVariable);
        
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                content.Add((reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetBoolean(5)));
            }
        }

        return content;
    }

    public static void AddTask(string title, string description, DateTime created_at, DateTime due_date, bool status)
    {
        var connection = OpenOrCreate();
        var command = connection.CreateCommand();
        command.CommandText = @"INSERT INTO tasks (title, description, created_at, due_date, status) VALUES ($title, $description, $created_At, $due_Date, $status);";
        
        command.Parameters.AddWithValue("$title", title);
        command.Parameters.AddWithValue("$description", description ?? string.Empty);
        command.Parameters.AddWithValue("$created_At", created_at.ToString("o"));
        command.Parameters.AddWithValue("$due_Date", due_date.ToString("o"));
        command.Parameters.AddWithValue("$status", status ? 1 : 0);

        command.ExecuteNonQuery();
    }

    public static void RemoveTask(int id)
    {
        var connection = OpenOrCreate();
        var command = connection.CreateCommand();
        command.CommandText = @"DELETE FROM tasks WHERE id = $id;";
        
        command.Parameters.AddWithValue("$id", id);
        
        command.ExecuteNonQuery();
    }

    public static void ChangeTask(int id, string title, string description, DateTime created_at, DateTime due_date, bool status)
    {
        var connection = OpenOrCreate();
        var command = connection.CreateCommand();
        command.CommandText = @"UPDATE tasks SET title = $title, description = $description, created_at = $created_at, due_date = $due_date, status = $status WHERE id = $id;";

        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$title", title);
        command.Parameters.AddWithValue("$description", description ?? string.Empty);
        command.Parameters.AddWithValue("$created_at", created_at.ToString("o"));
        command.Parameters.AddWithValue("$due_date", due_date.ToString("o"));
        command.Parameters.AddWithValue("$status", status ? 1 : 0);

        command.ExecuteNonQuery();
    }
}