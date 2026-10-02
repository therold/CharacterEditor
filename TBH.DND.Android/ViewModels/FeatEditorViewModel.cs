using System.Windows.Input;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    public class FeatEditorViewModel : BindableObject
    {
        readonly FeatDatabase db;

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
                    OnPropertyChanged(nameof(Current));
                }
            }
            else
            {
                Current = new Feat();
                OnPropertyChanged(nameof(Current));
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
