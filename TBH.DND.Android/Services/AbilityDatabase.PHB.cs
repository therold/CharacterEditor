using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Services.DB.Abilities
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
                    cmd.CommandText = @"INSERT INTO Abilities (Name, Class, Race, Background, Description, Source, Active) VALUES
                                        (@Name, @Class, @Race, @Background, @Description, @Source, @Active)";

                    //cmd.CommandText = @"INSERT INTO Spells (Name, Level, Class, School, CastingTime, Range, Components, Duration, Source, Description, Active) VALUES 
                    //                    (@Name, @Level, @Class, @School, @CastingTime, @Range, @Components, @Duration, @Source, @Description, @Active)";

                    // Start real seeding of Abilities

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Channel Divinity: Turn Undead");
                    cmd.Parameters.AddWithValue("@Class", "4");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "As an action, you present your holy symbol and speak a prayer censuring the undead. Each undead that can see or hear you within 30 feet of you must make a Wisdom saving throw. If the creature fails its saving throw, it is turned for 1 minute or until it takes any damage.<br><br>A turned creature must spend its turns trying to move as far away from you as it can, and it can’t willingly move to a space within 30 feet of you. It also can’t take reactions. For its action, it can use only the Dash action or try to escape from an effect that prevents it from moving. If there’s nowhere to move, the creature can use the Dodge action.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Destroy Undead");
                    cmd.Parameters.AddWithValue("@Class", "4");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Starting at 5th level, when an undead fails its saving throw against your Turn Undead feature, the creature is instantly destroyed if its challenge rating is at or below a certain threshold, as shown in the Destroy Undead table.<br><br><table><tr><th>Cleric Level</th><th>Destroys Undead of CR...</th></tr><tr><td>5th</td><td>1/2 or lower</td></tr><tr><td>8th</td><td>1 or lower</td></tr><tr><td>11th</td><td>2 or lower</td></tr><tr><td>14th</td><td>3 or lower</td></tr><tr><td>17th</td><td>4 or lower</td></tr></table>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Divine Intervention");
                    cmd.Parameters.AddWithValue("@Class", "4");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Beginning at 10th level, you can call on your deity to intervene on your behalf when your need is great.<br><br>Imploring your deity’s aid requires you to use your action. Describe the assistance you seek, and roll percentile dice. If you roll a number equal to or lower than your cleric level, your deity intervenes. The DM chooses the nature of the intervention; the effect of any cleric spell or cleric domain spell would be appropriate.<br><br>If your deity intervenes, you can’t use this feature again for 7 days. Otherwise, you can use it again after you finish a long rest.<br><br>At 20th level, your call for intervention succeeds automatically, no roll required.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Eldritch Invocations");
                    cmd.Parameters.AddWithValue("@Class", "256");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "In your study of occult lore, you have unearthed eldritch invocations, fragments of forbidden knowledge that imbue you with an abiding magical ability.<br><br>At 2nd level, you gain two eldritch invocations of your choice. Your invocation options are detailed at the end of the class description. When you gain certain warlock levels, you gain additional invocations of your choice, as shown in the Invocations Known column of the Warlock table.<br><br>Additionally, when you gain a level in this class, you can choose one of the invocations you know and replace it with another invocation that you could learn at that level.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Pact of the Chain");
                    cmd.Parameters.AddWithValue("@Class", "256");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You learn the find familiar spell and can cast it as a ritual. The spell doesn’t count against your number of spells known.<br><br>When you cast the spell, you can choose one of the normal forms for your familiar or one of the following special forms: imp, pseudodragon, quasit, or sprite.<br><br>Additionally, when you take the Attack action, you can forgo one of your own attacks to allow your familiar to make one attack of its own.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Pact of the Blade");
                    cmd.Parameters.AddWithValue("@Class", "256");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You can use your action to create a pact weapon in your empty hand. You can choose the form that this melee weapon takes each time you create it (see chapter 5 for weapon options). You are proficient with it while you wield it. This weapon counts as magical for the purpose of overcoming resistance and immunity to nonmagical attacks and damage.<br><br>Your pact weapon disappears if it is more than 5 feet away from you for 1 minute or more. It also disappears if you use this feature again, if you dismiss the weapon (no action required), or if you die.<br><br>You can transform one magic weapon into your pact weapon by performing a special ritual while you hold the weapon. You perform the ritual over the course of 1 hour, which can be done during a short rest.<br><br>You can then dismiss the weapon, shunting it into an extradimensional space, and it appears whenever you create your pact weapon thereafter. You can’t affect an artifact or a sentient weapon in this way. The weapon ceases being your pact weapon if you die, if you perform the 1-hour ritual on a different weapon, or if you use a 1-hour ritual to break your bond to it. The weapon appears at your feet if it is in the extradimensional space when the bond breaks.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Pact of the Tome");
                    cmd.Parameters.AddWithValue("@Class", "256");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Your patron gives you a grimoire called a Book of Shadows. When you gain this feature, choose three cantrips from any class’s spell list. While the book is on your person, you can cast those cantrips at will. They don’t count against your number of cantrips known.<br><br>If you lose your Book of Shadows, you can perform a 1-hour ceremony to receive a replacement from your patron. This ceremony can be performed during a short or long rest, and it destroys the previous book. The book turns to ash when you die.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Mystic Arcanum");
                    cmd.Parameters.AddWithValue("@Class", "256");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "At 11th level, your patron bestows upon you a magical secret called an arcanum. Choose one 6th-level spell from the warlock spell list as this arcanum.<br><br>You can cast your arcanum spell once without expending a spell slot. You must finish a long rest before you can do so again.<br><br>At higher levels, you gain more warlock spells of your choice that can be cast in this way: one 7th-level spell at 13th level, one 8th-level spell at 15th level, and one 9th-level spell at 17th level. You regain all uses of your Mystic Arcanum when you finish a long rest.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Eldritch Master");
                    cmd.Parameters.AddWithValue("@Class", "256");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "At 20th level, you can draw on your inner reserve of mystical power while entreating your patron to regain expended spell slots. You can spend 1 minute entreating your patron for aid to regain all your expended spell slots from your Pact Magic feature. Once you regain spell slots with this feature, you must finish a long rest before you can do so again.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Agonizing Blast");
                    cmd.Parameters.AddWithValue("@Class", "256");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: eldritch blast cantrip</i><br><br>When you cast eldritch blast, add your Charisma modifier to the damage it deals on a hit.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Book of Ancient Secrets");
                    cmd.Parameters.AddWithValue("@Class", "256");
                    cmd.Parameters.AddWithValue("@Race", "0");
                    cmd.Parameters.AddWithValue("@Background", "0");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Pact of the Tome feature</i><br><br>You can now inscribe magical rituals in your Book of Shadows. Choose two 1st-level spells that have the ritual tag from any class’s spell list. The spells appear in the book and don’t count against the number of spells you know. With your Book of Shadows in hand, you can cast the chosen spells as rituals. You can’t cast the spells except as rituals, unless you’ve learned them by some other means. You can also cast a warlock spell you know as a ritual if it has the ritual tag.<br><br>On your adventures, you can add other ritual spells to your Book of Shadows. When you find such a spell, you can add it to the book if the spell’s level is equal to or less than half your warlock level (rounded up) and if you can spare the time to transcribe the spell. For each level of the spell, the transcription process takes 2 hours and costs 50 gp for the rare inks needed to inscribe it.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}