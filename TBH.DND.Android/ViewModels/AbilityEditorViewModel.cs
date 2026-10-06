using System.Windows.Input;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    public class AbilityEditorViewModel : BindableObject
    {
        readonly AbilityDatabase db;

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
                    OnPropertyChanged(nameof(Current));
                }
            }
            else
            {
                Current = new Ability();
                OnPropertyChanged(nameof(Current));
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
