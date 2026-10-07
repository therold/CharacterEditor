using System.Windows.Input;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    public class AbilityEditorViewModel : BindableObject
    {
        readonly AbilityDatabase db;
        public Array Sources { get; } = Enum.GetValues(typeof(Spell.SpellSource));
        private Spell.SpellSource selectedSource;
        public Spell.SpellSource SelectedSource
        {
            get => selectedSource;
            set
            {
                if (selectedSource == value) return;
                selectedSource = value;
                // keep Current.Source (string) in sync for persistence
                Current.Source = selectedSource.ToString();
                OnPropertyChanged(nameof(SelectedSource));
            }
        }

        public Ability Current { get; set; } = new Ability();

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public AbilityEditorViewModel(AbilityDatabase database)
        {
            db = database;
            SaveCommand = new Command(async () => await SaveAsync());
            CancelCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        public async Task LoadAsync(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var a = await db.GetAbilityAsync(id.Value);
                if (a != null)
                {
                    Current = a;
                    if (!Enum.TryParse<Spell.SpellSource>(Current.Source, out var parsedSource))
                        parsedSource = (Spell.SpellSource)Sources.GetValue(0);
                    selectedSource = parsedSource;
                    OnPropertyChanged(nameof(Current));
                    OnPropertyChanged(nameof(SelectedSource));
                }
            }
            else
            {
                Current = new Ability();
                selectedSource = (Spell.SpellSource)Sources.GetValue(0);
                OnPropertyChanged(nameof(Current));
                OnPropertyChanged(nameof(SelectedSource));
            }
        }

        async Task SaveAsync()
        {
            await db.SaveAbilityAsync(Current);
            // rely on MainPage.OnAppearing to refresh the list
            await Shell.Current.GoToAsync("..");
        }
    }
}
