using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    internal class TraitAllViewModel : BindableObject
    {
        private readonly ObservableCollection<Trait> _allTraits = new ObservableCollection<Trait>();
        readonly TraitDatabase db;
        private Dictionary<string, Func<Trait, bool>> _filterPredicates = new Dictionary<string, Func<Trait, bool>>();

        public ObservableCollection<Trait> Traits { get; } = new ObservableCollection<Trait>();

        public TraitAllViewModel(TraitDatabase database)
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
                var pred = new Func<Trait, bool>(s =>
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

            _allTraits.Clear();
            Traits.Clear();
            var items = await db.GetAllTraitsAsync();
            var abilities = items.OrderBy(x => x.Name);
            foreach (var s in items)
            {
                _allTraits.Add(s);
                Traits.Add(s);
            }
            ApplyFilters();


            //Traits.Clear();
            //var items = await db.GetAllTraitsAsync();
            //var traits = items.OrderBy(x => x.Name);
            //foreach (var t in traits)
            //{
            //    Traits.Add(t);
            //}
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
        private void ApplyFilters()
        {
            Traits.Clear();
            var abilities = _allTraits.OrderBy(s => s.Name);

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
                    Traits.Add(spell);
                }
            }
        }
    }
}
