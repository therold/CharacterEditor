using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Maui.Storage;
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
                                    Description TEXT,
                                    Source TEXT,
                                    Active INTEGER
                                );";
            cmd.ExecuteNonQuery();
            //Seed();
        }

        public async Task<List<Ability>> GetActiveAbilitiesAsync()
        {
            var list = new List<Ability>();
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Description, Source, Active FROM Abilities WHERE Active = 1";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Ability
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Source = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Active = !reader.IsDBNull(4) && reader.GetInt32(4) == 1
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
                cmd.CommandText = "SELECT Id, Name, Description, Source, Active FROM Abilities";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Ability
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Source = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Active = !reader.IsDBNull(4) && reader.GetInt32(4) == 1
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
                cmd.CommandText = "SELECT Id, Name, Description, Source, Active FROM Abilities WHERE Id = $id";
                cmd.Parameters.AddWithValue("$id", id);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Ability
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Source = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Active = !reader.IsDBNull(4) && reader.GetInt32(4) == 1
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
                    cmd.CommandText = "INSERT INTO Abilities (Name, Description, Source, Active) VALUES ($name, $desc, $source, $active);";
                }
                else
                {
                    cmd.CommandText = "UPDATE Abilities SET Name=$name, Description=$desc, Source=$source, Active=$active WHERE Id=$id;";
                    cmd.Parameters.AddWithValue("$id", f.Id);
                }
                cmd.Parameters.AddWithValue("$name", f.Name ?? string.Empty);
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
