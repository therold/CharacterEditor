using System;
using System.Collections.Generic;
using System.Text;

namespace TBH.DND.Android.Models
{
    public class Character : BaseModel
    {
        public Character()
        {
            //Id = 0;
            //Name = "Thorin";
            //Race = "Hill Dwarf";
            //Class = "Forge Cleric";

            //Level = 7;
            //MaxHP = 81;
            //TempMaxHP = 0;
            //CurrentHP = 81;
            //TempCurrentHP = 0;
            //ArmorClass = 19;
            //Initiative = 1;
            //Speed = 25;

            //Strength = 10;
            //Dexterity = 12;
            //Constitution = 18;
            //Intelligence = 11;
            //Wisdom = 16;
            //Charisma = 8;

            //ConstitutionSavingThrowProficient = true;
            //WisdomSavingThrowProficient = true;
            //CharismaSavingThrowProficient = true;

            //HistoryProficient = true;
            //InsightProficient = true;
            //MedicineProficient = true;
            //ReligionProficient = true;

            //SpellSlotsFirstLevel = 4;
            //SpellSlotsSecondLevel = 3;
            //SpellSlotsThirdLevel = 3;
            //SpellSlotsFourthLevel = 1;
            
            //SpellSlotsFirstLevelCurrent = SpellSlotsFirstLevel;
            //SpellSlotsSecondLevelCurrent = SpellSlotsSecondLevel;
            //SpellSlotsThirdLevelCurrent = SpellSlotsThirdLevel;
            //SpellSlotsFourthLevelCurrent = SpellSlotsFourthLevel;
            //SpellSlotsFifthLevelCurrent = SpellSlotsFifthLevel;
            //SpellSlotsSixthLevelCurrent = SpellSlotsSixthLevel;
            //SpellSlotsSeventhLevelCurrent = SpellSlotsSeventhLevel;
            //SpellSlotsEighthLevelCurrent = SpellSlotsEighthLevel;
        }
        public int Id { get; set; }
        private string name = string.Empty;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        private string race = string.Empty;
        public string Race
        {
            get => race;
            set
            {
                SetProperty(ref race, value);
                OnPropertyChanged(nameof(Tagline));
            }

        }
        private string @class = string.Empty;
        public string Class
        {
            get => @class;
            set
            {
                SetProperty(ref @class, value);
                OnPropertyChanged(nameof(Tagline));
            }
        }
        private int level;
        public int Level
        {
            get => level;
            set 
            {
                SetProperty(ref level, value);
                OnPropertyChanged(nameof(Tagline));
                OnPropertyChanged(nameof(ProficiencyBonus));
                OnPropertyChanged(nameof(PassivePerception));
            }
        }
        public string Tagline => $"Level {Level} {Race} {Class}";
        private int maxHP;
        public int MaxHP 
        {
            get => maxHP;
            set
            {
                SetProperty(ref maxHP, value);
                OnPropertyChanged(nameof(TotalMaxHP));
            }
        }
        private int tempMaxHP;
        public int TempMaxHP 
        {
            get => tempMaxHP;
            set 
            { 
                SetProperty(ref tempMaxHP, value);
                OnPropertyChanged(nameof(TotalMaxHP));
            }
        }
        public int TotalMaxHP => MaxHP + TempMaxHP;
        private int currentHP;
        public int CurrentHP
        {
            get => currentHP;
            set 
            { 
                SetProperty(ref currentHP, value);
                OnPropertyChanged(nameof(TotalCurrentHP));
            }
        }
        private int tempCurrentHP;
        public int TempCurrentHP
        {
            get => tempCurrentHP;
            set 
            { 
                SetProperty(ref tempCurrentHP, value);
                OnPropertyChanged(nameof(TotalCurrentHP));
            }
        }
        public int TotalCurrentHP => CurrentHP + TempCurrentHP;
        private int armorClass;
        public int ArmorClass 
        { 
            get => armorClass;
            set => SetProperty(ref armorClass, value);
        }
        private int initiative;
        public int Initiative 
        { 
            get => initiative;
            set => SetProperty(ref initiative, value);
        }
        private int speed;
        public int Speed 
        { 
            get => speed;
            set => SetProperty(ref speed, value);
        }
        public  int ProficiencyBonus => 2 + (Level - 1) / 4; // Proficiency bonus increases at levels 5, 9, 13, and 17
        public int PassivePerception => 10 + WisdomModifier + (WisdomSavingThrowProficient ? ProficiencyBonus : 0);
        public int SpellSaveDC => 8 + ProficiencyBonus + WisdomModifier; // Assuming spellcasting ability is Wisdom

