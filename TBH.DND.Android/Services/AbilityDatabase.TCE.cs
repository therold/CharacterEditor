using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Services.DB.Abilities
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
                    cmd.CommandText = @"INSERT INTO Abilities (Name, Class, Race, Background, Description, Source, Active) VALUES
                                        (@Name, @Class, @Race, @Background, @Description, @Source, @Active)";

                    //cmd.CommandText = @"INSERT INTO Spells (Name, Level, Class, School, CastingTime, Range, Components, Duration, Source, Description, Active) VALUES 
                    //                    (@Name, @Level, @Class, @School, @CastingTime, @Range, @Components, @Duration, @Source, @Description, @Active)";

                    // Start real seeding of Abilities

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Harness Divine Power");
                    cmd.Parameters.AddWithValue("@Class", "4");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "<i>2nd-level cleric feature</i><br><br>You can expend a use of your Channel Divinity to fuel your spells. As a bonus action, you touch your holy symbol, utter a prayer, and regain one expended spell slot, the level of which can be no higher than half your proficiency bonus (rounded up). The number of times you can use this feature is based on the level you've reached in this class: 2nd level, once; 6th level, twice; and 18th level, thrice. You regain all expended uses when you finish a long rest.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Blessed Strikes");
                    cmd.Parameters.AddWithValue("@Class", "4");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "<i>8th-level cleric feature, which replaces the Divine Strike or Potent Spellcasting feature</i><br><br>You are blessed with divine might in battle. When a creature takes damage from one of your cantrips or weapon attacks, you can also deal ld8 radiant damage to that creature. Once you deal this damage, you can't use this feature again until the start of your next turn.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Pact of the Talisman");
                    cmd.Parameters.AddWithValue("@Class", "256");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "Your patron gives you an amulet, a talisman that can aid the wearer when the need is great. When the wearer fails an ability check, they can add a d4 to the roll, potentially turning the roll into a success. This benefit can be used a number of times equal to your proficiency bonus, and all expended uses are restored when you finish a long rest. <br><br>If you lose the talisman, you can perform a 1-hour ceremony to receive a replacement from your patron. This ceremony can be performed during a short or long rest, and it destroys the previous amulet. The talisman turns to ash when you die. ");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}