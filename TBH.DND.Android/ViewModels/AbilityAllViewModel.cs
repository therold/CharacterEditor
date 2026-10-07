using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    internal class AbilityAllViewModel : BindableObject
    {
        private readonly ObservableCollection<Ability> _allAbilities = new ObservableCollection<Ability>();
        readonly AbilityDatabase db;
        private Dictionary<string, Func<Ability, bool>> _filterPredicates = new Dictionary<string, Func<Ability, bool>>();

        public ObservableCollection<Ability> Abilities { get; } = new ObservableCollection<Ability>();

        public AbilityAllViewModel(AbilityDatabase database)
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
                var pred = new Func<Ability, bool>(s =>
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
            _allAbilities.Clear();
            Abilities.Clear();
            var items = await db.GetAllAbilitiesAsync();
            var abilities = items.OrderBy(x => x.Name);
            foreach (var s in items)
            {
                _allAbilities.Add(s);
                Abilities.Add(s);
            }
            ApplyFilters();
        }

        public async Task SaveAbilityAsync(Ability a)
        {
            await db.SaveAbilityAsync(a);
        }
        public async Task DeleteAbilityAsync(Ability a)
        {
            await db.DeleteAbilityAsync(a.Id);
            Abilities.Remove(a);
        }
        private void ApplyFilters()
        {
            Abilities.Clear();
            var abilities = _allAbilities.OrderBy(s => s.Name);

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
                    Abilities.Add(spell);
                }
            }
        }
    }
}
