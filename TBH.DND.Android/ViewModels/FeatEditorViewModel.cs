using System.Windows.Input;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    public class FeatEditorViewModel : BindableObject
    {
        readonly FeatDatabase db;
        public Array Sources { get; } = Enum.GetValues(typeof(FilterLists.Source));
        private FilterLists.Source selectedSource;
        public FilterLists.Source SelectedSource
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

        public Feat Current { get; set; } = new Feat();

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public FeatEditorViewModel(FeatDatabase database)
        {
            db = database;
            SaveCommand = new Command(async () => await SaveAsync());
            CancelCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        public async Task LoadAsync(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var f = await db.GetFeatAsync(id.Value);
                if (f != null)
                {
                    Current = f;
                    if (!Enum.TryParse<FilterLists.Source>(Current.Source, out var parsedSource))
                        parsedSource = (FilterLists.Source)Sources.GetValue(0);
                    selectedSource = parsedSource;
                    OnPropertyChanged(nameof(Current));
                    OnPropertyChanged(nameof(SelectedSource));
                }
            }
            else
            {
                Current = new Feat();
                selectedSource = (FilterLists.Source)Sources.GetValue(0);
                OnPropertyChanged(nameof(Current));
                OnPropertyChanged(nameof(SelectedSource));
            }
        }

        async Task SaveAsync()
        {
            await db.SaveFeatAsync(Current);
            // rely on MainPage.OnAppearing to refresh the list
            await Shell.Current.GoToAsync("..");
        }
    }
}
