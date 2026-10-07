using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        readonly SpellDatabase db;
        readonly FeatDatabase featDb;
        readonly AbilityDatabase abilityDb;
        readonly TraitDatabase traitDb;
        readonly CharacterDatabase characterDb;

        public ObservableCollection<Spell> Spells { get; } = new ObservableCollection<Spell>();
        public ObservableCollection<Feat> Feats { get; } = new ObservableCollection<Feat>();
        public ObservableCollection<Ability> Abilities { get; } = new ObservableCollection<Ability>();
        public ObservableCollection<Trait> Traits { get; } = new ObservableCollection<Trait>();
        public Character Character { get; set; }
        public ICommand RefreshCommand { get; }
        public ICommand ToggleExpandCommand { get; }
        public ICommand OpenEditorCommand { get; }

        public MainPageViewModel(SpellDatabase database, FeatDatabase featDatabase, AbilityDatabase abilityDatabase, TraitDatabase traitDatabase, CharacterDatabase characterDatabase)
        {
            db = database;
            featDb = featDatabase;
            abilityDb = abilityDatabase;
            traitDb = traitDatabase;
            characterDb = characterDatabase;
            RefreshCommand = new Command(async () => await LoadAsync());
            ToggleExpandCommand = new Command<Spell>((s) => { if (s != null) s.IsExpanded = !s.IsExpanded; });
            OpenEditorCommand = new Command(async () => await Shell.Current.GoToAsync("SpellEditorPage"));
            Character = new Character();
            // Will reload when the page appears; no messaging required
        }

        public async Task LoadAsync()
        {
            Spells.Clear();
            var items = await db.GetActiveSpellsAsync();
            foreach (var s in items)
                Spells.Add(s);
            Feats.Clear();
            var feats = await featDb.GetActiveFeatsAsync();
            foreach (var f in feats)
                Feats.Add(f);
            Abilities.Clear();
            var abilities = await abilityDb.GetActiveAbilitiesAsync();
            foreach (var a in abilities)
                Abilities.Add(a);
            Traits.Clear();
            var traits = await traitDb.GetActiveTraitsAsync();
            foreach (var t in traits)
                Traits.Add(t);
            var characters = await characterDb.GetAllCharactersAsync();
            var c = characters?.OrderBy(x => x.Id)?.FirstOrDefault();
            if (c != null)
            {
                Character.Id = c.Id;
                Character.Name = c.Name;
                Character.Level = c.Level;
                Character.Race = c.Race;
                Character.Class = c.Class;
                Character.MaxHP = c.MaxHP;
                Character.TempMaxHP = c.TempMaxHP;
                Character.CurrentHP = c.CurrentHP;
                Character.TempCurrentHP = c.TempCurrentHP;
                Character.ArmorClass = c.ArmorClass;
                Character.Initiative = c.Initiative;
                Character.Speed = c.Speed;

                Character.StrengthSavingThrowProficient = c.StrengthSavingThrowProficient;
                Character.DexteritySavingThrowProficient = c.DexteritySavingThrowProficient;
                Character.ConstitutionSavingThrowProficient = c.ConstitutionSavingThrowProficient;
                Character.IntelligenceSavingThrowProficient = c.IntelligenceSavingThrowProficient;
                Character.WisdomSavingThrowProficient = c.WisdomSavingThrowProficient;
                Character.CharismaSavingThrowProficient = c.CharismaSavingThrowProficient;

                Character.AcrobaticsProficient = c.AcrobaticsProficient;
                Character.AnimalHandlingProficient = c.AnimalHandlingProficient;
                Character.ArcanaProficient = c.ArcanaProficient;
                Character.AthleticsProficient = c.AthleticsProficient;
                Character.DeceptionProficient = c.DeceptionProficient;
                Character.HistoryProficient = c.HistoryProficient;
                Character.InsightProficient = c.InsightProficient;
                Character.IntimidationProficient = c.IntimidationProficient;
                Character.InvestigationProficient = c.InvestigationProficient;
                Character.MedicineProficient = c.MedicineProficient;
                Character.NatureProficient = c.NatureProficient;
                Character.PerceptionProficient = c.PerceptionProficient;
                Character.PerformanceProficient = c.PerformanceProficient;
                Character.PersuasionProficient = c.PersuasionProficient;
                Character.ReligionProficient = c.ReligionProficient;
                Character.SleightOfHandProficient = c.SleightOfHandProficient;
                Character.StealthProficient = c.StealthProficient;
                Character.SurvivalProficient = c.SurvivalProficient;

                Character.Strength = c.Strength;
                Character.Dexterity = c.Dexterity;
                Character.Constitution = c.Constitution;
                Character.Intelligence = c.Intelligence;
                Character.Wisdom = c.Wisdom;
                Character.Charisma = c.Charisma;

                Character.SpellSlotsFirstLevel = c.SpellSlotsFirstLevel;
                Character.SpellSlotsSecondLevel = c.SpellSlotsSecondLevel;
                Character.SpellSlotsThirdLevel = c.SpellSlotsThirdLevel;
                Character.SpellSlotsFourthLevel = c.SpellSlotsFourthLevel;
                Character.SpellSlotsFifthLevel = c.SpellSlotsFifthLevel;
                Character.SpellSlotsSixthLevel = c.SpellSlotsSixthLevel;
                Character.SpellSlotsSeventhLevel = c.SpellSlotsSeventhLevel;
                Character.SpellSlotsEighthLevel = c.SpellSlotsEighthLevel;
                Character.SpellSlotsNinthLevel = c.SpellSlotsNinthLevel;

                Character.SpellSlotsFirstLevelCurrent = c.SpellSlotsFirstLevelCurrent;
                Character.SpellSlotsSecondLevelCurrent = c.SpellSlotsSecondLevelCurrent;
                Character.SpellSlotsThirdLevelCurrent = c.SpellSlotsThirdLevelCurrent;
                Character.SpellSlotsFourthLevelCurrent = c.SpellSlotsFourthLevelCurrent;
                Character.SpellSlotsFifthLevelCurrent = c.SpellSlotsFifthLevelCurrent;
                Character.SpellSlotsSixthLevelCurrent = c.SpellSlotsSixthLevelCurrent;
                Character.SpellSlotsSeventhLevelCurrent = c.SpellSlotsSeventhLevelCurrent;
                Character.SpellSlotsEighthLevelCurrent = c.SpellSlotsEighthLevelCurrent;
                Character.SpellSlotsNinthLevelCurrent = c.SpellSlotsNinthLevelCurrent;


            }
        }
    }
}
