using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TBH.DND.Android.Services.DB.Feats
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
                    cmd.CommandText = @"INSERT INTO Feats (Name, Description, Source, Active) VALUES
                                        (@Name, @Description, @Source, @Active)";

                    //cmd.CommandText = @"INSERT INTO Spells (Name, Level, Class, School, CastingTime, Range, Components, Duration, Source, Description, Active) VALUES 
                    //                    (@Name, @Level, @Class, @School, @CastingTime, @Range, @Components, @Duration, @Source, @Description, @Active)";

                    // Start real seeding of feats

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Artificer Initiate");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "You've learned some of an artificer’s inventiveness:<br><ul><li>You learn one cantrip of your choice from the artificer spell list, and you learn one 1st-level spell of your choice from that list. Intelligence is your spellcasting ability for these spells.</li><li>You can cast this feat’s 1st-level spell without a spell slot, and you must finish a long rest before you can cast it in this way again. You can also cast the spell using any spell slots you have.</li><li>You gain proficiency with one type of artisan’s tools of your choice, and you can use that type of tool as a spellcasting focus for any spell you cast that uses Intelligence as its spellcasting ability.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Chef");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "Time spent mastering the culinary arts has paid off, granting you the following benefits:<br><ul><li>Increase your Constitution or Wisdom score by 1, to a maximum of 20.</li><li>You gain proficiency with cook’s utensils if you don’t already have it.</li><li>As part of a short rest, you can cook special food, provided you have ingredients and cook’s utensils on hand. You can prepare enough of this food for a number of creatures equal to 4 + your proficiency bonus. At the end of the short rest, any creature who eats the food and spends one or more Hit Dice to regain hit points regains an extra 1d8 hit points.</li><li>With one hour of work or when you finish a long rest, you can cook a number of treats equal to your proficiency bonus. These special treats last 8 hours after being made. A creature can use a bonus action to eat one of those treats to gain temporary hit points equal to your proficiency bonus.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Crusher");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "You are practiced in the art of crushing your enemies, granting you the following benefits:<br><ul><li>Increase your Strength or Constitution by 1, to a maximum of 20.</li><li>Once per turn, when you hit a creature with an attack that deals bludgeoning damage, you \r\ncan move it 5 feet to an unoccupied space, provided the target is no more than one size larger than you.</li><li>When you score a critical hit that deals bludgeoning damage to a creature, attack rolls against that creature are made with advantage until the start \r\nof your next turn.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Eldritch Adept");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Spellcasting or Pact Magic feature</i><br><br>Studying occult lore, you have unlocked eldritch power within yourself: you learn one Eldritch Invocation option of your choice from the warlock class. If the invocation has a prerequisite of any kind, you \r\ncan choose that invocation only if you’re a warlock who meets the prerequisite.<br><br>Whenever you gain a level, you can replace the invocation with another one from the warlock class.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Fey Touched");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Your exposure to the Feywild’s magic has changed you, granting you the following benefits:<br><ul><li>Increase your Intelligence, Wisdom, or Charisma score by 1, toa maximum of 20.</li><li>You learn the misty step spell and one 1st-level spell of your choice. The 1st-level spell must be from the divination or enchantment school of magic. You can cast each of these spells without expending a spell slot. Once you cast either of these spells in this way, you can’t cast that spell in this way again until you finish a long rest. You can also cast these spells using spell slots you have of the appropriate level. The spells’ spellcasting ability is the ability increased by this feat.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Fighting Initiate");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Proficiency with a martial weapon</i><br><br>Your martial training has helped you develop a particular style of fighting. As a result, you learn one Fighting Style option of your choice from the fighter class. If you already have a style, the one you choose must be different.<br><br>Whenever you reach a level that grants the Ability Score Improvement feature, you can replace this \r\nfeat’s fighting style with another one from the fighter class that you don’t have. ");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Gunner");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "You have a quick hand and keen eye when employing firearms, granting you the following benefits:<br><ul><li>Increase your Dexterity score by 1, to a maximum of 20.</li><li>You gain proficiency with firearms (see “Firearms” in the Dungeon Master's Guide).</li><li>You ignore the loading property of firearms.</li><li>Being within 5 feet of a hostile creature doesn’t impose disadvantage on your ranged attack rolls.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Metamagic Adept");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Spellcasting or Pact Magic feature</i><br><br>You've learned how to exert your will on your spells to alter how they function:<br><ul><li>You learn two Metamagic options of your choice from the sorcerer class. You can use only one Metamagic option on a spell when you cast it, unless the option says otherwise. Whenever you reach a level that grants the Ability Score Improvement feature, you can replace one of these Metamagic options with another one from the sorcerer class.</li><li>You gain 2 sorcery points to spend on Metamagic (these points are added to any sorcery points you have from another source but can be used only on Metamagic). You regain all spent sorcery points when you finish a long rest.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Piercer");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "You have achieved a penetrating precision in combat, granting you the following benefits:<br><ul><li>Increase your Strength or Dexterity by 1, to a maximum of 20.</li><li>Once per turn, when you hit a creature with an attack that deals piercing damage, you can reroll one of the attack’s damage dice, and you must use the new roll.</li><li>When you score a critical hit that deals piercing damage to a creature, you can roll one additional damage die when determining the extra piercing damage the target takes.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Poisoner");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "You can prepare and deliver deadly poisons, granting you the following benefits:<br><ul><li>When you make a damage roll that deals poison \r\ndamage, it ignores resistance to poison damage.</li><li>You can apply poison to a weapon or piece of ammunition as a bonus action, instead of an action.</li><li>You gain proficiency with the poisoner’s kit if you don’t already have it. With one hour of work using a poisoner’s kit and expending 50 gp worth of materials, you can create a number of doses of potent poison equal to your proficiency bonus. Once applied to a weapon or piece of ammunition, the poison retains its potency for 1 minute or until you hit with the weapon or ammunition. When a creature takes damage from the coated weapon or ammunition, that creature must succeed on a DC 14 Constitution saving throw or take 2d8 poison damage and become poisoned until the end of your next turn. </li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Shadow Touched");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "Your exposure to the Shadowfell’s magic has changed you, granting you the following benefits:<br><ul><li>Increase your Intelligence, Wisdom, or Charisma score by 1, toa maximum of 20.</li><li>You learn the invisibility spell and one 1st-level spell of your choice. The 1st-level spell must be from the illusion or necromancy school of magic. You can cast each of these spells without expending a spell slot. Once you cast either of these spells in this way, you can’t cast that spell in this way again until you finish a long rest. You can also cast these spells using spell slots you have of the appropriate level. The spells’ spellcasting ability is the ability increased by this feat.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Skill Expert");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "You have honed your proficiency with particular skills, granting you the following benefits:<br><ul><li>Increase one ability score of your choice by 1, to a maximum of 20.</li><li>You gain proficiency in one skill of your choice.</li><li>Choose one skill in which you have proficiency. You gain expertise with that skill, which means your proficiency bonus is doubled for any ability check you make with it. The skill you choose must be one that isn’t already benefiting from a feature, such as Expertise, that doubles your proficiency bonus.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Slasher");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "You've learned where to cut to have the greatest results, granting you the following benefits:<br><ul><li>Increase your Strength or Dexterity by 1, to a maximum of 20.</li><li>Once per turn when you hit a creature with an attack that deals slashing damage, you can reduce the speed of the target by 10 feet until the start of your next turn.</li><li>When you score a critical hit that deals slashing \r\ndamage to a creature, you grievously wound it. Until the start of your next turn, the target has disadvantage on all attack rolls.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Telekinetic");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "You learn to move things with your mind, granting you the following benefits:<br><ul><li>Increase your Intelligence, Wisdom, or Charisma score by 1, to a maximum of 20.</li><li>You learn the mage hand cantrip. You can cast it without verbal or somatic components, and you can make the spectral hand invisible. If you already know this spell, its range increases by 30 feet when you cast it. Its spellcasting ability is the ability increased by this feat.</li><li>As a bonus action, you can try to telekinetically shove one creature you can see within 30 feet of you. When you do so, the target must succeed on a Strength saving throw (DC 8 + your proficiency bonus + the ability modifier of the score increased by this feat) or be moved 5 feet toward you or away from you. A creature can willingly fail this save.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Telepathic");
                    cmd.Parameters.AddWithValue("@Source", "TCE");
                    cmd.Parameters.AddWithValue("@Description", "You awaken the ability to mentally connect with others, granting you the following benefits:<br><ul><li>Increase your Intelligence, Wisdom, or Charisma score by 1, to a maximum of 20.</li><li>You can speak telepathically to any creature you can see within 60 feet of you. Your telepathic utterances are in a language you know, and the creature understands you only if it knows that language. Your communication doesn’t give the creature the ability to respond to you telepathically.</li><li>You can cast the detect thoughts spell, requiring no spell slot or components, and you must finish a long rest before you can cast it this way again. Your spellcasting ability for the spell is the ability increased by this feat. If you have spell slots of 2nd level or higher, you can cast this spell with them.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}