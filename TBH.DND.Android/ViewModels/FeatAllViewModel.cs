using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    internal class FeatAllViewModel : BindableObject
    {
        private readonly ObservableCollection<Feat> _allFeats = new ObservableCollection<Feat>();
        readonly FeatDatabase db;
        private Dictionary<string, Func<Feat, bool>> _filterPredicates = new Dictionary<string, Func<Feat, bool>>();

        public ObservableCollection<Feat> Feats { get; } = new ObservableCollection<Feat>();

        public FeatAllViewModel(FeatDatabase database)
        {
            db = database;
        }
        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                if (searchText == value) return;
                searchText = value;
                var pred = new Func<Feat, bool>(s =>
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                    else
                    {
                        return s.Name.ToUpper().Contains(value.ToUpper());
                    }
                });
                _filterPredicates["Search"] = pred;
                ApplyFilters();
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public async Task LoadAsync()
        {
            _allFeats.Clear();
            Feats.Clear();
            var items = await db.GetAllFeatsAsync();
            var abilities = items.OrderBy(x => x.Name);
            foreach (var s in items)
            {
                _allFeats.Add(s);
                Feats.Add(s);
            }
            ApplyFilters();

            //Feats.Clear();
            //var items = await db.GetAllFeatsAsync();
            //var feats = items.OrderBy(x => x.Name);
            //foreach (var f in feats)
            //{
            //    Feats.Add(f);
            //}
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
        private void ApplyFilters()
        {
            Feats.Clear();
            var abilities = _allFeats.OrderBy(s => s.Name);

            foreach (var spell in abilities)
            {
                bool include = true;
                foreach (var predicate in _filterPredicates)
                {
                    if (!predicate.Value(spell))
                    {
                        include = false;
                        break;
                    }
                }
                if (include)
                {
                    Feats.Add(spell);
                }
            }
        }
    }
}
