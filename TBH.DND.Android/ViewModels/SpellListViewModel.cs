using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;
using Microsoft.Maui.Controls;

namespace TBH.DND.Android.ViewModels
{
    public class SpellListViewModel : BindableObject
    {
        readonly SpellDatabase db;

        public ObservableCollection<Spell> Spells { get; } = new ObservableCollection<Spell>();

        public ICommand RefreshCommand { get; }
        public ICommand ToggleExpandCommand { get; }
        public ICommand OpenEditorCommand { get; }

        public SpellListViewModel(SpellDatabase database)
        {
            db = database;
            RefreshCommand = new Command(async () => await LoadAsync());
            ToggleExpandCommand = new Command<Spell>((s) => { if (s != null) s.IsExpanded = !s.IsExpanded; });
            OpenEditorCommand = new Command(async () => await Shell.Current.GoToAsync("SpellEditorPage"));

            // Will reload when the page appears; no messaging required
        }

        public async Task LoadAsync()
        {
            Spells.Clear();
            var items = await db.GetActiveSpellsAsync();
            foreach (var s in items)
                Spells.Add(s);
        }
    }
}
