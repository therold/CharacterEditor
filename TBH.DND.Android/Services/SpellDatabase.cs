using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Maui.Storage;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Services
{
    public class SpellDatabase
    {
        readonly string dbPath;

        public SpellDatabase()
        {
            var folder = FileSystem.AppDataDirectory;
            dbPath = Path.Combine(folder, "spells.db");
            Initialize();
        }

        void Initialize()
        {
            using var conn = new SqliteConnection($"Data Source={dbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Spells (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Name TEXT,
                                    Level INTEGER,
                                    Class TEXT,
                                    Description TEXT,
                                    Active INTEGER
                                );";
            cmd.ExecuteNonQuery();
        }

        public async Task<List<Spell>> GetActiveSpellsAsync()
        {
            var list = new List<Spell>();
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={dbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Level, Class, Description, Active FROM Spells WHERE Active = 1 ORDER BY Level ASC, Name ASC";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Spell
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Level = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                        Class = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Description = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        Active = !reader.IsDBNull(5) && reader.GetInt32(5) == 1
                    });
                }
            });
            return list;
        }

        public async Task<List<Spell>> GetAllSpellsAsync()
        {
            var list = new List<Spell>();
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={dbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Level, Class, Description, Active FROM Spells ORDER BY Level ASC, Name ASC";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Spell
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Level = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                        Class = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Description = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        Active = !reader.IsDBNull(5) && reader.GetInt32(5) == 1
                    });
                }
            });
            return list;
        }

        public async Task<Spell?> GetSpellAsync(int id)
        {
            return await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={dbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Level, Class, Description, Active FROM Spells WHERE Id = $id";
                cmd.Parameters.AddWithValue("$id", id);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Spell
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Level = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                        Class = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Description = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        Active = !reader.IsDBNull(5) && reader.GetInt32(5) == 1
                    };
                }
                return null;
            });
        }

        public async Task SaveSpellAsync(Spell s)
        {
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={dbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                if (s.Id == 0)
                {
                    cmd.CommandText = "INSERT INTO Spells (Name, Level, Class, Description, Active) VALUES ($name, $level, $class, $desc, $active);";
                }
                else
                {
                    cmd.CommandText = "UPDATE Spells SET Name=$name, Level=$level, Class=$class, Description=$desc, Active=$active WHERE Id=$id;";
                    cmd.Parameters.AddWithValue("$id", s.Id);
                }
                cmd.Parameters.AddWithValue("$name", s.Name ?? string.Empty);
                cmd.Parameters.AddWithValue("$level", s.Level);
                cmd.Parameters.AddWithValue("$class", s.Class ?? string.Empty);
                cmd.Parameters.AddWithValue("$desc", s.Description ?? string.Empty);
                cmd.Parameters.AddWithValue("$active", s.Active ? 1 : 0);
                cmd.ExecuteNonQuery();
            });
        }

        public async Task DeleteSpellAsync(int id)
        {
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={dbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Spells WHERE Id = $id";
                cmd.Parameters.AddWithValue("$id", id);
                cmd.ExecuteNonQuery();
            });
        }
    }
}
