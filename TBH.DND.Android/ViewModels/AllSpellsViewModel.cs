using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    public class AllSpellsViewModel : BindableObject
    {
        readonly SpellDatabase db;

        public ObservableCollection<Spell> Spells { get; } = new ObservableCollection<Spell>();

        public AllSpellsViewModel(SpellDatabase database)
        {
            db = database;
        }

        public async Task LoadAsync()
        {
            Spells.Clear();
            var items = await db.GetAllSpellsAsync();
            foreach (var s in items)
                Spells.Add(s);
        }

        public async Task SaveSpellAsync(Spell s)
        {
            await db.SaveSpellAsync(s);
        }
    }
}
