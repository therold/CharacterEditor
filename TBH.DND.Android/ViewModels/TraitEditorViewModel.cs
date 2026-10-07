using System.Windows.Input;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    public class TraitEditorViewModel : BindableObject
    {
        readonly TraitDatabase db;
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

        public Trait Current { get; set; } = new Trait();

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public TraitEditorViewModel(TraitDatabase database)
        {
            db = database;
            SaveCommand = new Command(async () => await SaveAsync());
            CancelCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        public async Task LoadAsync(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var t = await db.GetTraitAsync(id.Value);
                if (t != null)
                {
                    Current = t;
                    if (!Enum.TryParse<Spell.SpellSource>(Current.Source, out var parsedSource))
                        parsedSource = (Spell.SpellSource)Sources.GetValue(0);
                    selectedSource = parsedSource;
                    OnPropertyChanged(nameof(Current));
                    OnPropertyChanged(nameof(SelectedSource));
                }
            }
            else
            {
                Current = new Trait();
                selectedSource = (Spell.SpellSource)Sources.GetValue(0);
                OnPropertyChanged(nameof(Current));
                OnPropertyChanged(nameof(SelectedSource));
            }
        }

        async Task SaveAsync()
        {
            await db.SaveTraitAsync(Current);
            // rely on MainPage.OnAppearing to refresh the list
            await Shell.Current.GoToAsync("..");
        }
    }
}
