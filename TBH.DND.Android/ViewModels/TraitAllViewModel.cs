using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    internal class TraitAllViewModel
    {
        readonly TraitDatabase db;

        public ObservableCollection<Trait> Traits { get; } = new ObservableCollection<Trait>();

        public TraitAllViewModel(TraitDatabase database)
        {
            db = database;
        }

        public async Task LoadAsync()
        {
            Traits.Clear();
            var items = await db.GetAllTraitsAsync();
            var traits = items.OrderBy(x => x.Name);
            foreach (var t in traits)
            {
                Traits.Add(t);
            }
        }

        public async Task SaveTraitAsync(Trait t)
        {
            await db.SaveTraitAsync(t);
        }
        public async Task DeleteTraitAsync(Trait t)
        {
            await db.DeleteTraitAsync(t.Id);
            Traits.Remove(t);
        }
    }
}