        // Ability scores
        private int strength;
        public int Strength 
        { 
            get => strength;
            set 
            { 
                SetProperty(ref strength, value);
                OnPropertyChanged(nameof(StrengthModifier));
                OnPropertyChanged(nameof(StrengthSavingThrow));
                OnPropertyChanged(nameof(Athletics));
            }
        }
        private int dexterity;
        public int Dexterity 
        { 
            get => dexterity;
            set 
            { 
                SetProperty(ref dexterity, value);
                OnPropertyChanged(nameof(DexterityModifier));
                OnPropertyChanged(nameof(DexteritySavingThrow));
                OnPropertyChanged(nameof(Acrobatics));
                OnPropertyChanged(nameof(SleightOfHand));
                OnPropertyChanged(nameof(Stealth));
            }
        }
        private int constitution;
        public int Constitution 
        { 
            get => constitution;
            set 
            { 
                SetProperty(ref constitution, value);
                OnPropertyChanged(nameof(ConstitutionModifier));
                OnPropertyChanged(nameof(ConstitutionSavingThrow));
            }
        }
        private int intelligence;
        public int Intelligence 
        { 
            get => intelligence;
            set 
            { 
                SetProperty(ref intelligence, value);
                OnPropertyChanged(nameof(IntelligenceModifier));
                OnPropertyChanged(nameof(IntelligenceSavingThrow));
                OnPropertyChanged(nameof(Arcana));
                OnPropertyChanged(nameof(History));
                OnPropertyChanged(nameof(Investigation));
                OnPropertyChanged(nameof(Nature));
                OnPropertyChanged(nameof(Religion));
            }
        }
        private int wisdom;
        public int Wisdom 
        { 
            get => wisdom;
            set 
            { 
                SetProperty(ref wisdom, value);
                OnPropertyChanged(nameof(WisdomModifier));
                OnPropertyChanged(nameof(WisdomSavingThrow));
                OnPropertyChanged(nameof(PassivePerception));
                OnPropertyChanged(nameof(AnimalHandling));
                OnPropertyChanged(nameof(Insight));
                OnPropertyChanged(nameof(Medicine));
                OnPropertyChanged(nameof(Perception));
                OnPropertyChanged(nameof(Survival));
                OnPropertyChanged(nameof(SpellSaveDC));
            }
        }
        private int charisma;
        public int Charisma 
        { 
            get => charisma;
            set 
            { 
                SetProperty(ref charisma, value);
                OnPropertyChanged(nameof(CharismaModifier));
                OnPropertyChanged(nameof(CharismaSavingThrow));
                OnPropertyChanged(nameof(Deception));
                OnPropertyChanged(nameof(Intimidation));
                OnPropertyChanged(nameof(Performance));
                OnPropertyChanged(nameof(Persuasion));
            }
        }

        // Ability modifiers
        public int StrengthModifier => (Strength - 10) / 2;
        public int DexterityModifier => (Dexterity - 10) / 2;
        public int ConstitutionModifier => (Constitution - 10) / 2;
        public int IntelligenceModifier => (Intelligence - 10) / 2;
        public int WisdomModifier => (Wisdom - 10) / 2;
        public int CharismaModifier => (Charisma - 10) / 2;

