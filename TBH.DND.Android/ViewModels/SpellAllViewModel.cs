using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    public class SpellAllViewModel : BindableObject
    {
        private readonly ObservableCollection<Spell> _allSpells = new ObservableCollection<Spell>();
        readonly SpellDatabase db;
        private Dictionary<string, Func<Spell, bool>> _filterPredicates = new Dictionary<string, Func<Spell, bool>>();

        public Array Classes { get; } = Enum.GetNames(typeof(Spell.SpellClass)).Prepend("All").ToArray();
        public Array Sources { get; } = Enum.GetNames(typeof(Spell.SpellSource)).Prepend("All").ToArray();

        private string selectedClass;
        public string SelectedClass
        {
            get => selectedClass;
            set
            {
                if (selectedClass == value) return;
                selectedClass = value;
                var pred = new Func<Spell, bool>(s =>
                {
                    if (SelectedClass == "All")
                    {
                        return true;
                    }
                    else
                    {
                        var selectedClassEnum = (Spell.SpellClass)Enum.Parse(typeof(Spell.SpellClass), SelectedClass);
                        return (s.Class & (int)selectedClassEnum) != 0;
                    }
                });
                _filterPredicates["Class"] = pred;
                ApplyFilters();
                OnPropertyChanged(nameof(SelectedClass));
            }
        }
        private string selectedSource;
        public string SelectedSource
        {
            get => selectedSource;
            set
            {
                if (selectedSource == value) return;
                selectedSource = value;
                var pred = new Func<Spell, bool>(s =>
                {
                    if (value == "All")
                    {
                        return true;
                    }
                    else
                    {
                        var selectedSourceEnum = (Spell.SpellSource)Enum.Parse(typeof(Spell.SpellSource), value);
                        return s.Source == selectedSourceEnum.ToString();
                    }
                });
                _filterPredicates["Source"] = pred;
                ApplyFilters();
                OnPropertyChanged(nameof(SelectedSource));
            }
        }
        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                if (searchText == value) return;
                searchText = value;
                var pred = new Func<Spell, bool>(s =>
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                    else
                    {
                        return s.Name.Contains(value);
                    }
                });
                _filterPredicates["Search"] = pred;
                ApplyFilters();
                OnPropertyChanged(nameof(SearchText));
            }
        }
        private string sortOrder = "Level";
        public string SortOrder { 
            get => sortOrder;
            set
            {
                if (sortOrder == value) return;
                sortOrder = value;
                ApplyFilters();
                OnPropertyChanged(nameof(SortOrder));
            }
        }
        public ObservableCollection<Spell> Spells { get; } = new ObservableCollection<Spell>();

        public SpellAllViewModel(SpellDatabase database)
        {
            db = database;
            this.SelectedClass = "All";
            this.SelectedSource = "All";
        }

        public async Task LoadAsync()
        {
            _allSpells.Clear();
            Spells.Clear();
            var items = await db.GetAllSpellsAsync();
            foreach (var s in items)
            {
                _allSpells.Add(s);
                Spells.Add(s);
            }
            ApplyFilters();
        }

        public async Task SaveSpellAsync(Spell s, bool load)
        {
            await db.SaveSpellAsync(s);
            if (load)
                await LoadAsync();
        }

        public async Task DeleteSpellAsync(Spell s)
        {
            await db.DeleteSpellAsync(s.Id);
            _allSpells.Remove(s);
            Spells.Remove(s);
        }

        private void ApplyFilters()
        {
            Spells.Clear();
            // Default to sorting by level if no sort order is specified
            var spells = _allSpells.OrderBy(s => s.Level);
            if (SortOrder == "Name")
                spells = _allSpells.OrderBy(s => s.Name);

            foreach (var spell in spells)
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
                    Spells.Add(spell);
                }
            }
        }
    }
}
