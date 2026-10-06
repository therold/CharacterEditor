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
                                    Description TEXT,
                                    Source TEXT,
                                    Active INTEGER
                                );";
            cmd.ExecuteNonQuery();
            Seed();
        }

        public async Task<List<Trait>> GetActiveTraitsAsync()
        {
            var list = new List<Trait>();
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Description, Source, Active FROM Traits WHERE Active = 1";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Trait
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

        public async Task<List<Trait>> GetAllTraitsAsync()
        {
            var list = new List<Trait>();
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Description, Source, Active FROM Traits";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Trait
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

        public async Task<Trait?> GetTraitAsync(int id)
        {
            return await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Description, Source, Active FROM Traits WHERE Id = $id";
                cmd.Parameters.AddWithValue("$id", id);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Trait
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

        public async Task SaveTraitAsync(Trait t)
        {
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                if (t.Id == 0)
                {
                    cmd.CommandText = "INSERT INTO Traits (Name, Description, Source, Active) VALUES ($name, $desc, $source, $active);";
                }
                else
                {
                    cmd.CommandText = "UPDATE Traits SET Name=$name, Description=$desc, Source=$source, Active=$active WHERE Id=$id;";
                    cmd.Parameters.AddWithValue("$id", t.Id);
                }
                cmd.Parameters.AddWithValue("$name", t.Name ?? string.Empty);
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
            //DB.Traits.TCE.Seed();
            //DB.Traits.XGE.Seed();
        }
    }
}