        // Saving throw proficiencies
        private bool strengthSavingThrowProficient;
        public bool StrengthSavingThrowProficient 
        { 
            get => strengthSavingThrowProficient;
            set 
            { 
                SetProperty(ref strengthSavingThrowProficient, value);
                OnPropertyChanged(nameof(StrengthSavingThrow));
            }
        }
        private bool dexteritySavingThrowProficient;
        public bool DexteritySavingThrowProficient 
        { 
            get => dexteritySavingThrowProficient;
            set 
            { 
                SetProperty(ref dexteritySavingThrowProficient, value);
                OnPropertyChanged(nameof(DexteritySavingThrow));
            }
        }
        private bool constitutionSavingThrowProficient;
        public bool ConstitutionSavingThrowProficient 
        { 
            get => constitutionSavingThrowProficient;
            set 
            { 
                SetProperty(ref constitutionSavingThrowProficient, value);
                OnPropertyChanged(nameof(ConstitutionSavingThrow));
            }
        }
        private bool intelligenceSavingThrowProficient;
        public bool IntelligenceSavingThrowProficient 
        { 
            get => intelligenceSavingThrowProficient;
            set 
            { 
                SetProperty(ref intelligenceSavingThrowProficient, value);
                OnPropertyChanged(nameof(IntelligenceSavingThrow));
            }
        }
        private bool wisdomSavingThrowProficient;
        public bool WisdomSavingThrowProficient 
        { 
            get => wisdomSavingThrowProficient;
            set 
            { 
                SetProperty(ref wisdomSavingThrowProficient, value);
                OnPropertyChanged(nameof(WisdomSavingThrow));
                OnPropertyChanged(nameof(PassivePerception));
            }
        }
        private bool charismaSavingThrowProficient;
        public bool CharismaSavingThrowProficient 
        { 
            get => charismaSavingThrowProficient;
            set 
            { 
                SetProperty(ref charismaSavingThrowProficient, value);
                OnPropertyChanged(nameof(CharismaSavingThrow));
            }
        }

        // Saving throws
        public int StrengthSavingThrow => StrengthModifier + (StrengthSavingThrowProficient ? 2 : 0);
        public int DexteritySavingThrow => DexterityModifier + (DexteritySavingThrowProficient ? 2 : 0);
        public int ConstitutionSavingThrow => ConstitutionModifier + (ConstitutionSavingThrowProficient ? 2 : 0);
        public int IntelligenceSavingThrow => IntelligenceModifier + (IntelligenceSavingThrowProficient ? 2 : 0);
        public int WisdomSavingThrow => WisdomModifier + (WisdomSavingThrowProficient ? 2 : 0);
        public int CharismaSavingThrow => CharismaModifier + (CharismaSavingThrowProficient ? 2 : 0);

        // Skill proficiencies
        private bool acrobaticsProficient;
        public bool AcrobaticsProficient 
        { 
            get => acrobaticsProficient;
            set => SetProperty(ref acrobaticsProficient, value);
        }
        private bool animalHandlingProficient;
        public bool AnimalHandlingProficient 
        { 
            get => animalHandlingProficient;
            set => SetProperty(ref animalHandlingProficient, value);
        }
        private bool arcanaProficient;
        public bool ArcanaProficient 
        { 
            get => arcanaProficient;
            set => SetProperty(ref arcanaProficient, value);
        }
        private bool athleticsProficient;
        public bool AthleticsProficient 
        { 
            get => athleticsProficient;
            set => SetProperty(ref athleticsProficient, value);
        }
        private bool deceptionProficient;
        public bool DeceptionProficient 
        { 
            get => deceptionProficient;
            set => SetProperty(ref deceptionProficient, value);
        }
        private bool historyProficient;
        public bool HistoryProficient 
        { 
            get => historyProficient;
            set => SetProperty(ref historyProficient, value);
        }
        private bool insightProficient;
        public bool InsightProficient 
        { 
            get => insightProficient;
            set => SetProperty(ref insightProficient, value);
        }
        private bool intimidationProficient;
        public bool IntimidationProficient 
        { 
            get => intimidationProficient;
            set => SetProperty(ref intimidationProficient, value);
        }
        private bool investigationProficient;
        public bool InvestigationProficient 
        { 
            get => investigationProficient;
            set => SetProperty(ref investigationProficient, value);
        }
        private bool medicineProficient;
        public bool MedicineProficient 
        { 
            get => medicineProficient;
            set => SetProperty(ref medicineProficient, value);
        }
        private bool natureProficient;
        public bool NatureProficient 
        { 
            get => natureProficient;
            set => SetProperty(ref natureProficient, value);
        }
        private bool perceptionProficient;
        public bool PerceptionProficient 
        { 
            get => perceptionProficient;
            set => SetProperty(ref perceptionProficient, value);
        }
        private bool performanceProficient;
        public bool PerformanceProficient 
        { 
            get => performanceProficient;
            set => SetProperty(ref performanceProficient, value);
        }
        private bool persuasionProficient;
        public bool PersuasionProficient 
        { 
            get => persuasionProficient;
            set => SetProperty(ref persuasionProficient, value);
        }
        private bool religionProficient;
        public bool ReligionProficient 
        { 
            get => religionProficient;
            set => SetProperty(ref religionProficient, value);
        }
        private bool sleightOfHandProficient;
        public bool SleightOfHandProficient 
        { 
            get => sleightOfHandProficient;
            set => SetProperty(ref sleightOfHandProficient, value);
        }
        private bool stealthProficient;
        public bool StealthProficient 
        { 
            get => stealthProficient;
            set => SetProperty(ref stealthProficient, value);
        }
        private bool survivalProficient;
        public bool SurvivalProficient 
        { 
            get => survivalProficient;
            set => SetProperty(ref survivalProficient, value);
        }

