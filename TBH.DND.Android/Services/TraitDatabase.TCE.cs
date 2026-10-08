using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Services.DB.Traits
{
    public static class TCE
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
                    cmd.Parameters.AddWithValue("@Name", "Eldritch Mind");
                    cmd.Parameters.AddWithValue("@Class", "256");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "You have advantage on Constitution saving throws that you make to maintain your concentration on a spell.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Eldritch Versatility");
                    cmd.Parameters.AddWithValue("@Class", "256");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "<i>4th-level warlock feature</i><br><br>Whenever you reach a level in this class that grants the Ability Score Improvement feature, you can do one of the following, representing a change of focus in your occult studies: <br><ul><li>Replace one cantrip you learned from this class’s Pact Magic feature with another cantrip from the warlock spell list.</li><li>Replace the option you chose for the Pact Boon feature with one of that feature’s other options.</li><li>If you’re 12th level or higher, replace one spell from your Mystic Arcanum feature with another warlock spell of the same level.<br><br>If this change makes you ineligible for any of your Eldritch Invocations, you must also replace them now, choosing invocations for which you qualify. ");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Cantrip Versatility");
                    cmd.Parameters.AddWithValue("@Class", "4");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "<i>4th-level cleric feature</i><br><br>Whenever you reach a level in this class that grants the Ability Score Improvement feature, you can replace one cantrip you learned from this class's Spellcasting feature with another cantrip from the cleric spell list.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}