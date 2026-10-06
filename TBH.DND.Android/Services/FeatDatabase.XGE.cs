using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Services.DB.Feats
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
                    cmd.CommandText = @"INSERT INTO Feats (Name, Description, Source, Active) VALUES
                                        (@Name, @Description, @Source, @Active)";

                    //cmd.CommandText = @"INSERT INTO Spells (Name, Level, Class, School, CastingTime, Range, Components, Duration, Source, Description, Active) VALUES 
                    //                    (@Name, @Level, @Class, @School, @CastingTime, @Range, @Components, @Duration, @Source, @Description, @Active)";

                    // Start real seeding of feats

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Boutifull Luck");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Halfling</i><br><br>Your people have extraordinary luck, which you have learned to mystically lend to your companions when yousee them falter. You're not sure how you do it; you just wish it, and it happens. Surely a sign of fortune's favor!<br><br>When an ally you can see within 30 feet of you rolls a 1 on the d20 for an attack roll, an ability check, or a saving throw, you can use your reaction to let the ally reroll the die. The ally must use the new roll.<br><br> When you use this ability, you can't use your Lucky racial trait before the end of your next turn.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Dragon Fear");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Dragonborn</i><br><br>When angered, you can radiate menace. You gain the following benefits:<br><ul><li>Increase your Strength, Constitution, or Charisma score by 1 , to a maximum of 20.</li><li>Instead of exhaling destructive energy, you can expend a use of your Breath Weapon trait to roar, forcing each creature of your choice within 30 feet of you to make a Wisdom saving throw (DC 8 + your proficiency bonus + your Charisma modifier). A target automatically succeeds on the save if it can't hear or see you. On a failed save, a target becomes frightened of you for 1 minute. If the frightened target takes any damage, it can repeat the saving throw, ending the effect on itself on a success.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Dragon Hide");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Dragonborn</i><br><br>You manifest scales and claws reminiscent of your draconic ancestors. You gain the following benefits:<br><ul><li>Increase your Strength, Constitution, or Charisma score by 1, to a maximum of 20.</li><li>Your scales harden. While you aren't wearing armor, you can calculate your AC as 13 + your Dexterity modifier. You can use a shield and still gain this benefit.</li><li>You grow retractable claws from the tips of your fingers. Extending or retracting the claws requires no action. The claws are natural weapons, which you can use to make unarmed strikes. If you hit with them, you deal slashing damage equal to 1d4 + your Strength modifier, instead of the normal bludgeoning damage for an unarmed strike.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Drow High Magic");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Elf (drow)</i><br><br>You learn more of the magic typical of dark elves. You learn the detect magic spell and can cast it at will, without expending a spell slot. You also learn levitate and dispel magic, each of which you can cast once without expending a spell slot. You regain the ability to cast those two spells in this way when you finish a long rest. Charisma is your spellcasting ability for all three spells.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Dwarven Fortitude");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Dwarf</i><br><br>You have the blood of dwarf heroes flowing through your veins. You gain the following benefits:<br><ul><li>Increase your Constitution score by 1, to a maximum of 20.</li><li>Whenever you take the Dodge action in combat, you can spend one Hit Die to heal yourself. Roll the die, add your Constitution modifier, and regain a number of hit points equal to the total (minimum of 1).</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Elven Accuracy");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Elf or half-elf</i><br><br>The accuracy of elves is legendary, especially that of elf archers and spellcasters. You have uncanny aim with attacks that rely on precision rather than brute force. You gain the following benefits:<br><ul><li>Increase your Dexterity, Intelligence, Wisdom, or Charisma score by 1, to a maximum of 20.</li><li>Whenever you have advantage on an attack roll using Dexterity, Intelligence, Wisdom, or Charisma, you can reroll one of the dice once.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Fade Away");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Gnome</i><br><br>Your people are clever, with a knack for illusion magic. You have learned a magical trick for fading away when you suffer harm. You gain the following benefits:<br><ul><li>Increase your Dexterity or Intelligence score by 1, to a maximum of 20.</li><li>Immediately after you take damage, you can use a reaction to magically become invisible until the end of your next turn or until you attack, deal damage, or force someone to make a saving throw. Once you use this ability, you can't do so again until you finish a short or long rest.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Fey Teleportation");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Elf (high)</i><br><br>Your study of high elven lore has unlocked fey power that few other elves possess, except your eladrin cousins. Drawing on your fey ancestry, you can momentarily stride through the Feywild to shorten your path from one place to another. You gain the following benefits:<br><ul><li>Increase your Intelligence or Charisma score by 1, to a maximum of 20.</li><li>You learn to speak, read, and write Sylvan.</li><li>You learn the misty step spell and can cast it once without expending a spell slot. You regain the ability to cast it in this way when you finish a short or long rest. Intelligence is your spellcasting ability for this spell.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Flames of Phlegethos");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Tiefling</i><br><br>You learn to call on hellfire to serve your commands.<br><br>You gain the following benefits:<br><ul><li>Increase your Intelligence or Charisma score by 1, to a maximum of 20.</li><li>When you roll fire damage for a spell you cast, you can reroll any roll of 1 on the fire damage dice, but you must use the new roll, even if it is another 1.</li><li>Whenever you cast a spell that deals fire damage, you can cause flames to wreathe you until the end of your next turn. The flames don't harm you or your possessions, and they shed bright light out to 30 feet and dim light for an additional 30 feet. While the flames are present, any creature within 5 feet of you that hits you with a melee attack takes ld4 fire damage.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Infernal Constitution");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Tiefling</i><br><br>Fiendish blood runs strong in you, unlocking a resilience akin to that possessed by some fiends. You gain the following benefits:<br><ul><li>Increase your Constitution score by 1, to a maximum of 20.</li><li>You have resistance to cold damage and poison damage.</li><li>You have advantage on saving throws against being poisoned.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Orcish Fury");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Half-orc</i><br><br>Your inner fury burns tirelessly. You gain the following benefits:<br><ul><li>Increase your Strength or Constitution score by 1, to a maximum of 20.</li><li>When you hit with an attack using a simple or martial weapon, you can roll one of the weapon's damage dice an additional time and add it as extra damage of the weapon's damage type. Once you use this ability, you can't use it again until you finish a short or long rest.</li><li>Immediately after you use your Relentless Endurance trait, you can use your reaction to make one weapon attack.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Prodigy");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Half-elf, half-orc, or human</i><br><br>You have a knack for learning new things. You gain the following benefits:<br><ul><li>You gain one skill proficiency of your choice, one tool proficiency of your choice, and fluency in one language of your choice.</li><li>Choose one skill in which you have proficiency. You gain expertise with that skill, which means your proficiency bonus is doubled for any ability check you make with it. The skill you choose must be one that isn't already benefiting from a feature, such as Expertise, that doubles your proficiency bonus.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Second Chance");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Halfling</i><br><br>Fortune favors you when someone tries to strike you. You gain the following benefits:<br><ul><li>Increase your Dexterity, Constitution, or Charisma score by 1, to a maximum of 20.</li><li>When a creature you can see hits you with an attack roll, you can use your reaction to force that creature to reroll. Once you use this ability, you can't use it again until you roll initiative at the start of combat or until you finish a short or long rest.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Squat Nimbleness");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Dwarf or a Small race</i><br><br>You are uncommonly nimble for your race. You gain the following benefits:<br><ul><li>Increase your Strength or Dexterity score by 1, to a maximum of 20.</li><li>Increase your walking speed by 5 feet.</li><li>You gain proficiency in the Acrobatics or Athletics skill (your choice).</li><li>You have advan tage on a ny Strength (Athletics) or Dexterity (Acrobatics) check you ma ke to escape from being grappled.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Wood Elf Magic");
                    cmd.Parameters.AddWithValue("@Source", "XGE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Elf(wood)</i><br><br>You learn the magic of the primeval woods, which are revered and protected by your people. You learn one druid can trip of your choice. You also learn the <i>long strider</i> and <i>pass without trace</i> spells, each of which you can cast once without expending a spell slot. You regain the a bility to cast these two spells in this way when you finish a long rest. Wisdom is your spellcasting ability for all three spells.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}