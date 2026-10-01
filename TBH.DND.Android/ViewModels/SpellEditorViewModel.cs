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
