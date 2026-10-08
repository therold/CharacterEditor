using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Maui.Storage;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Services
{
    public class TraitDatabase : Database
    {
        public TraitDatabase() : base()
        {
            Initialize();
        }

        void Initialize()
        {
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Traits (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Name TEXT,
                                    Class INTEGER,
                                    Race INTEGER,
                                    Background INTEGER,
                                    Description TEXT,
                                    Source TEXT,
                                    Active INTEGER
                                );";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "SELECT COUNT(Id) FROM Traits;";
            try
            {
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count < 1)
                    Seed();
            }
            catch { }
        }

        public async Task<List<Trait>> GetActiveTraitsAsync()
        {
            var list = new List<Trait>();
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Class, Race, Background, Description, Source, Active FROM Traits WHERE Active = 1";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Trait
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Class = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                        Race = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                        Background = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        Description = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Source = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        Active = !reader.IsDBNull(7) && reader.GetInt32(7) == 1
                    });
                }
            });
            return list;
        }

        public async Task<List<Trait>> GetAllTraitsAsync()
        {
            var list = new List<Trait>();
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Class, Race, Background, Description, Source, Active FROM Traits";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Trait
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Class = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                        Race = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                        Background = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        Description = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Source = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        Active = !reader.IsDBNull(7) && reader.GetInt32(7) == 1
                    });
                }
            });
            return list;
        }

        public async Task<Trait?> GetTraitAsync(int id)
        {
            return await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Class, Race, Background, Description, Source, Active FROM Traits WHERE Id = $id";
                cmd.Parameters.AddWithValue("$id", id);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Trait
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Class = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                        Race = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                        Background = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        Description = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Source = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        Active = !reader.IsDBNull(7) && reader.GetInt32(7) == 1
                    };
                }
                return null;
            });
        }

        public async Task SaveTraitAsync(Trait t)
        {
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                if (t.Id == 0)
                {
                    cmd.CommandText = "INSERT INTO Traits (Name, Class, Race, Background, Description, Source, Active) VALUES ($name, $class, $race, $background, $desc, $source, $active);";
                }
                else
                {
                    cmd.CommandText = "UPDATE Traits SET Name=$name, Class=$class, Race=$race, Background=$background, Description=$desc, Source=$source, Active=$active WHERE Id=$id;";
                    cmd.Parameters.AddWithValue("$id", t.Id);
                }
                cmd.Parameters.AddWithValue("$name", t.Name ?? string.Empty);
                cmd.Parameters.AddWithValue("$class", t.Class);
                cmd.Parameters.AddWithValue("$race", t.Race);
                cmd.Parameters.AddWithValue("$background", t.Background);
                cmd.Parameters.AddWithValue("$desc", t.Description ?? string.Empty);
                cmd.Parameters.AddWithValue("$source", t.Source ?? string.Empty);
                cmd.Parameters.AddWithValue("$active", t.Active ? 1 : 0);
                cmd.ExecuteNonQuery();
            });
        }

        public async Task DeleteTraitAsync(int id)
        {
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Traits WHERE Id = $id";
                cmd.Parameters.AddWithValue("$id", id);
                cmd.ExecuteNonQuery();
            });
        }

        private void Seed()
        {
            DB.Traits.PHB.Seed();
            DB.Traits.TCE.Seed();
            DB.Traits.XGE.Seed();
        }
    }
}
