using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;
using Microsoft.Maui.Controls;

namespace TBH.DND.Android.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        readonly SpellDatabase db;
        readonly FeatDatabase featDb;

        public ObservableCollection<Spell> Spells { get; } = new ObservableCollection<Spell>();
        public ObservableCollection<Feat> Feats { get; } = new ObservableCollection<Feat>();

        public ICommand RefreshCommand { get; }
        public ICommand ToggleExpandCommand { get; }
        public ICommand OpenEditorCommand { get; }

        public MainPageViewModel(SpellDatabase database, FeatDatabase featDatabase)
        {
            db = database;
            featDb = featDatabase;
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
            Feats.Clear();
            var feats = await featDb.GetActiveFeatsAsync();
            foreach (var f in feats)
                Feats.Add(f);
        }
    }
}
