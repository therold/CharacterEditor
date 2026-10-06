using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Services.DB.Feats
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
                    cmd.CommandText = @"INSERT INTO Feats (Name, Description, Source, Active) VALUES
                                        (@Name, @Description, @Source, @Active)";

                    //cmd.CommandText = @"INSERT INTO Spells (Name, Level, Class, School, CastingTime, Range, Components, Duration, Source, Description, Active) VALUES 
                    //                    (@Name, @Level, @Class, @School, @CastingTime, @Range, @Components, @Duration, @Source, @Description, @Active)";

                    // Start real seeding of feats
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Actor");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Skilled at mimicry and dramatics, you gain the following benefits:<br><ul><li>Increase your Charisma score by 1, to a maximum of 20.</li><li>You have an advantage on Charisma (Deception) and Charisma (Performance) checks when trying to pass yourself off as a different person.</li><li>You can mimic the speech of another person or the sounds made by other creatures. You must have heard the person speaking, or heard the creature make the sound, for at least 1 minute. A successful Wisdom (Insight) check contested by your Charisma (Deception) check allows a listener to determine that the effect is faked.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Alert");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Always on the lookout for danger, you gain the following benefits:<br><ul><li>You gain a +5 bonus to initiative.</li><li>You can't be surprised while you are conscious.</li><li>Other creatures don't gain advantage on attack rolls against you as a result of being unseen by you.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Athlete");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You have undergone extensive physical training to gain the following benefits:<br><ul><li>Increase your Strength or Dexterity score by 1, to a maximum of 20.</li><li>When you are prone, standing up uses only 5 feet of your movement.</li><li>Climbing doesn't cost you extra movement.</li><li>You can make a running long jump or a running high jump after moving only 5 feet on foot, rather than 10 feet.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Charger");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "When you use your action to Dash, you can use a bonus action to make one melee weapon attack or to shove a creature.<br><br>If you move at least 10 feet in a straight line immediately before taking this bonus action, you either gain a +5 bonus to the attack's damage roll (if you chose to make a melee attack and hit) or push the target up to 10 feet away from you (if you chose to shove and you succeed).");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Crossbow Expert");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Thanks to extensive practice with the crossbow, you gain the following benefits:<br><ul><li>You ignore the loading quality of crossbows with which you are proficient.</li><li>Being within 5 feet of a hostile creature doesn't impose disadvantage on your ranged attack rolls.</li><li>When you use the Attack action and attack with a one handed weapon, you can use a bonus action to attack with a hand crossbow you are holding.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Defensive Duelist");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "When you are wielding a finesse weapon with which you are proficient and another creature hits you with a melee attack, you can use your reaction to add your proficiency bonus to your AC for that attack, potentially causing the attack to miss you.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Dual Wielder");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You master fighting with two weapons, gaining the following benefits:<br><ul><li>You gain a +1 bonus to AC while you are wielding a separate melee weapon in each hand.</li><li>You can use two-weapon fighting even when the one handed melee weapons you are wielding aren't light.</li><li>You can draw or stow two one-handed weapons when you would normally be able to draw or stow only one.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Dungeon Delver");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Alert to the hidden traps and secret doors found in many dungeons, you gain the following benefits:<br><ul><li>You have advantage on Wisdom (Perception) and Intelligence (Investigation) checks made to detect the presence of secret doors.</li><li>You have advantage on saving throws made to avoid or resist traps.</li><li>You have resistance to the damage dealt by traps.</li><li>Traveling at a fast pace doesn't impose the normal −5 penalty on your passive Wisdom (Perception) score.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Durable");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Hardy and resilient, you gain the following benefits:<br><ul><li>Increase your Constitution score by 1, to a maximum of 20.</li><li>When you roll a Hit Die to regain hit points, the minimum number of hit points you regain from the roll equals twice your Constitution modifier (minimum of 2).</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Elemental Adept");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: The ability to cast at least one spell</i><br><br>When you gain this feat, choose one of the following damage types: acid, cold, fire, lightning, or thunder.<br><br>Spells you cast ignore resistance to damage of the chosen type. In addition, when you roll damage for a spell you cast that deals damage of that type, you can treat any 1 on a damage die as a 2.<br><br>You can select this feat multiple times. Each time you do so, you must choose a different damage type.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Grappler");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Strength 13 or higher</i><br><br>You've developed the skills necessary to hold your own in close-quarters grappling. You gain the following benefits:<br><ul><li>You have advantage on attack rolls against a creature you are grappling.</li><li>You can use your action to try to pin a creature grappled by you. To do so, make another grapple check. If you succeed, you and the creature are both restrained until the grapple ends.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Great Weapon Master");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You've learned to put the weight of a weapon to your advantage, letting its momentum empower your strikes. You gain the following benefits:<br><ul><li>On your turn, when you score a critical hit with a melee weapon or reduce a creature to 0 hit points with one, you can make one melee weapon attack as a bonus action.</li><li>Before you make a melee attack with a heavy weapon that you are proficient with, you can choose to take a -5 penalty to the attack roll. If the attack hits, you add +10 to the attack's damage.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Healer");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You are an able physician, allowing you to mend wounds quickly and get your allies back in the fight. You gain the following benefits:<br><ul><li>When you use a healer's kit to stabilize a dying creature, that creature also regains 1 hit point.</li><li>As an action, you can spend one use of a healer's kit to tend to a creature and restore 1d6 + 4 hit points to it, plus additional hit points equal to the creature's maximum number of Hit Dice. The creature can't regain hit points from this feat again until it finishes a short or long rest.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Heavily Armored");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Proficiency with medium armor</i><br><br>You have trained to master the use of heavy armor, gaining the following benefits:<ul><li>Increase your Strength score by 1, to a maximum of 20.</li><li>You gain proficiency with heavy armor.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Heavy Armor Master");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Proficiency with heavy armor</i><br><br>You can use your armor to deflect strikes that would kill others. You gain the following benefits:<br><ul><li>Increase your Strength score by 1, to a maximum of 20.</li><li>While you are wearing heavy armor, bludgeoning, piercing, and slashing damage that you take from nonmagical attacks is reduced by 3.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Inspiring Leader");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Charisma 13 or higher</i><br><br>You can spend 10 minutes inspiring your companions, shoring up their resolve to fight. When you do so, choose up to six friendly creatures (which can include yourself) within 30 feet of you who can see or hear you and who can understand you. Each creature can gain temporary hit points equal to your level + your Charisma modifier. A creature can't gain temporary hit points from this feat again until it has finished a short or long rest.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Keen Mind");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You have a mind that can track time, direction, and detail with uncanny precision. You gain the following benefits:<br><ul><li>Increase your Intelligence score by 1, to a maximum of 20.</li><li>You always know which way is north.</li><li>You always know the number of hours left before the next sunrise or sunset.</li><li>You can accurately recall anything you have seen or heard within the past month.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Lightly Armored");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You have trained to master the use of light armor, gaining the following benefits.<br><ul><li>Increase your Strength or Dexterity score by 1, to a maximum of 20.</li><li>You gain proficiency with light armor.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Linguist");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You have studied languages and codes, gaining the following benefits:<br><ul><li>Increase your Intelligence score by 1, to a maximum of 20.</li><li>You learn three languages of your choice.</li><li>You can ably create written ciphers. Others can't decipher a code you create unless you teach them, they succeed on an Intelligence check (DC equal to your Intelligence score + your proficiency bonus), or they use magic to decipher it.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Lucky");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You have inexplicable luck that seems to kick in at just the right moment.<br><br>You have 3 luck points. Whenever you make an attack roll, an ability check, or a saving throw, you can spend one luck point to roll an additional d20. You can choose to spend one of your luck points after you roll the die, but before the outcome is determined. You choose which of the d20s is used for the attack roll, ability check, or saving throw.<br><br>You can also spend one luck point when an attack roll is made against you. Roll a d20 and then choose whether the attack uses the attacker's roll or yours.<br><br>If more than one creature spends a luck point to influence the outcome of a roll, the points cancel each other out; no additional dice are rolled.<br><br>You regain your expended luck points when you finish a long rest.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Mage Slayer");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You have practiced techniques in melee combat against spellcasters, gaining the following benefits.<br><ul><li>When a creature within 5 feet of you casts a spell, you can use your reaction to make a melee weapon attack against that creature.</li><li>When you damage a creature that is concentrating on a spell, that creature has disadvantage on the saving throw it makes to maintain its concentration.</li><li>You have advantage on saving throws against spells cast by creatures within 5 feet of you.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Magic Initiate");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Choose a class: bard, cleric, druid, sorcerer, warlock, or wizard. You learn two cantrips of your choice from that class's spell list.<br><br>In addition, choose one 1st-level spell to learn from that same list. Using this feat, you can cast the spell once at its lowest level, and you must finish a long rest before you can cast it in this way again.<br><br>Your spellcasting ability for these spells depends on the class you chose: Charisma for bard, sorcerer, or warlock; Wisdom for cleric or druid; or Intelligence for wizard.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Martial Adept");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You have martial training that allows you to perform special combat maneuvers. You gain the following benefits:<br><ul><li>You learn two maneuvers of your choice from among those available to the Battle Master archetype in the fighter class. If a maneuver you use requires your target to make a saving throw to resist the maneuver's effects, the saving throw DC equals 8 + your proficiency bonus + your Strength or Dexterity modifier (your choice).</li><li>You gain one superiority die, which is a d6 (this die is added to any superiority dice you have from another source). This die is used to fuel your maneuvers. A superiority die is expended when you use it. You regain your expended superiority dice when you finish a short or long rest.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Medium Armor Master");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Proficiency with medium armor</i><br><br>You have practiced moving in medium armor to gain the following benefits:<br><ul><li>Wearing medium armor doesn't impose disadvantage on your Dexterity (Stealth) checks.</li><li>When you wear medium armor, you can add 3, rather than 2, to your AC if you have a Dexterity of 16 or higher.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Mobile");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You are exceptionally speedy and agile. You gain the following benefits:<br><ul><li>Your speed increases by 10 feet.</li><li>When you use the Dash action, difficult terrain doesn't cost you extra movement on that turn.</li><li>When you make a melee attack against a creature, you don't provoke opportunity attacks from that creature for the rest of the turn, whether you hit or not.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Moderately Armored");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Proficiency with light armor</i><br><br>You have trained to master the use of medium armor and shields, gaining the following benefits:<br><ul><li>Increase your Strength or Dexterity score by 1, to a maximum of 20.</li><li>You gain proficiency with medium armor and shields.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Mounted Combatant");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You are a dangerous foe to face while mounted. While you are mounted and aren't incapacitated, you gain the following benefits:<br><ul><li>You have advantage on melee attack rolls against any unmounted creature that is smaller than your mount.</li><li>You can force an attack targeted at your mount to target you instead.</li><li>If your mount is subjected to an effect that allows it to make Dexterity saving throw to take only half damage, it instead takes no damage if it succeeds on the saving throw, and only half damage if it fails.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Observant");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Quick to notice details of your environment, you gain the following benefits:<br><ul><li>Increase your Intelligence or Wisdom score by 1, to a maximum of 20.</li><li>If you can see a creature's mouth while it is speaking a language you understand, you can interpret what it's saying by reading its lips.</li><li>You have a +5 bonus to your passive Wisdom (Perception) and passive Intelligence (Investigation) scores.</li><ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Polearm Master");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You gain the following benefits:<br><ul><li>When you take the Attack action and attack with only a glaive, halberd, quarterstaff, or spear, you can use a bonus action to make a melee attack with the opposite end of the weapon. This attack uses the same ability modifier as the primary attack. The weapon's damage die for this attack is a d4, and it deals bludgeoning damage.</li><li>While you are wielding a glaive, halberd, pike, quarterstaff, or spear, other creatures provoke an opportunity attack from you when they enter the reach you have with that weapon.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Resilient");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Choose one ability score. You gain the following benefits:<br><ul><li>Increase the chosen ability score by 1, to a maximum of 20.</li><li>You gain proficiency in saving throws using the chosen ability.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Ritual Caster");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Intelligence or Wisdom 13 or higher</i><br><br>You have learned a number of spells that you can cast as rituals. These spells are written in a ritual book, which you must have in hand while casting one of them.<br><br>When you choose this feat, you acquire a ritual book holding two 1st-level spells of your choice. Choose one of the following classes: bard, cleric, druid, sorcerer, warlock, or wizard. You must choose your spells from that class's spell list, and the spells you choose must have the ritual tag. The class you choose also must have the ritual tag. The class you choose also determines your spellcasting ability for these spells: Charisma for bard, sorcerer, or warlock; Wisdom for cleric or druid; or Intelligence for wizard.<br><br>If you come across a spell in written form, such as a magical spell scroll or a wizard's spellbook, you might be able to add it to your ritual book. The spell must be on the spell list for the class you chose, the spell's level can be no higher than half your level (rounded up), and it must have the ritual tag. The process of copying the spell into your ritual book takes 2 hours per level of the spell, and costs 50 gp per level. The cost represents the material components you expend as you experiment with the spell to master it, as well as the fine inks you need to record it.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Savage Attacker");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Once per turn when you roll damage for a melee weapon attack, you can reroll the weapon's damage dice and use either total.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Sentinel");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You have mastered techniques to take advantage of every drop in any enemy's guard, gaining the following benefits.<br><ul><li>When you hit a creature with an opportunity attack, the creature's speed becomes 0 for the rest of the turn.</li><li>Creatures provoke opportunity attacks from you even if they take the Disengage action before leaving your reach.</li><li>When a creature makes an attack against a target other than you (and that target doesn't have this feat), you can use your reaction to make a melee weapon attack against the attacking creature.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Sharpshooter");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You have mastered ranged weapons and can make shots that others find impossible. You gain the following benefits:<br><ul><li>Attacking at long range doesn't impose disadvantage on your ranged weapon attack rolls.</li><li>Your ranged weapon attacks ignore half and three-quarters cover.</li><li>Before you make an attack with a ranged weapon that you are proficient with, you can choose to take a -5 penalty to the attack roll. If that attack hits, you add +10 to the attack's damage.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Shield Master");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You use shields not just for protection but also for offense. You gain the following benefits while you are wielding a shield:<br><ul><li>If you take the Attack action on your turn, you can use a bonus action to try to shove a creature within 5 feet of you with your shield.</li><li>If you aren't incapacitated, you can add your shield's AC bonus to any Dexterity saving throw you make against a spell or other harmful effect that targets only you.</li><li>If you are subjected to an effect that allows you to make a Dexterity saving throw to take only half damage, you can use your reaction to take no damage if you succeed on the saving throw, interposing your shield between yourself and the source of the effect.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Skilled");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You gain proficiency in any combination of three skills or tools of your choice.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Skulker");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: Dexterity 13 or higher</i><br><br>You are an expert at slinking through shadows. You gain the following benefits:<br><ul><li>You can try to hide when you are lightly obscured from the creature from which you are hiding.</li><li>When you are hidden from a creature and miss it with a ranged weapon attack, making the attack doesn't reveal your position.</li><li>Dim light doesn't impose disadvantage on your Wisdom (Perception) checks relying on sight.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Spell Sniper");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: The ability to cast at least one spell</i><br><br>You have learned techniques to enhance your attacks with certain kinds of spells, gaining the following benefits:<br><ul><li>When you cast a spell that requires you to make an attack roll, the spell's range is doubled.</li><li>Your ranged spell attacks ignore half cover and three-quarters cover.</li><li>You learn one cantrip that requires an attack roll. Choose the cantrip from the bard, cleric, druid, sorcerer, warlock, or wizard spell list. Your spellcasting ability for this cantrip depends on the spell list you chose from: Charisma for bard, sorcerer, and warlock; Wisdom for cleric or druid; or Intelligence for wizard.</li><ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Tavern Brawler");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Accustomed to rough-and-tumble fighting using whatever weapons happen to be at hand, you gain the following benefits:<br><ul><li>Increase your Strength or Constitution score by 1, to a maximum of 20.</li><li>You are proficient with improvised weapons and unarmed strikes.\r\nYour unarmed strike uses a d4 for damage.</li><li>When you hit a creature with an unarmed strike or an improvised weapon on your turn, you can use a bonus action to attempt to grapple the target.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Tough");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "Your hit point maximum increases by an amount equal to twice your level when you gain this feat.<br><br>Whenever you gain a level thereafter, your hit point maximum increases by an additional 2 hit points.");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "War Caster");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "<i>Prerequisite: The ability to cast at least one spell</i><br><br>You have practiced casting spells in the midst of combat, learning techniques that grant you the following benefits:<br><ul><li>You have advantage on Constitution saving throws that you make to maintain your concentration on a spell when you take damage.</li><li>You can perform the somatic components of spells even when you have weapons or a shield in one or both hands.</li><li>When a hostile creature's movement provokes an opportunity attack from you, you can use your reaction to cast a spell at the creature, rather than making an opportunity attack. The spell must have a casting time of 1 action and must target only that creature.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Name", "Weapon Master");
                    cmd.Parameters.AddWithValue("@Source", "PHB");
                    cmd.Parameters.AddWithValue("@Description", "You have practiced extensively with a variety of weapons, gaining the following benefits:<br><ul><li>Increase your Strength or Dexterity score by 1, to a maximum of 20.</li><li>You gain proficiency with four weapons of your choice. Each one must be a simple or a martial weapon.</li></ul>");
                    cmd.Parameters.AddWithValue("@Active", 0);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }
    }
}