using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Services.DB.Traits
{
    public static class PHB
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
                    cmd.Parameters.AddWithValue("@Name", "Darkvision");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Class", "0");
                    cmd.Parameters.AddWithValue("@Race", "1");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Description", "Accustomed to life underground, you have superior vision in dark and dim conditions. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can’t discern color in darkness, only shades of gray.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Dwarven Resilience");
                    cmd.Parameters.AddWithValue("@Class", "0");
                    cmd.Parameters.AddWithValue("@Race", "1");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You have advantage on saving throws against poison, and you have resistance against poison damage (explained in chapter 9).");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Dwarven Combat Training");
                    cmd.Parameters.AddWithValue("@Class", "0");
                    cmd.Parameters.AddWithValue("@Race", "1");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You have proficiency with the battleaxe, handaxe, throwing hammer, and warhammer.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Dwarven Tool Proficiency");
                    cmd.Parameters.AddWithValue("@Class", "0");
                    cmd.Parameters.AddWithValue("@Race", "1");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You gain proficiency with the artisan’s tools of your choice: smith’s tools, brewer’s supplies, or mason’s tools.<br><br>Chosen: mason's tools");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Stonecunning");
                    cmd.Parameters.AddWithValue("@Class", "0");
                    cmd.Parameters.AddWithValue("@Race", "1");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Whenever you make an Intelligence (History) check related to the origin of stonework, you are considered proficient in the History skill and add double your proficiency bonus to the check, instead of your normal proficiency bonus.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Dwarven Languages");
                    cmd.Parameters.AddWithValue("@Class", "0");
                    cmd.Parameters.AddWithValue("@Race", "1");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You can speak, read, and write Common and Dwarvish. Dwarvish is full of hard consonants and guttural sounds, and those characteristics spill over into whatever other language a dwarf might speak.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Dwarven Toughness");
                    cmd.Parameters.AddWithValue("@Class", "0");
                    cmd.Parameters.AddWithValue("@Race", "1");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Your hit point maximum increases by 1, and it increases by 1 every time you gain a level.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Hermit Languages");
                    cmd.Parameters.AddWithValue("@Class", "0");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "32");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You can speak Celestial.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Hermit Tool Proficiency");
                    cmd.Parameters.AddWithValue("@Class", "0");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "32");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You are proficient with the herbalism kit.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}