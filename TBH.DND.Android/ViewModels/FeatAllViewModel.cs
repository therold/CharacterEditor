using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    internal class FeatAllViewModel
    {
        readonly FeatDatabase db;

        public ObservableCollection<Feat> Feats { get; } = new ObservableCollection<Feat>();

        public FeatAllViewModel(FeatDatabase database)
        {
            db = database;
        }

        public async Task LoadAsync()
        {
            Feats.Clear();
            var items = await db.GetAllFeatsAsync();
            var feats = items.OrderBy(x => x.Name);
            foreach (var f in feats)
            {
                Feats.Add(f);
            }
        }

        public async Task SaveFeatAsync(Feat f)
        {
            await db.SaveFeatAsync(f);
        }
        public async Task DeleteFeatAsync(Feat f)
        {
            await db.DeleteFeatAsync(f.Id);
            Feats.Remove(f);
        }
    }
}
