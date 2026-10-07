using System.Windows.Input;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    public class CharacterEditorViewModel : BindableObject
    {
        readonly CharacterDatabase db;

        public Character Current { get; set; } = new Character();

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public CharacterEditorViewModel(CharacterDatabase database)
        {
            db = database;
            SaveCommand = new Command(async () => await SaveAsync());
            CancelCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        public async Task LoadAsync(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var t = await db.GetCharacterAsync(id.Value);
                if (t != null)
                {
                    Current = t;
                    OnPropertyChanged(nameof(Current));
                }
            }
            else
            {
                Current = new Character();
                OnPropertyChanged(nameof(Current));
            }
        }

        async Task SaveAsync()
        {
            await db.SaveCharacterAsync(Current);
            // rely on MainPage.OnAppearing to refresh the list
            await Shell.Current.GoToAsync("..");
        }
    }
}
