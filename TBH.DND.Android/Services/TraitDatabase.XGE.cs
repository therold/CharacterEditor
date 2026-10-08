using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Services.DB.Traits
{
    public static class XGE
    {
        public static void Seed()
        {
            var db = new Database();
            using var conn = new SqliteConnection($"Data Source={db.DbPath}");
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = transaction;
                    cmd.CommandText = @"INSERT INTO Traits (Name, Class, Race, Background, Description, Source, Active) VALUES
                                        (@Name, @Class, @Race, @Background, @Description, @Source, @Active)";

                    //cmd.CommandText = @"INSERT INTO Spells (Name, Level, Class, School, CastingTime, Range, Components, Duration, Source, Description, Active) VALUES 
                    //                    (@Name, @Level, @Class, @School, @CastingTime, @Range, @Components, @Duration, @Source, @Description, @Active)";

                    // Start real seeding of traits

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Forge Domain Cleric Bonus Proficiencies");
                    cmd.Parameters.AddWithValue("@Class", "4");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "When you choose this domain at 1st level, you gain proficiency with heavy armor and smith's tools.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Soul of the Forge");
                    cmd.Parameters.AddWithValue("@Class", "4");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "Starting at 6th level, your mastery of the forge grants you special abilities:<br><ul><li>You gain resistance to fire damage.</li><li>While wearing heavy armor, you gain a +1 bonus to AC.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Saint of Forge and Fire");
                    cmd.Parameters.AddWithValue("@Class", "4");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "At 17th level, your blessed affinity with fire and metal becomes more powerful:<br><ul><li>You gain immunity to fire damage.</li><li>While wearing heavy armor, you have resistance to bludgeoning, piercing, and slashing damage from nonmagical attacks.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}