        // Skills
        public int Acrobatics => DexterityModifier + (AcrobaticsProficient ? ProficiencyBonus : 0);
        public int AnimalHandling => WisdomModifier + (AnimalHandlingProficient ? ProficiencyBonus : 0);
        public int Arcana => IntelligenceModifier + (ArcanaProficient ? ProficiencyBonus : 0);
        public int Athletics => StrengthModifier + (AthleticsProficient ? ProficiencyBonus : 0);
        public int Deception => CharismaModifier + (DeceptionProficient ? ProficiencyBonus : 0);
        public int History => IntelligenceModifier + (HistoryProficient ? ProficiencyBonus : 0);
        public int Insight => WisdomModifier + (InsightProficient ? ProficiencyBonus : 0);
        public int Intimidation => CharismaModifier + (IntimidationProficient ? ProficiencyBonus : 0);
        public int Investigation => IntelligenceModifier + (InvestigationProficient ? ProficiencyBonus : 0);
        public int Medicine => WisdomModifier + (MedicineProficient ? ProficiencyBonus : 0);
        public int Nature => IntelligenceModifier + (NatureProficient ? ProficiencyBonus : 0);
        public int Perception => WisdomModifier + (PerceptionProficient ? ProficiencyBonus : 0);
        public int Performance => CharismaModifier + (PerformanceProficient ? ProficiencyBonus : 0);
        public int Persuasion => CharismaModifier + (PersuasionProficient ? ProficiencyBonus : 0);
        public int Religion => IntelligenceModifier + (ReligionProficient ? ProficiencyBonus : 0);
        public int SleightOfHand => DexterityModifier + (SleightOfHandProficient ? ProficiencyBonus : 0);
        public int Stealth => DexterityModifier + (StealthProficient ? ProficiencyBonus : 0);
        public int Survival => WisdomModifier + (SurvivalProficient ? ProficiencyBonus : 0);

