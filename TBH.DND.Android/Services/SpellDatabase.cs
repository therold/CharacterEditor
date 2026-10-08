using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Maui.Storage;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Services
{
    public class SpellDatabase : Database
    {
        public SpellDatabase() : base()
        {
            Initialize();
        }

        void Initialize()
        {
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Spells (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Name TEXT,
                                    Level INTEGER,
                                    Class INTEGER,
                                    School TEXT,
                                    CastingTime TEXT,
                                    Range TEXT,
                                    Components TEXT,
                                    Duration TEXT,
                                    Source TEXT,
                                    Description TEXT,
                                    Active INTEGER
                                );";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "SELECT COUNT(Id) FROM Spells;";
            try
            {
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count < 1)
                    Seed();
            }
            catch { }
        }

        public async Task<List<Spell>> GetActiveSpellsAsync()
        {
            var list = new List<Spell>();
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Level, Class, School, CastingTime, Range, Components, Duration, Source, Description, Active FROM Spells WHERE Active = 1 ORDER BY Level ASC, Name ASC";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Spell
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Level = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                        Class = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                        School = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        CastingTime = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Range = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        Components = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        Duration = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        Source = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                        Description = reader.IsDBNull(10) ? string.Empty : reader.GetString(10),
                        Active = !reader.IsDBNull(11) && reader.GetInt32(11) == 1
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
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Level, Class, School, CastingTime, Range, Components, Duration, Source, Description, Active FROM Spells ORDER BY Level ASC, Name ASC";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Spell
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Level = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                        Class = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                        School = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        CastingTime = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Range = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        Components = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        Duration = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        Source = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                        Description = reader.IsDBNull(10) ? string.Empty : reader.GetString(10),
                        Active = !reader.IsDBNull(11) && reader.GetInt32(11) == 1
                    });
                }
            });
            return list;
        }

        public async Task<Spell?> GetSpellAsync(int id)
        {
            return await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Level, Class, School, CastingTime, Range, Components, Duration, Source, Description, Active FROM Spells WHERE Id = $id";
                cmd.Parameters.AddWithValue("$id", id);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Spell
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Level = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                        Class = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                        School = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        CastingTime = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Range = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        Components = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        Duration = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        Source = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                        Description = reader.IsDBNull(10) ? string.Empty : reader.GetString(10),
                        Active = !reader.IsDBNull(11) && reader.GetInt32(11) == 1
                    };
                }
                return null;
            });
        }

        public async Task SaveSpellAsync(Spell s)
        {
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                if (s.Id == 0)
                {
                    cmd.CommandText = "INSERT INTO Spells (Name, Level, Class, School, CastingTime, Range, Components, Duration, Source, Description, Active) VALUES ($name, $level, $class, $school, $castingTime, $range, $components, $duration, $source, $desc, $active);";
                }
                else
                {
                    cmd.CommandText = "UPDATE Spells SET Name=$name, Level=$level, Class=$class, School=$school, CastingTime=$castingTime, Range=$range, Components=$components, Duration=$duration, Source=$source, Description=$desc, Active=$active WHERE Id=$id;";
                    cmd.Parameters.AddWithValue("$id", s.Id);
                }
                cmd.Parameters.AddWithValue("$name", s.Name ?? string.Empty);
                cmd.Parameters.AddWithValue("$level", s.Level);
                cmd.Parameters.AddWithValue("$class", s.Class);
                cmd.Parameters.AddWithValue("$school", s.School ?? string.Empty);
                cmd.Parameters.AddWithValue("$castingTime", s.CastingTime ?? string.Empty);
                cmd.Parameters.AddWithValue("$range", s.Range ?? string.Empty);
                cmd.Parameters.AddWithValue("$components", s.Components ?? string.Empty);
                cmd.Parameters.AddWithValue("$duration", s.Duration ?? string.Empty);
                cmd.Parameters.AddWithValue("$source", s.Source ?? string.Empty);
                cmd.Parameters.AddWithValue("$desc", s.Description ?? string.Empty);
                cmd.Parameters.AddWithValue("$active", s.Active ? 1 : 0);
                cmd.ExecuteNonQuery();
            });
        }

        public async Task DeleteSpellAsync(int id)
        {
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Spells WHERE Id = $id";
                cmd.Parameters.AddWithValue("$id", id);
                cmd.ExecuteNonQuery();
            });
        }

        private void Seed()
        {
            DB.Spells.PHB.Seed();
            DB.Spells.TCE.Seed();
            DB.Spells.XGE.Seed();
        }
    }
}
