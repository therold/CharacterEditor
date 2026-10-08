using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Services.DB.Abilities
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
                    cmd.CommandText = @"INSERT INTO Abilities (Name, Class, Race, Background, Description, Source, Active) VALUES
                                        (@Name, @Class, @Race, @Background, @Description, @Source, @Active)";

                    //cmd.CommandText = @"INSERT INTO Spells (Name, Level, Class, School, CastingTime, Range, Components, Duration, Source, Description, Active) VALUES 
                    //                    (@Name, @Level, @Class, @School, @CastingTime, @Range, @Components, @Duration, @Source, @Description, @Active)";

                    // Start real seeding of Abilities

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Blessing of the Forge");
                    cmd.Parameters.AddWithValue("@Class", "4");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "At 1st level, you gain the ability to imbue magic into a weapon or armor. At the end of a long rest, you can touch one nonmagical object that is a suit of armor or a simple or martial weapon. Until the end of your next long rest or until you die , the object becomes a magic item, granting a +1 bonus to AC if it's armor or a +1 bonus to attack and damage rolls if it 's a weapon.<br><br>Once you use this feature, you can't use it again until you finish a long rest.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Channel Divinity: Artisan's Blessing");
                    cmd.Parameters.AddWithValue("@Class", "4");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "Starting at 2nd level, you can use your Channel Divinity to create simple items.<br><br>You conduct an hour-long ritual that crafts a nonmagical item that must include some metal: a simple or martial weapon, a suit of armor, ten pieces of a munition, a set of tools, or another metal object (see chapter 5, \"Equipment,\" in the Player's Handbook for examples of these items). The creation is completed at the end of the hour, coalescing in an unoccupied space of your choice on a surface within 5 feet of you.<br><br>The thing you create can be something that is worth no more than 100 gp. As part of this ritual, you must lay out metal, which can include coins, with a value equal to the creation. The metal irretrievably coalesces and transforms into the creation at the ritual's end, magically forming even nonmetal parts of the creation.<br><br>The ritual can create a duplicate of a nonmagical item that contains metal, such as a key, if you possess the original during the ritual.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Divine Strike");
                    cmd.Parameters.AddWithValue("@Class", "4");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "At 8th level, you gain the ability to infuse your weapon strikes with the fiery power of the forge. Once on each of your turns when you hit a creature with a weapon attack, you can cause the attack to deal an extra 1d8 fire damage to the target. When you reach 14th level, the extra damage increases to 2d8.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}