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

        public Spell Current { get; set; } = new Spell();

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
                    // try parse existing string into enum, default to first value on failure
                    if (!Enum.TryParse<Spell.SpellSchool>(Current.School, out var parsed))
                        parsed = (Spell.SpellSchool)Schools.GetValue(0);
                    selectedSchool = parsed;
                    OnPropertyChanged(nameof(Current));
                    OnPropertyChanged(nameof(SelectedSchool));
                }
            }
            else
            {
                Current = new Spell();
                selectedSchool = (Spell.SpellSchool)Schools.GetValue(0);
                Current.School = selectedSchool.ToString();
                OnPropertyChanged(nameof(Current));
                OnPropertyChanged(nameof(SelectedSchool));
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
