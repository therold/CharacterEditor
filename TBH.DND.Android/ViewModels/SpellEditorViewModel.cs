using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    public class SpellEditorViewModel : BindableObject
    {
        readonly SpellDatabase db;

        public Array Schools { get; } = Enum.GetValues(typeof(Spell.SpellSchool));
        public Array Levels { get; } = new string[] { "Cantrip", "Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Level 6", "Level 7", "Level 8", "Level 9" };
        public Spell Current { get; set; } = new Spell();

        private string selectedLevel;
        public string SelectedLevel
        {
            get => selectedLevel;
            set
            {
                if (selectedLevel == value) return;
                selectedLevel = value;
                // keep Current.Level (int) in sync for persistence
                Current.Level = Levels.OfType<string>().ToList().IndexOf(SelectedLevel);
                OnPropertyChanged(nameof(SelectedLevel));
            }
        }
        private Spell.SpellSchool selectedSchool;
        public Spell.SpellSchool SelectedSchool
        {
            get => selectedSchool;
            set
            {
                if (selectedSchool == value) return;
                selectedSchool = value;
                // keep Current.School (string) in sync for persistence
                Current.School = selectedSchool.ToString();
                OnPropertyChanged(nameof(SelectedSchool));
            }
        }

        public bool ClassBard
        {
            get => (Current.Class & (int)Spell.SpellClass.Bard) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)Spell.SpellClass.Bard;
                else
                    Current.Class &= ~(int)Spell.SpellClass.Bard;
                OnPropertyChanged(nameof(ClassBard));
            }
        }
        public bool ClassCleric
        {
            get => (Current.Class & (int)Spell.SpellClass.Cleric) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)Spell.SpellClass.Cleric;
                else
                    Current.Class &= ~(int)Spell.SpellClass.Cleric;
                OnPropertyChanged(nameof(ClassCleric));
            }
        }
        public bool ClassDruid
        {
            get => (Current.Class & (int)Spell.SpellClass.Druid) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)Spell.SpellClass.Druid;
                else
                    Current.Class &= ~(int)Spell.SpellClass.Druid;
                OnPropertyChanged(nameof(ClassDruid));
            }
        }
        public bool ClassPaladin
        {
            get => (Current.Class & (int)Spell.SpellClass.Paladin) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)Spell.SpellClass.Paladin;
                else
                    Current.Class &= ~(int)Spell.SpellClass.Paladin;
                OnPropertyChanged(nameof(ClassPaladin));
            }
        }
        public bool ClassRanger
        {
            get => (Current.Class & (int)Spell.SpellClass.Ranger) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)Spell.SpellClass.Ranger;
                else
                    Current.Class &= ~(int)Spell.SpellClass.Ranger;
                OnPropertyChanged(nameof(ClassRanger));
            }
        }
        public bool ClassSorcerer
        {
            get => (Current.Class & (int)Spell.SpellClass.Sorcerer) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)Spell.SpellClass.Sorcerer;
                else
                    Current.Class &= ~(int)Spell.SpellClass.Sorcerer;
                OnPropertyChanged(nameof(ClassSorcerer));
            }
        }
        public bool ClassWarlock
        {
            get => (Current.Class & (int)Spell.SpellClass.Warlock) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)Spell.SpellClass.Warlock;
                else
                    Current.Class &= ~(int)Spell.SpellClass.Warlock;
                OnPropertyChanged(nameof(ClassWarlock));
            }
        }
        public bool ClassWizard
        {
            get => (Current.Class & (int)Spell.SpellClass.Wizard) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)Spell.SpellClass.Wizard;
                else
                    Current.Class &= ~(int)Spell.SpellClass.Wizard;
                OnPropertyChanged(nameof(ClassWizard));
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public SpellEditorViewModel(SpellDatabase database)
        {
            db = database;
            SaveCommand = new Command(async () => await SaveAsync());
            CancelCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        public async Task LoadAsync(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var s = await db.GetSpellAsync(id.Value);
                if (s != null)
                {
                    Current = s;
                    selectedLevel = Levels.GetValue(Current.Level)?.ToString() ?? Levels.GetValue(0)?.ToString();
                    // try parse existing string into enum, default to first value on failure
                    if (!Enum.TryParse<Spell.SpellSchool>(Current.School, out var parsed))
                        parsed = (Spell.SpellSchool)Schools.GetValue(0);
                    selectedSchool = parsed;
                    OnPropertyChanged(nameof(Current));
                    OnPropertyChanged(nameof(SelectedSchool));
                    OnPropertyChanged(nameof(SelectedLevel));
                    OnPropertyChanged(nameof(ClassBard));
                    OnPropertyChanged(nameof(ClassCleric));
                    OnPropertyChanged(nameof(ClassDruid));
                    OnPropertyChanged(nameof(ClassPaladin));
                    OnPropertyChanged(nameof(ClassRanger));
                    OnPropertyChanged(nameof(ClassSorcerer));
                    OnPropertyChanged(nameof(ClassWarlock));
                    OnPropertyChanged(nameof(ClassWizard));
                }
            }
            else
            {
                Current = new Spell();
                selectedLevel = Levels.GetValue(0)?.ToString();
                selectedSchool = (Spell.SpellSchool)Schools.GetValue(0);
                Current.School = selectedSchool.ToString();
                OnPropertyChanged(nameof(Current));
                OnPropertyChanged(nameof(SelectedSchool));
                OnPropertyChanged(nameof(SelectedLevel));
            }
        }

        async Task SaveAsync()
        {
            await db.SaveSpellAsync(Current);
            // rely on MainPage.OnAppearing to refresh the list
            await Shell.Current.GoToAsync("..");
        }
    }
}
