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

        public Array Classes { get; } = Enum.GetNames(typeof(FilterLists.DndClass)).Prepend("All").ToArray();
        public Array Races { get; } = Enum.GetNames(typeof(FilterLists.Race)).Prepend("All").ToArray();
        public Array Backgrounds { get; } = Enum.GetNames(typeof(FilterLists.Background)).Prepend("All").ToArray();
        public Array Sources { get; } = Enum.GetNames(typeof(FilterLists.Source)).Prepend("All").ToArray();
        private string selectedClass;
        public string SelectedClass
        {
            get => selectedClass;
            set
            {
                if (selectedClass == value) return;
                selectedClass = value;
                ApplyFilters();
                OnPropertyChanged(nameof(SelectedClass));
            }
        }
        private string selectedRace;
        public string SelectedRace
        {
            get => selectedRace;
            set
            {
                if (selectedRace == value) return;
                selectedRace = value;
                ApplyFilters();
                OnPropertyChanged(nameof(SelectedRace));
            }
        }
        private string selectedBackground;
        public string SelectedBackground
        {
            get => selectedBackground;
            set
            {
                if (selectedBackground == value) return;
                selectedBackground = value;
                ApplyFilters();
                OnPropertyChanged(nameof(SelectedBackground));
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
                ApplyFilters();
                OnPropertyChanged(nameof(SelectedSource));
            }
        }
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
                ApplyFilters();
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public async Task LoadAsync()
        {

            _allTraits.Clear();
            Traits.Clear();
            var items = await db.GetAllTraitsAsync();
            var traits = items.OrderBy(x => x.Name);
            foreach (var t in traits)
            {
                _allTraits.Add(t);
                Traits.Add(t);
            }
            ApplyFilters();
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
            var orderedTraits = _allTraits.OrderBy(s => s.Name).ToList();

            if ((string.IsNullOrEmpty(SelectedClass) || SelectedClass == "All") &&
                    (string.IsNullOrEmpty(SelectedRace) || SelectedRace == "All") &&
                    (string.IsNullOrEmpty(SelectedBackground) || SelectedBackground == "All") &&
                    (string.IsNullOrEmpty(SelectedSource) || SelectedSource == "All") &&
                    (string.IsNullOrEmpty(SearchText)))
            {
                // No filters
                foreach (var t in orderedTraits)
                    Traits.Add(t);
            }
            else
            {
                var result = new List<Trait>();
                
                // Filter behavior:
                // (class || race || background) && source && search
                if (!string.IsNullOrEmpty(SelectedClass) && SelectedClass != "All")
                {
                    var selectedClassEnum = (FilterLists.DndClass)Enum.Parse(typeof(FilterLists.DndClass), SelectedClass);
                    var traits = orderedTraits.Where(t => (t.Class & (int)selectedClassEnum) != 0).ToList();
                    foreach (var t in traits)
                        result.Add(t);
                }
                if (!string.IsNullOrEmpty(SelectedRace) && SelectedRace != "All")
                {
                    var selectedRaceEnum = (FilterLists.Race)Enum.Parse(typeof(FilterLists.Race), SelectedRace);
                    var traits = orderedTraits.Where(t => (t.Race & (int)selectedRaceEnum) != 0).ToList();
                    foreach (var t in traits)
                        result.Add(t);
                }
                if (!string.IsNullOrEmpty(SelectedBackground) && SelectedBackground != "All")
                {
                    var selectedBackgroundEnum = (FilterLists.Background)Enum.Parse(typeof(FilterLists.Background), SelectedBackground);
                    var traits = orderedTraits.Where(t => (t.Background & (int)selectedBackgroundEnum) != 0).ToList();
                    foreach (var t in traits)
                        result.Add(t);
                }

                if (!string.IsNullOrEmpty(SelectedSource) && SelectedSource != "All")
                {
                    var selectedSourceEnum = (FilterLists.Source)Enum.Parse(typeof(FilterLists.Source), SelectedSource);
                    result = result.Where(t => t.Source == selectedSourceEnum.ToString()).ToList();
                }
                if (!string.IsNullOrEmpty(SearchText))
                {
                    result = result.Where(t => t.Name.ToUpper().Contains(SearchText.ToUpper())).ToList();
                }

                foreach (var t in result)
                    Traits.Add(t);
            }
        }
    }
}
