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

        public Spell Current { get; set; } = new Spell();

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
                    OnPropertyChanged(nameof(Current));
                }
            }
            else
            {
                Current = new Spell();
                OnPropertyChanged(nameof(Current));
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