        // Spell Slots
        private int spellSlotsFirstLevel;
        public int SpellSlotsFirstLevel 
        { 
            get => spellSlotsFirstLevel;
            set
            {
                SetProperty(ref spellSlotsFirstLevel, value);
                SetProperty(ref spellSlotsFirstLevelCurrent, value);
            }
        }
        private int spellSlotsSecondLevel;
        public int SpellSlotsSecondLevel 
        { 
            get => spellSlotsSecondLevel;
            set 
            { 
                SetProperty(ref spellSlotsSecondLevel, value);
                SetProperty(ref spellSlotsSecondLevelCurrent, value);
            }
        }
        private int spellSlotsThirdLevel;
        public int SpellSlotsThirdLevel 
        { 
            get => spellSlotsThirdLevel;
            set 
            { 
                SetProperty(ref spellSlotsThirdLevel, value);
                SetProperty(ref spellSlotsThirdLevelCurrent, value);
            }
        }
        private int spellSlotsFourthLevel;
        public int SpellSlotsFourthLevel 
        { 
            get => spellSlotsFourthLevel;
            set 
            { 
                SetProperty(ref spellSlotsFourthLevel, value);
                SetProperty(ref spellSlotsFourthLevelCurrent, value);
            }
        }
        private int spellSlotsFifthLevel;
        public int SpellSlotsFifthLevel 
        { 
            get => spellSlotsFifthLevel;
            set 
            { 
                SetProperty(ref spellSlotsFifthLevel, value);
                SetProperty(ref spellSlotsFifthLevelCurrent, value);
            }
        }
        private int spellSlotsSixthLevel;
        public int SpellSlotsSixthLevel 
        { 
            get => spellSlotsSixthLevel;
            set 
            { 
                SetProperty(ref spellSlotsSixthLevel, value);
                SetProperty(ref spellSlotsSixthLevelCurrent, value);
            }
        }
        private int spellSlotsSeventhLevel;
        public int SpellSlotsSeventhLevel 
        { 
            get => spellSlotsSeventhLevel;
            set 
            { 
                SetProperty(ref spellSlotsSeventhLevel, value);
                SetProperty(ref spellSlotsSeventhLevelCurrent, value);
            }
        }
        private int spellSlotsEighthLevel;
        public int SpellSlotsEighthLevel
        {
            get => spellSlotsEighthLevel;
            set 
            { 
                SetProperty(ref spellSlotsEighthLevel, value);
                SetProperty(ref spellSlotsEighthLevelCurrent, value);
            }
        }
        private int spellSlotsNinthLevel;
        public int SpellSlotsNinthLevel
        {
            get => spellSlotsNinthLevel;
            set 
            { 
                SetProperty(ref spellSlotsNinthLevel, value);
                SetProperty(ref spellSlotsNinthLevelCurrent, value);
            }
        }

        private int spellSlotsFirstLevelCurrent;
        public int SpellSlotsFirstLevelCurrent 
        { 
            get => spellSlotsFirstLevelCurrent;
            set => SetProperty(ref spellSlotsFirstLevelCurrent, value);
        }
        private int spellSlotsSecondLevelCurrent;
        public int SpellSlotsSecondLevelCurrent 
        { 
            get => spellSlotsSecondLevelCurrent;
            set => SetProperty(ref spellSlotsSecondLevelCurrent, value);
        }
        private int spellSlotsThirdLevelCurrent;
        public int SpellSlotsThirdLevelCurrent 
        { 
            get => spellSlotsThirdLevelCurrent;
            set => SetProperty(ref spellSlotsThirdLevelCurrent, value);
        }
        private int spellSlotsFourthLevelCurrent;
        public int SpellSlotsFourthLevelCurrent 
        { 
            get => spellSlotsFourthLevelCurrent;
            set => SetProperty(ref spellSlotsFourthLevelCurrent, value);
        }
        private int spellSlotsFifthLevelCurrent;
        public int SpellSlotsFifthLevelCurrent 
        { 
            get => spellSlotsFifthLevelCurrent;
            set => SetProperty(ref spellSlotsFifthLevelCurrent, value);
        }
        private int spellSlotsSixthLevelCurrent;
        public int SpellSlotsSixthLevelCurrent 
        { 
            get => spellSlotsSixthLevelCurrent;
            set => SetProperty(ref spellSlotsSixthLevelCurrent, value);
        }
        private int spellSlotsSeventhLevelCurrent;
        public int SpellSlotsSeventhLevelCurrent 
        { 
            get => spellSlotsSeventhLevelCurrent;
            set => SetProperty(ref spellSlotsSeventhLevelCurrent, value);
        }
        private int spellSlotsEighthLevelCurrent;
        public int SpellSlotsEighthLevelCurrent
        {
            get => spellSlotsEighthLevelCurrent;
            set => SetProperty(ref spellSlotsEighthLevelCurrent, value);
        }
        private int spellSlotsNinthLevelCurrent;
        public int SpellSlotsNinthLevelCurrent
        {
            get => spellSlotsNinthLevelCurrent;
            set => SetProperty(ref spellSlotsNinthLevelCurrent, value);
        }


    }
}
