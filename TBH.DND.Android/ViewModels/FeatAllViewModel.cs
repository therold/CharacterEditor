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
            foreach (var f in items)
            {
                Feats.Add(f);
            }
        }

        public async Task SaveFeatAsync(Feat f)
        {
            await db.SaveFeatAsync(f);
        }
    }
}
