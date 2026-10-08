using Microsoft.Data.Sqlite;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Services
{
    public class AbilityDatabase : Database
    {
        public AbilityDatabase() : base()
        {
            Initialize();
        }

        void Initialize()
        {
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Abilities (
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

            cmd.CommandText = "SELECT COUNT(Id) FROM Abilities;";
            try
            {
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count < 1)
                    Seed();
            }
            catch { }
        }

        public async Task<List<Ability>> GetActiveAbilitiesAsync()
        {
            var list = new List<Ability>();
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Class, Race, Background, Description, Source, Active FROM Abilities WHERE Active = 1";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Ability
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

        public async Task<List<Ability>> GetAllAbilitiesAsync()
        {
            var list = new List<Ability>();
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Class, Race, Background, Description, Source, Active FROM Abilities";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Ability
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

        public async Task<Ability?> GetAbilityAsync(int id)
        {
            return await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Class, Race, Background, Description, Source, Active FROM Abilities WHERE Id = $id";
                cmd.Parameters.AddWithValue("$id", id);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Ability
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

        public async Task SaveAbilityAsync(Ability f)
        {
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                if (f.Id == 0)
                {
                    cmd.CommandText = "INSERT INTO Abilities (Name, Class, Race, Background, Description, Source, Active) VALUES ($name, $desc, $source, $active);";
                }
                else
                {
                    cmd.CommandText = "UPDATE Abilities SET Name=$name, Class=$class, Race=$race, Background=$background, Description=$desc, Source=$source, Active=$active WHERE Id=$id;";
                    cmd.Parameters.AddWithValue("$id", f.Id);
                }
                cmd.Parameters.AddWithValue("$name", f.Name ?? string.Empty);
                cmd.Parameters.AddWithValue("$class", f.Class);
                cmd.Parameters.AddWithValue("$race", f.Race);
                cmd.Parameters.AddWithValue("$background", f.Background);
                cmd.Parameters.AddWithValue("$desc", f.Description ?? string.Empty);
                cmd.Parameters.AddWithValue("$source", f.Source ?? string.Empty);
                cmd.Parameters.AddWithValue("$active", f.Active ? 1 : 0);
                cmd.ExecuteNonQuery();
            });
        }

        public async Task DeleteAbilityAsync(int id)
        {
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Abilities WHERE Id = $id";
                cmd.Parameters.AddWithValue("$id", id);
                cmd.ExecuteNonQuery();
            });
        }

        private void Seed()
        {
            DB.Abilities.PHB.Seed();
            DB.Abilities.TCE.Seed();
            DB.Abilities.XGE.Seed();
        }
    }
}
