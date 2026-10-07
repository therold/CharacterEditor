using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Maui.Storage;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Services
{
    public class CharacterDatabase : Database
    {
        public CharacterDatabase() : base()
        {
            Initialize();
        }

        void Initialize()
        {
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Characters (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Name TEXT,
                                    Race TEXT,
                                    Class TEXT,
                                    Level INTEGER,
                                    MaxHP INTEGER,
                                    TempMaxHP INTEGER,
                                    CurrentHP INTEGER,
                                    TempCurrentHP INTEGER,
                                    ArmorClass INTEGER,
                                    Initiative INTEGER,
                                    Speed INTEGER,
                                    Strength INTEGER,
                                    Dexterity INTEGER,
                                    Constitution INTEGER,
                                    Intelligence INTEGER,
                                    Wisdom INTEGER,
                                    Charisma INTEGER,
                                    StrengthSavingThrowProficient INTEGER,
                                    DexteritySavingThrowProficient INTEGER,
                                    ConstitutionSavingThrowProficient INTEGER,
                                    IntelligenceSavingThrowProficient INTEGER,
                                    WisdomSavingThrowProficient INTEGER,
                                    CharismaSavingThrowProficient INTEGER,
                                    AcrobaticsProficient INTEGER,
                                    AnimalHandlingProficient INTEGER,
                                    ArcanaProficient INTEGER,
                                    AthleticsProficient INTEGER,
                                    DeceptionProficient INTEGER,
                                    HistoryProficient INTEGER,
                                    InsightProficient INTEGER,
                                    IntimidationProficient INTEGER,
                                    InvestigationProficient INTEGER,
                                    MedicineProficient INTEGER,
                                    NatureProficient INTEGER,
                                    PerceptionProficient INTEGER,
                                    PerformanceProficient INTEGER,
                                    PersuasionProficient INTEGER,
                                    ReligionProficient INTEGER,
                                    SleightOfHandProficient INTEGER,
                                    StealthProficient INTEGER,
                                    SurvivalProficient INTEGER,
                                    SpellSlotsFirstLevel INTEGER,
                                    SpellSlotsSecondLevel INTEGER,
                                    SpellSlotsThirdLevel INTEGER,
                                    SpellSlotsFourthLevel INTEGER,
                                    SpellSlotsFifthLevel INTEGER,
                                    SpellSlotsSixthLevel INTEGER,
                                    SpellSlotsSeventhLevel INTEGER,
                                    SpellSlotsEighthLevel INTEGER,
                                    SpellSlotsNinthLevel INTEGER,
                                    SpellSlotsFirstLevelCurrent INTEGER,
                                    SpellSlotsSecondLevelCurrent INTEGER,
                                    SpellSlotsThirdLevelCurrent INTEGER,
                                    SpellSlotsFourthLevelCurrent INTEGER,
                                    SpellSlotsFifthLevelCurrent INTEGER,
                                    SpellSlotsSixthLevelCurrent INTEGER,
                                    SpellSlotsSeventhLevelCurrent INTEGER,
                                    SpellSlotsEighthLevelCurrent INTEGER,
                                    SpellSlotsNinthLevelCurrent INTEGER
                                );";
            cmd.ExecuteNonQuery();
            //Seed();
        }

        public async Task<List<Character>> GetActiveCharactersAsync()
        {
            var list = new List<Character>();
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"SELECT Id, Name, Race, Class, Level, MaxHP, TempMaxHP, CurrentHP, TempCurrentHP, ArmorClass, Initiative, Speed, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma, StrengthSavingThrowProficient, DexteritySavingThrowProficient, ConstitutionSavingThrowProficient, IntelligenceSavingThrowProficient, WisdomSavingThrowProficient, CharismaSavingThrowProficient, AcrobaticsProficient, AnimalHandlingProficient, ArcanaProficient, AthleticsProficient, DeceptionProficient, HistoryProficient, InsightProficient, IntimidationProficient, InvestigationProficient, MedicineProficient, NatureProficient, PerceptionProficient, PerformanceProficient, PersuasionProficient, ReligionProficient, SleightOfHandProficient, StealthProficient, SurvivalProficient, SpellSlotsFirstLevel, SpellSlotsSecondLevel, SpellSlotsThirdLevel, SpellSlotsFourthLevel, SpellSlotsFifthLevel, SpellSlotsSixthLevel, SpellSlotsSeventhLevel, SpellSlotsEighthLevel, SpellSlotsNinthLevel, SpellSlotsFirstLevelCurrent, SpellSlotsSecondLevelCurrent, SpellSlotsThirdLevelCurrent, SpellSlotsFourthLevelCurrent, SpellSlotsFifthLevelCurrent, SpellSlotsSixthLevelCurrent, SpellSlotsSeventhLevelCurrent, SpellSlotsEighthLevelCurrent, SpellSlotsNinthLevelCurrent FROM Characters";

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Character
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Race = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Class = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Level = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        MaxHP = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                        TempMaxHP = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                        CurrentHP = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                        TempCurrentHP = reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                        ArmorClass = reader.IsDBNull(9) ? 0 : reader.GetInt32(9),
                        Initiative = reader.IsDBNull(10) ? 0 : reader.GetInt32(10),
                        Speed = reader.IsDBNull(11) ? 0 : reader.GetInt32(11),
                        Strength = reader.IsDBNull(12) ? 0 : reader.GetInt32(12),
                        Dexterity = reader.IsDBNull(13) ? 0 : reader.GetInt32(13),
                        Constitution = reader.IsDBNull(14) ? 0 : reader.GetInt32(14),
                        Intelligence = reader.IsDBNull(15) ? 0 : reader.GetInt32(15),
                        Wisdom = reader.IsDBNull(16) ? 0 : reader.GetInt32(16),
                        Charisma = reader.IsDBNull(17) ? 0 : reader.GetInt32(17),
                        StrengthSavingThrowProficient = reader.IsDBNull(18) ? false : reader.GetInt32(18) == 1,
                        DexteritySavingThrowProficient = reader.IsDBNull(19) ? false : reader.GetInt32(19) == 1,
                        ConstitutionSavingThrowProficient = reader.IsDBNull(20) ? false : reader.GetInt32(20) == 1,
                        IntelligenceSavingThrowProficient = reader.IsDBNull(21) ? false : reader.GetInt32(21) == 1,
                        WisdomSavingThrowProficient = reader.IsDBNull(22) ? false : reader.GetInt32(22) == 1,
                        CharismaSavingThrowProficient = reader.IsDBNull(23) ? false : reader.GetInt32(23) == 1,
                        AcrobaticsProficient = reader.IsDBNull(24) ? false : reader.GetInt32(24) == 1,
                        AnimalHandlingProficient = reader.IsDBNull(25) ? false : reader.GetInt32(25) == 1,
                        ArcanaProficient = reader.IsDBNull(26) ? false : reader.GetInt32(26) == 1,
                        AthleticsProficient = reader.IsDBNull(27) ? false : reader.GetInt32(27) == 1,
                        DeceptionProficient = reader.IsDBNull(28) ? false : reader.GetInt32(28) == 1,
                        HistoryProficient = reader.IsDBNull(29) ? false : reader.GetInt32(29) == 1,
                        InsightProficient = reader.IsDBNull(30) ? false : reader.GetInt32(30) == 1,
                        IntimidationProficient = reader.IsDBNull(31) ? false : reader.GetInt32(31) == 1,
                        InvestigationProficient = reader.IsDBNull(32) ? false : reader.GetInt32(32) == 1,
                        MedicineProficient = reader.IsDBNull(33) ? false : reader.GetInt32(33) == 1,
                        NatureProficient = reader.IsDBNull(34) ? false : reader.GetInt32(34) == 1,
                        PerceptionProficient = reader.IsDBNull(35) ? false : reader.GetInt32(35) == 1,
                        PerformanceProficient = reader.IsDBNull(36) ? false : reader.GetInt32(36) == 1,
                        PersuasionProficient = reader.IsDBNull(37) ? false : reader.GetInt32(37) == 1,
                        ReligionProficient = reader.IsDBNull(38) ? false : reader.GetInt32(38) == 1,
                        SleightOfHandProficient = reader.IsDBNull(39) ? false : reader.GetInt32(39) == 1,
                        StealthProficient = reader.IsDBNull(40) ? false : reader.GetInt32(40) == 1,
                        SurvivalProficient = reader.IsDBNull(41) ? false : reader.GetInt32(41) == 1,
                        SpellSlotsFirstLevel = reader.IsDBNull(42) ? 0 : reader.GetInt32(42),
                        SpellSlotsSecondLevel = reader.IsDBNull(43) ? 0 : reader.GetInt32(43),
                        SpellSlotsThirdLevel = reader.IsDBNull(44) ? 0 : reader.GetInt32(44),
                        SpellSlotsFourthLevel = reader.IsDBNull(45) ? 0 : reader.GetInt32(45),
                        SpellSlotsFifthLevel = reader.IsDBNull(46) ? 0 : reader.GetInt32(46),
                        SpellSlotsSixthLevel = reader.IsDBNull(47) ? 0 : reader.GetInt32(47),
                        SpellSlotsSeventhLevel = reader.IsDBNull(48) ? 0 : reader.GetInt32(48),
                        SpellSlotsEighthLevel = reader.IsDBNull(49) ? 0 : reader.GetInt32(49),
                        SpellSlotsNinthLevel = reader.IsDBNull(50) ? 0 : reader.GetInt32(50),
                        SpellSlotsFirstLevelCurrent = reader.IsDBNull(51) ? 0 : reader.GetInt32(51),
                        SpellSlotsSecondLevelCurrent = reader.IsDBNull(52) ? 0 : reader.GetInt32(52),
                        SpellSlotsThirdLevelCurrent = reader.IsDBNull(53) ? 0 : reader.GetInt32(53),
                        SpellSlotsFourthLevelCurrent = reader.IsDBNull(54) ? 0 : reader.GetInt32(54),
                        SpellSlotsFifthLevelCurrent = reader.IsDBNull(55) ? 0 : reader.GetInt32(55),
                        SpellSlotsSixthLevelCurrent = reader.IsDBNull(56) ? 0 : reader.GetInt32(56),
                        SpellSlotsSeventhLevelCurrent = reader.IsDBNull(57) ? 0 : reader.GetInt32(57),
                        SpellSlotsEighthLevelCurrent = reader.IsDBNull(58) ? 0 : reader.GetInt32(58),
                        SpellSlotsNinthLevelCurrent = reader.IsDBNull(59) ? 0 : reader.GetInt32(59)
                    });
                }
            });
            return list;
        }

        public async Task<List<Character>> GetAllCharactersAsync()
        {
            var list = new List<Character>();
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Race, Class, Level, MaxHP, TempMaxHP, CurrentHP, TempCurrentHP, ArmorClass, Initiative, Speed, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma, StrengthSavingThrowProficient, DexteritySavingThrowProficient, ConstitutionSavingThrowProficient, IntelligenceSavingThrowProficient, WisdomSavingThrowProficient, CharismaSavingThrowProficient, AcrobaticsProficient, AnimalHandlingProficient, ArcanaProficient, AthleticsProficient, DeceptionProficient, HistoryProficient, InsightProficient, IntimidationProficient, InvestigationProficient, MedicineProficient, NatureProficient, PerceptionProficient, PerformanceProficient, PersuasionProficient, ReligionProficient, SleightOfHandProficient, StealthProficient, SurvivalProficient, SpellSlotsFirstLevel, SpellSlotsSecondLevel, SpellSlotsThirdLevel, SpellSlotsFourthLevel, SpellSlotsFifthLevel, SpellSlotsSixthLevel, SpellSlotsSeventhLevel, SpellSlotsEighthLevel, SpellSlotsNinthLevel, SpellSlotsFirstLevelCurrent, SpellSlotsSecondLevelCurrent, SpellSlotsThirdLevelCurrent, SpellSlotsFourthLevelCurrent, SpellSlotsFifthLevelCurrent, SpellSlotsSixthLevelCurrent, SpellSlotsSeventhLevelCurrent, SpellSlotsEighthLevelCurrent, SpellSlotsNinthLevelCurrent FROM Characters";
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Character
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Race = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Class = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Level = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        MaxHP = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                        TempMaxHP = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                        CurrentHP = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                        TempCurrentHP = reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                        ArmorClass = reader.IsDBNull(9) ? 0 : reader.GetInt32(9),
                        Initiative = reader.IsDBNull(10) ? 0 : reader.GetInt32(10),
                        Speed = reader.IsDBNull(11) ? 0 : reader.GetInt32(11),
                        Strength = reader.IsDBNull(12) ? 0 : reader.GetInt32(12),
                        Dexterity = reader.IsDBNull(13) ? 0 : reader.GetInt32(13),
                        Constitution = reader.IsDBNull(14) ? 0 : reader.GetInt32(14),
                        Intelligence = reader.IsDBNull(15) ? 0 : reader.GetInt32(15),
                        Wisdom = reader.IsDBNull(16) ? 0 : reader.GetInt32(16),
                        Charisma = reader.IsDBNull(17) ? 0 : reader.GetInt32(17),
                        StrengthSavingThrowProficient = reader.IsDBNull(18) ? false : reader.GetInt32(18) == 1,
                        DexteritySavingThrowProficient = reader.IsDBNull(19) ? false : reader.GetInt32(19) == 1,
                        ConstitutionSavingThrowProficient = reader.IsDBNull(20) ? false : reader.GetInt32(20) == 1,
                        IntelligenceSavingThrowProficient = reader.IsDBNull(21) ? false : reader.GetInt32(21) == 1,
                        WisdomSavingThrowProficient = reader.IsDBNull(22) ? false : reader.GetInt32(22) == 1,
                        CharismaSavingThrowProficient = reader.IsDBNull(23) ? false : reader.GetInt32(23) == 1,
                        AcrobaticsProficient = reader.IsDBNull(24) ? false : reader.GetInt32(24) == 1,
                        AnimalHandlingProficient = reader.IsDBNull(25) ? false : reader.GetInt32(25) == 1,
                        ArcanaProficient = reader.IsDBNull(26) ? false : reader.GetInt32(26) == 1,
                        AthleticsProficient = reader.IsDBNull(27) ? false : reader.GetInt32(27) == 1,
                        DeceptionProficient = reader.IsDBNull(28) ? false : reader.GetInt32(28) == 1,
                        HistoryProficient = reader.IsDBNull(29) ? false : reader.GetInt32(29) == 1,
                        InsightProficient = reader.IsDBNull(30) ? false : reader.GetInt32(30) == 1,
                        IntimidationProficient = reader.IsDBNull(31) ? false : reader.GetInt32(31) == 1,
                        InvestigationProficient = reader.IsDBNull(32) ? false : reader.GetInt32(32) == 1,
                        MedicineProficient = reader.IsDBNull(33) ? false : reader.GetInt32(33) == 1,
                        NatureProficient = reader.IsDBNull(34) ? false : reader.GetInt32(34) == 1,
                        PerceptionProficient = reader.IsDBNull(35) ? false : reader.GetInt32(35) == 1,
                        PerformanceProficient = reader.IsDBNull(36) ? false : reader.GetInt32(36) == 1,
                        PersuasionProficient = reader.IsDBNull(37) ? false : reader.GetInt32(37) == 1,
                        ReligionProficient = reader.IsDBNull(38) ? false : reader.GetInt32(38) == 1,
                        SleightOfHandProficient = reader.IsDBNull(39) ? false : reader.GetInt32(39) == 1,
                        StealthProficient = reader.IsDBNull(40) ? false : reader.GetInt32(40) == 1,
                        SurvivalProficient = reader.IsDBNull(41) ? false : reader.GetInt32(41) == 1,
                        SpellSlotsFirstLevel = reader.IsDBNull(42) ? 0 : reader.GetInt32(42),
                        SpellSlotsSecondLevel = reader.IsDBNull(43) ? 0 : reader.GetInt32(43),
                        SpellSlotsThirdLevel = reader.IsDBNull(44) ? 0 : reader.GetInt32(44),
                        SpellSlotsFourthLevel = reader.IsDBNull(45) ? 0 : reader.GetInt32(45),
                        SpellSlotsFifthLevel = reader.IsDBNull(46) ? 0 : reader.GetInt32(46),
                        SpellSlotsSixthLevel = reader.IsDBNull(47) ? 0 : reader.GetInt32(47),
                        SpellSlotsSeventhLevel = reader.IsDBNull(48) ? 0 : reader.GetInt32(48),
                        SpellSlotsEighthLevel = reader.IsDBNull(49) ? 0 : reader.GetInt32(49),
                        SpellSlotsNinthLevel = reader.IsDBNull(50) ? 0 : reader.GetInt32(50),
                        SpellSlotsFirstLevelCurrent = reader.IsDBNull(51) ? 0 : reader.GetInt32(51),
                        SpellSlotsSecondLevelCurrent = reader.IsDBNull(52) ? 0 : reader.GetInt32(52),
                        SpellSlotsThirdLevelCurrent = reader.IsDBNull(53) ? 0 : reader.GetInt32(53),
                        SpellSlotsFourthLevelCurrent = reader.IsDBNull(54) ? 0 : reader.GetInt32(54),
                        SpellSlotsFifthLevelCurrent = reader.IsDBNull(55) ? 0 : reader.GetInt32(55),
                        SpellSlotsSixthLevelCurrent = reader.IsDBNull(56) ? 0 : reader.GetInt32(56),
                        SpellSlotsSeventhLevelCurrent = reader.IsDBNull(57) ? 0 : reader.GetInt32(57),
                        SpellSlotsEighthLevelCurrent = reader.IsDBNull(58) ? 0 : reader.GetInt32(58),
                        SpellSlotsNinthLevelCurrent = reader.IsDBNull(59) ? 0 : reader.GetInt32(59)
                    });
                }
            });
            return list;
        }

        public async Task<Character?> GetCharacterAsync(int id)
        {
            return await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Name, Race, Class, Level, MaxHP, TempMaxHP, CurrentHP, TempCurrentHP, ArmorClass, Initiative, Speed, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma, StrengthSavingThrowProficient, DexteritySavingThrowProficient, ConstitutionSavingThrowProficient, IntelligenceSavingThrowProficient, WisdomSavingThrowProficient, CharismaSavingThrowProficient, AcrobaticsProficient, AnimalHandlingProficient, ArcanaProficient, AthleticsProficient, DeceptionProficient, HistoryProficient, InsightProficient, IntimidationProficient, InvestigationProficient, MedicineProficient, NatureProficient, PerceptionProficient, PerformanceProficient, PersuasionProficient, ReligionProficient, SleightOfHandProficient, StealthProficient, SurvivalProficient, SpellSlotsFirstLevel, SpellSlotsSecondLevel, SpellSlotsThirdLevel, SpellSlotsFourthLevel, SpellSlotsFifthLevel, SpellSlotsSixthLevel, SpellSlotsSeventhLevel, SpellSlotsEighthLevel, SpellSlotsNinthLevel, SpellSlotsFirstLevelCurrent, SpellSlotsSecondLevelCurrent, SpellSlotsThirdLevelCurrent, SpellSlotsFourthLevelCurrent, SpellSlotsFifthLevelCurrent, SpellSlotsSixthLevelCurrent, SpellSlotsSeventhLevelCurrent, SpellSlotsEighthLevelCurrent, SpellSlotsNinthLevelCurrent FROM Characters WHERE Id = $id";
                cmd.Parameters.AddWithValue("$id", id);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Character
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        Race = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Class = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Level = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        MaxHP = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                        TempMaxHP = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                        CurrentHP = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                        TempCurrentHP = reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                        ArmorClass = reader.IsDBNull(9) ? 0 : reader.GetInt32(9),
                        Initiative = reader.IsDBNull(10) ? 0 : reader.GetInt32(10),
                        Speed = reader.IsDBNull(11) ? 0 : reader.GetInt32(11),
                        Strength = reader.IsDBNull(12) ? 0 : reader.GetInt32(12),
                        Dexterity = reader.IsDBNull(13) ? 0 : reader.GetInt32(13),
                        Constitution = reader.IsDBNull(14) ? 0 : reader.GetInt32(14),
                        Intelligence = reader.IsDBNull(15) ? 0 : reader.GetInt32(15),
                        Wisdom = reader.IsDBNull(16) ? 0 : reader.GetInt32(16),
                        Charisma = reader.IsDBNull(17) ? 0 : reader.GetInt32(17),
                        StrengthSavingThrowProficient = reader.IsDBNull(18) ? false : reader.GetInt32(18) == 1,
                        DexteritySavingThrowProficient = reader.IsDBNull(19) ? false : reader.GetInt32(19) == 1,
                        ConstitutionSavingThrowProficient = reader.IsDBNull(20) ? false : reader.GetInt32(20) == 1,
                        IntelligenceSavingThrowProficient = reader.IsDBNull(21) ? false : reader.GetInt32(21) == 1,
                        WisdomSavingThrowProficient = reader.IsDBNull(22) ? false : reader.GetInt32(22) == 1,
                        CharismaSavingThrowProficient = reader.IsDBNull(23) ? false : reader.GetInt32(23) == 1,
                        AcrobaticsProficient = reader.IsDBNull(24) ? false : reader.GetInt32(24) == 1,
                        AnimalHandlingProficient = reader.IsDBNull(25) ? false : reader.GetInt32(25) == 1,
                        ArcanaProficient = reader.IsDBNull(26) ? false : reader.GetInt32(26) == 1,
                        AthleticsProficient = reader.IsDBNull(27) ? false : reader.GetInt32(27) == 1,
                        DeceptionProficient = reader.IsDBNull(28) ? false : reader.GetInt32(28) == 1,
                        HistoryProficient = reader.IsDBNull(29) ? false : reader.GetInt32(29) == 1,
                        InsightProficient = reader.IsDBNull(30) ? false : reader.GetInt32(30) == 1,
                        IntimidationProficient = reader.IsDBNull(31) ? false : reader.GetInt32(31) == 1,
                        InvestigationProficient = reader.IsDBNull(32) ? false : reader.GetInt32(32) == 1,
                        MedicineProficient = reader.IsDBNull(33) ? false : reader.GetInt32(33) == 1,
                        NatureProficient = reader.IsDBNull(34) ? false : reader.GetInt32(34) == 1,
                        PerceptionProficient = reader.IsDBNull(35) ? false : reader.GetInt32(35) == 1,
                        PerformanceProficient = reader.IsDBNull(36) ? false : reader.GetInt32(36) == 1,
                        PersuasionProficient = reader.IsDBNull(37) ? false : reader.GetInt32(37) == 1,
                        ReligionProficient = reader.IsDBNull(38) ? false : reader.GetInt32(38) == 1,
                        SleightOfHandProficient = reader.IsDBNull(39) ? false : reader.GetInt32(39) == 1,
                        StealthProficient = reader.IsDBNull(40) ? false : reader.GetInt32(40) == 1,
                        SurvivalProficient = reader.IsDBNull(41) ? false : reader.GetInt32(41) == 1,
                        SpellSlotsFirstLevel = reader.IsDBNull(42) ? 0 : reader.GetInt32(42),
                        SpellSlotsSecondLevel = reader.IsDBNull(43) ? 0 : reader.GetInt32(43),
                        SpellSlotsThirdLevel = reader.IsDBNull(44) ? 0 : reader.GetInt32(44),
                        SpellSlotsFourthLevel = reader.IsDBNull(45) ? 0 : reader.GetInt32(45),
                        SpellSlotsFifthLevel = reader.IsDBNull(46) ? 0 : reader.GetInt32(46),
                        SpellSlotsSixthLevel = reader.IsDBNull(47) ? 0 : reader.GetInt32(47),
                        SpellSlotsSeventhLevel = reader.IsDBNull(48) ? 0 : reader.GetInt32(48),
                        SpellSlotsEighthLevel = reader.IsDBNull(49) ? 0 : reader.GetInt32(49),
                        SpellSlotsNinthLevel = reader.IsDBNull(50) ? 0 : reader.GetInt32(50),
                        SpellSlotsFirstLevelCurrent = reader.IsDBNull(51) ? 0 : reader.GetInt32(51),
                        SpellSlotsSecondLevelCurrent = reader.IsDBNull(52) ? 0 : reader.GetInt32(52),
                        SpellSlotsThirdLevelCurrent = reader.IsDBNull(53) ? 0 : reader.GetInt32(53),
                        SpellSlotsFourthLevelCurrent = reader.IsDBNull(54) ? 0 : reader.GetInt32(54),
                        SpellSlotsFifthLevelCurrent = reader.IsDBNull(55) ? 0 : reader.GetInt32(55),
                        SpellSlotsSixthLevelCurrent = reader.IsDBNull(56) ? 0 : reader.GetInt32(56),
                        SpellSlotsSeventhLevelCurrent = reader.IsDBNull(57) ? 0 : reader.GetInt32(57),
                        SpellSlotsEighthLevelCurrent = reader.IsDBNull(58) ? 0 : reader.GetInt32(58),
                        SpellSlotsNinthLevelCurrent = reader.IsDBNull(59) ? 0 : reader.GetInt32(59)
                    };
                }
                return null;
            });
        }

        public async Task SaveCharacterAsync(Character c)
        {
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                if (c.Id == 0)
                {
                    cmd.CommandText = "INSERT INTO Characters (Name, Race, Class, Level, MaxHP, TempMaxHP, CurrentHP, TempCurrentHP, ArmorClass, Initiative, Speed, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma, StrengthSavingThrowProficient, DexteritySavingThrowProficient, ConstitutionSavingThrowProficient, IntelligenceSavingThrowProficient, WisdomSavingThrowProficient, CharismaSavingThrowProficient, AcrobaticsProficient, AnimalHandlingProficient, ArcanaProficient, AthleticsProficient, DeceptionProficient, HistoryProficient, InsightProficient, IntimidationProficient, InvestigationProficient, MedicineProficient, NatureProficient, PerceptionProficient, PerformanceProficient, PersuasionProficient, ReligionProficient, SleightOfHandProficient, StealthProficient, SurvivalProficient, SpellSlotsFirstLevel, SpellSlotsSecondLevel, SpellSlotsThirdLevel, SpellSlotsFourthLevel, SpellSlotsFifthLevel, SpellSlotsSixthLevel, SpellSlotsSeventhLevel, SpellSlotsEighthLevel, SpellSlotsNinthLevel, SpellSlotsFirstLevelCurrent, SpellSlotsSecondLevelCurrent, SpellSlotsThirdLevelCurrent, SpellSlotsFourthLevelCurrent, SpellSlotsFifthLevelCurrent, SpellSlotsSixthLevelCurrent, SpellSlotsSeventhLevelCurrent, SpellSlotsEighthLevelCurrent, SpellSlotsNinthLevelCurrent) VALUES ($name, $race, $class, $level, $maxHP, $tempMaxHP, $currentHP, $tempCurrentHP, $armorClass, $initiative, $speed, $strength, $dexterity, $constitution, $intelligence, $wisdom, $charisma, $strengthSavingThrowProficient, $dexteritySavingThrowProficient, $constitutionSavingThrowProficient, $intelligenceSavingThrowProficient, $wisdomSavingThrowProficient, $charismaSavingThrowProficient, $acrobaticsProficient, $animalHandlingProficient, $arcanaProficient, $athleticsProficient, $deceptionProficient, $historyProficient, $insightProficient, $intimidationProficient, $investigationProficient, $medicineProficient, $natureProficient, $perceptionProficient, $performanceProficient, $persuasionProficient, $religionProficient, $sleightOfHandProficient, $stealthProficient, $survivalProficient, $spellSlotsFirstLevel, $spellSlotsSecondLevel, $spellSlotsThirdLevel, $spellSlotsFourthLevel, $spellSlotsFifthLevel, $spellSlotsSixthLevel, $spellSlotsSeventhLevel, $spellSlotsEighthLevel, $spellSlotsNinthLevel, $spellSlotsFirstLevelCurrent, $spellSlotsSecondLevelCurrent, $spellSlotsThirdLevelCurrent, $spellSlotsFourthLevelCurrent, $spellSlotsFifthLevelCurrent, $spellSlotsSixthLevelCurrent, $spellSlotsSeventhLevelCurrent, $spellSlotsEighthLevelCurrent, $spellSlotsNinthLevelCurrent)";
                }
                else
                {
                    cmd.CommandText = "UPDATE Characters SET Name=$name, Race=$race, Class=$class, Level=$level, MaxHP=$maxHP, TempMaxHP=$tempMaxHP, CurrentHP=$currentHP, TempCurrentHP=$tempCurrentHP, ArmorClass=$armorClass, Initiative=$initiative, Speed=$speed, Strength=$strength, Dexterity=$dexterity, Constitution=$constitution, Intelligence=$intelligence, Wisdom=$wisdom, Charisma=$charisma, StrengthSavingThrowProficient=$strengthSavingThrowProficient, DexteritySavingThrowProficient=$dexteritySavingThrowProficient, ConstitutionSavingThrowProficient=$constitutionSavingThrowProficient, IntelligenceSavingThrowProficient=$intelligenceSavingThrowProficient, WisdomSavingThrowProficient=$wisdomSavingThrowProficient, CharismaSavingThrowProficient=$charismaSavingThrowProficient, AcrobaticsProficient=$acrobaticsProficient, AnimalHandlingProficient=$animalHandlingProficient, ArcanaProficient=$arcanaProficient, AthleticsProficient=$athleticsProficient, DeceptionProficient=$deceptionProficient, HistoryProficient=$historyProficient, InsightProficient=$insightProficient, IntimidationProficient=$intimidationProficient, InvestigationProficient=$investigationProficient, MedicineProficient=$medicineProficient, NatureProficient=$natureProficient, PerceptionProficient=$perceptionProficient, PerformanceProficient=$performanceProficient, PersuasionProficient=$persuasionProficient, ReligionProficient=$religionProficient, SleightOfHandProficient=$sleightOfHandProficient, StealthProficient=$stealthProficient, SurvivalProficient=$survivalProficient, SpellSlotsFirstLevel=$spellSlotsFirstLevel, SpellSlotsSecondLevel=$spellSlotsSecondLevel, SpellSlotsThirdLevel=$spellSlotsThirdLevel, SpellSlotsFourthLevel=$spellSlotsFourthLevel, SpellSlotsFifthLevel=$spellSlotsFifthLevel, SpellSlotsSixthLevel=$spellSlotsSixthLevel, SpellSlotsSeventhLevel=$spellSlotsSeventhLevel, SpellSlotsEighthLevel=$spellSlotsEighthLevel, SpellSlotsNinthLevel=$spellSlotsNinthLevel, SpellSlotsFirstLevelCurrent=$spellSlotsFirstLevelCurrent, SpellSlotsSecondLevelCurrent=$spellSlotsSecondLevelCurrent, SpellSlotsThirdLevelCurrent=$spellSlotsThirdLevelCurrent, SpellSlotsFourthLevelCurrent=$spellSlotsFourthLevelCurrent, SpellSlotsFifthLevelCurrent=$spellSlotsFifthLevelCurrent, SpellSlotsSixthLevelCurrent=$spellSlotsSixthLevelCurrent, SpellSlotsSeventhLevelCurrent=$spellSlotsSeventhLevelCurrent, SpellSlotsEighthLevelCurrent=$spellSlotsEighthLevelCurrent, SpellSlotsNinthLevelCurrent=$spellSlotsNinthLevelCurrent WHERE Id=$id;";
                    cmd.Parameters.AddWithValue("$id", c.Id);
                }

                cmd.Parameters.AddWithValue("$name", c.Name ?? string.Empty);
                cmd.Parameters.AddWithValue("$race", c.Race ?? string.Empty);
                cmd.Parameters.AddWithValue("$class", c.Class ?? string.Empty);
                cmd.Parameters.AddWithValue("$level", c.Level);
                cmd.Parameters.AddWithValue("$maxHP", c.MaxHP);
                cmd.Parameters.AddWithValue("$tempMaxHP", c.TempMaxHP);
                cmd.Parameters.AddWithValue("$currentHP", c.CurrentHP);
                cmd.Parameters.AddWithValue("$tempCurrentHP", c.TempCurrentHP);
                cmd.Parameters.AddWithValue("$armorClass", c.ArmorClass);
                cmd.Parameters.AddWithValue("$initiative", c.Initiative);
                cmd.Parameters.AddWithValue("$speed", c.Speed);
                cmd.Parameters.AddWithValue("$strength", c.Strength);
                cmd.Parameters.AddWithValue("$dexterity", c.Dexterity);
                cmd.Parameters.AddWithValue("$constitution", c.Constitution);
                cmd.Parameters.AddWithValue("$intelligence", c.Intelligence);
                cmd.Parameters.AddWithValue("$wisdom", c.Wisdom);
                cmd.Parameters.AddWithValue("$charisma", c.Charisma);
                cmd.Parameters.AddWithValue("$strengthSavingThrowProficient", c.StrengthSavingThrowProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$dexteritySavingThrowProficient", c.DexteritySavingThrowProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$constitutionSavingThrowProficient", c.ConstitutionSavingThrowProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$intelligenceSavingThrowProficient", c.IntelligenceSavingThrowProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$wisdomSavingThrowProficient", c.WisdomSavingThrowProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$charismaSavingThrowProficient", c.CharismaSavingThrowProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$acrobaticsProficient", c.AcrobaticsProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$animalHandlingProficient", c.AnimalHandlingProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$arcanaProficient", c.ArcanaProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$athleticsProficient", c.AthleticsProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$deceptionProficient", c.DeceptionProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$historyProficient", c.HistoryProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$insightProficient", c.InsightProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$intimidationProficient", c.IntimidationProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$investigationProficient", c.InvestigationProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$medicineProficient", c.MedicineProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$natureProficient", c.NatureProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$perceptionProficient", c.PerceptionProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$performanceProficient", c.PerformanceProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$persuasionProficient", c.PersuasionProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$religionProficient", c.ReligionProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$sleightOfHandProficient", c.SleightOfHandProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$stealthProficient", c.StealthProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$survivalProficient", c.SurvivalProficient ? 1 : 0);
                cmd.Parameters.AddWithValue("$spellSlotsFirstLevel", c.SpellSlotsFirstLevel);
                cmd.Parameters.AddWithValue("$spellSlotsSecondLevel", c.SpellSlotsSecondLevel);
                cmd.Parameters.AddWithValue("$spellSlotsThirdLevel", c.SpellSlotsThirdLevel);
                cmd.Parameters.AddWithValue("$spellSlotsFourthLevel", c.SpellSlotsFourthLevel);
                cmd.Parameters.AddWithValue("$spellSlotsFifthLevel", c.SpellSlotsFifthLevel);
                cmd.Parameters.AddWithValue("$spellSlotsSixthLevel", c.SpellSlotsSixthLevel);
                cmd.Parameters.AddWithValue("$spellSlotsSeventhLevel", c.SpellSlotsSeventhLevel);
                cmd.Parameters.AddWithValue("$spellSlotsEighthLevel", c.SpellSlotsEighthLevel);
                cmd.Parameters.AddWithValue("$spellSlotsNinthLevel", c.SpellSlotsNinthLevel);
                cmd.Parameters.AddWithValue("$spellSlotsFirstLevelCurrent", c.SpellSlotsFirstLevelCurrent);
                cmd.Parameters.AddWithValue("$spellSlotsSecondLevelCurrent", c.SpellSlotsSecondLevelCurrent);
                cmd.Parameters.AddWithValue("$spellSlotsThirdLevelCurrent", c.SpellSlotsThirdLevelCurrent);
                cmd.Parameters.AddWithValue("$spellSlotsFourthLevelCurrent", c.SpellSlotsFourthLevelCurrent);
                cmd.Parameters.AddWithValue("$spellSlotsFifthLevelCurrent", c.SpellSlotsFifthLevelCurrent);
                cmd.Parameters.AddWithValue("$spellSlotsSixthLevelCurrent", c.SpellSlotsSixthLevelCurrent);
                cmd.Parameters.AddWithValue("$spellSlotsSeventhLevelCurrent", c.SpellSlotsSeventhLevelCurrent);
                cmd.Parameters.AddWithValue("$spellSlotsEighthLevelCurrent", c.SpellSlotsEighthLevelCurrent);
                cmd.Parameters.AddWithValue("$spellSlotsNinthLevelCurrent", c.SpellSlotsNinthLevelCurrent);
                cmd.ExecuteScalar();
            });
        }

        public async Task DeleteCharacterAsync(int id)
        {
            await Task.Run(() =>
            {
                using var conn = new SqliteConnection($"Data Source={DbPath}");
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Characters WHERE Id = $id";
                cmd.Parameters.AddWithValue("$id", id);
                cmd.ExecuteNonQuery();
            });
        }
    }
}
