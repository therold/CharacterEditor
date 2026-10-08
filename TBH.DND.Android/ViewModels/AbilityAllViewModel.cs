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
            var orderedAbilities = _allAbilities.OrderBy(s => s.Name).ToList();

            if ((string.IsNullOrEmpty(SelectedClass) || SelectedClass == "All") &&
                    (string.IsNullOrEmpty(SelectedRace) || SelectedRace == "All") &&
                    (string.IsNullOrEmpty(SelectedBackground) || SelectedBackground == "All") &&
                    (string.IsNullOrEmpty(SelectedSource) || SelectedSource == "All") &&
                    (string.IsNullOrEmpty(SearchText)))
            {
                // No filters
                foreach (var t in orderedAbilities)
                    Abilities.Add(t);
            }
            else
            {
                var result = new List<Ability>();

                // Filter behavior:
                // (class || race || background) && source && search
                if (!string.IsNullOrEmpty(SelectedClass) && SelectedClass != "All")
                {
                    var selectedClassEnum = (FilterLists.DndClass)Enum.Parse(typeof(FilterLists.DndClass), SelectedClass);
                    var abilities = orderedAbilities.Where(t => (t.Class & (int)selectedClassEnum) != 0).ToList();
                    foreach (var t in abilities)
                        result.Add(t);
                }
                if (!string.IsNullOrEmpty(SelectedRace) && SelectedRace != "All")
                {
                    var selectedRaceEnum = (FilterLists.Race)Enum.Parse(typeof(FilterLists.Race), SelectedRace);
                    var abilities = orderedAbilities.Where(t => (t.Race & (int)selectedRaceEnum) != 0).ToList();
                    foreach (var t in abilities)
                        result.Add(t);
                }
                if (!string.IsNullOrEmpty(SelectedBackground) && SelectedBackground != "All")
                {
                    var selectedBackgroundEnum = (FilterLists.Background)Enum.Parse(typeof(FilterLists.Background), SelectedBackground);
                    var abilities = orderedAbilities.Where(t => (t.Background & (int)selectedBackgroundEnum) != 0).ToList();
                    foreach (var t in abilities)
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
                    Abilities.Add(t);
            }
        }
    }
}
