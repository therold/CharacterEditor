using System.Windows.Input;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;
using static TBH.DND.Android.Models.FilterLists;

namespace TBH.DND.Android.ViewModels
{
    public class TraitEditorViewModel : BindableObject
    {
        readonly TraitDatabase db;
        public Array Sources { get; } = Enum.GetValues(typeof(FilterLists.Source));
        private FilterLists.Source selectedSource;
        public FilterLists.Source SelectedSource
        {
            get => selectedSource;
            set
            {
                if (selectedSource == value) return;
                selectedSource = value;
                // keep Current.Source (string) in sync for persistence
                Current.Source = selectedSource.ToString();
                OnPropertyChanged(nameof(SelectedSource));
            }
        }

        public Trait Current { get; set; } = new Trait();

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public TraitEditorViewModel(TraitDatabase database)
        {
            db = database;
            SaveCommand = new Command(async () => await SaveAsync());
            CancelCommand = new Command(async () => await Shell.Current.GoToAsync(".."));
        }

        #region Classes
        public bool ClassArtificer
        {
            get => (Current.Class & (int)FilterLists.DndClass.Artificer) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)FilterLists.DndClass.Artificer;
                else
                    Current.Class &= ~(int)FilterLists.DndClass.Artificer;
                OnPropertyChanged(nameof(ClassArtificer));
            }
        }
        public bool ClassBard
        {
            get => (Current.Class & (int)FilterLists.DndClass.Bard) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)FilterLists.DndClass.Bard;
                else
                    Current.Class &= ~(int)FilterLists.DndClass.Bard;
                OnPropertyChanged(nameof(ClassBard));
            }
        }
        public bool ClassCleric
        {
            get => (Current.Class & (int)FilterLists.DndClass.Cleric) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)FilterLists.DndClass.Cleric;
                else
                    Current.Class &= ~(int)FilterLists.DndClass.Cleric;
                OnPropertyChanged(nameof(ClassCleric));
            }
        }
        public bool ClassDruid
        {
            get => (Current.Class & (int)FilterLists.DndClass.Druid) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)FilterLists.DndClass.Druid;
                else
                    Current.Class &= ~(int)FilterLists.DndClass.Druid;
                OnPropertyChanged(nameof(ClassDruid));
            }
        }

        public bool ClassMonk
        {
            get => (Current.Class & (int)FilterLists.DndClass.Monk) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)FilterLists.DndClass.Monk;
                else
                    Current.Class &= ~(int)FilterLists.DndClass.Monk;
                OnPropertyChanged(nameof(ClassMonk));
            }
        }
        public bool ClassPaladin
        {
            get => (Current.Class & (int)FilterLists.DndClass.Paladin) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)FilterLists.DndClass.Paladin;
                else
                    Current.Class &= ~(int)FilterLists.DndClass.Paladin;
                OnPropertyChanged(nameof(ClassPaladin));
            }
        }
        public bool ClassRanger
        {
            get => (Current.Class & (int)FilterLists.DndClass.Ranger) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)FilterLists.DndClass.Ranger;
                else
                    Current.Class &= ~(int)FilterLists.DndClass.Ranger;
                OnPropertyChanged(nameof(ClassRanger));
            }
        }
        public bool ClassSorcerer
        {
            get => (Current.Class & (int)FilterLists.DndClass.Sorcerer) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)FilterLists.DndClass.Sorcerer;
                else
                    Current.Class &= ~(int)FilterLists.DndClass.Sorcerer;
                OnPropertyChanged(nameof(ClassSorcerer));
            }
        }
        public bool ClassWarlock
        {
            get => (Current.Class & (int)FilterLists.DndClass.Warlock) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)FilterLists.DndClass.Warlock;
                else
                    Current.Class &= ~(int)FilterLists.DndClass.Warlock;
                OnPropertyChanged(nameof(ClassWarlock));
            }
        }
        public bool ClassWizard
        {
            get => (Current.Class & (int)FilterLists.DndClass.Wizard) != 0;
            set
            {
                if (value)
                    Current.Class |= (int)FilterLists.DndClass.Wizard;
                else
                    Current.Class &= ~(int)FilterLists.DndClass.Wizard;
                OnPropertyChanged(nameof(ClassWizard));
            }
        }
        #endregion

        #region Races

        public bool RaceDwarf
        {
            get => (Current.Race & (int)FilterLists.Race.Dwarf) != 0;
            set
            {
                if (value)
                    Current.Race |= (int)FilterLists.Race.Dwarf;
                else
                    Current.Race &= ~(int)FilterLists.Race.Dwarf;
                OnPropertyChanged(nameof(RaceDwarf));
            }
        }

        public bool RaceElf
        {
            get => (Current.Race & (int)FilterLists.Race.Elf) != 0;
            set
            {
                if (value)
                    Current.Race |= (int)FilterLists.Race.Elf;
                else
                    Current.Race &= ~(int)FilterLists.Race.Elf;
                OnPropertyChanged(nameof(RaceElf));
            }
        }

        public bool RaceHalfling
        {
            get => (Current.Race & (int)FilterLists.Race.Halfling) != 0;
            set
            {
                if (value)
                    Current.Race |= (int)FilterLists.Race.Halfling;
                else
                    Current.Race &= ~(int)FilterLists.Race.Halfling;
                OnPropertyChanged(nameof(RaceHalfling));
            }
        }

        public bool RaceHuman
        {
            get => (Current.Race & (int)FilterLists.Race.Human) != 0;
            set
            {
                if (value)
                    Current.Race |= (int)FilterLists.Race.Human;
                else
                    Current.Race &= ~(int)FilterLists.Race.Human;
                OnPropertyChanged(nameof(RaceHuman));
            }
        }

        public bool RaceDragonborn
        {
            get => (Current.Race & (int)FilterLists.Race.Dragonborn) != 0;
            set
            {
                if (value)
                    Current.Race |= (int)FilterLists.Race.Dragonborn;
                else
                    Current.Race &= ~(int)FilterLists.Race.Dragonborn;
                OnPropertyChanged(nameof(RaceDragonborn));
            }
        }

        public bool RaceGnome
        {
            get => (Current.Race & (int)FilterLists.Race.Gnome) != 0;
            set
            {
                if (value)
                    Current.Race |= (int)FilterLists.Race.Gnome;
                else
                    Current.Race &= ~(int)FilterLists.Race.Gnome;
                OnPropertyChanged(nameof(RaceGnome));
            }
        }

        public bool RaceHalfElf
        {
            get => (Current.Race & (int)FilterLists.Race.HalfElf) != 0;
            set
            {
                if (value)
                    Current.Race |= (int)FilterLists.Race.HalfElf;
                else
                    Current.Race &= ~(int)FilterLists.Race.HalfElf;
                OnPropertyChanged(nameof(RaceHalfElf));
            }
        }

        public bool RaceHalfOrc
        {
            get => (Current.Race & (int)FilterLists.Race.HalfOrc) != 0;
            set
            {
                if (value)
                    Current.Race |= (int)FilterLists.Race.HalfOrc;
                else
                    Current.Race &= ~(int)FilterLists.Race.HalfOrc;
                OnPropertyChanged(nameof(RaceHalfOrc));
            }
        }

        public bool RaceTiefling
        {
            get => (Current.Race & (int)FilterLists.Race.Tiefling) != 0;
            set
            {
                if (value)
                    Current.Race |= (int)FilterLists.Race.Tiefling;
                else
                    Current.Race &= ~(int)FilterLists.Race.Tiefling;
                OnPropertyChanged(nameof(RaceTiefling));
            }
        }
        #endregion

        #region Backgrounds

        public bool BackgroundAcolyte
        {
            get => (Current.Background & (int)FilterLists.Background.Acolyte) != 0;
            set
            {
                if (value)
                    Current.Background |= (int)FilterLists.Background.Acolyte;
                else
                    Current.Background &= ~(int)FilterLists.Background.Acolyte;
                OnPropertyChanged(nameof(BackgroundAcolyte));
            }
        }
        public bool BackgroundCharlatan
        {
            get => (Current.Background & (int)FilterLists.Background.Charlatan) != 0;
            set
            {
                if (value)
                    Current.Background |= (int)FilterLists.Background.Charlatan;
                else
                    Current.Background &= ~(int)FilterLists.Background.Charlatan;
                OnPropertyChanged(nameof(BackgroundCharlatan));
            }
        }
        public bool BackgroundCriminal
        {
            get => (Current.Background & (int)FilterLists.Background.Criminal) != 0;
            set
            {
                if (value)
                    Current.Background |= (int)FilterLists.Background.Criminal;
                else
                    Current.Background &= ~(int)FilterLists.Background.Criminal;
                OnPropertyChanged(nameof(BackgroundCriminal));
            }
        }
        public bool BackgroundEntertainer
        {
            get => (Current.Background & (int)FilterLists.Background.Entertainer) != 0;
            set
            {
                if (value)
                    Current.Background |= (int)FilterLists.Background.Entertainer;
                else
                    Current.Background &= ~(int)FilterLists.Background.Entertainer;
                OnPropertyChanged(nameof(BackgroundEntertainer));
            }
        }
        public bool BackgroundGuildArtisan
        {
            get => (Current.Background & (int)FilterLists.Background.GuildArtisan) != 0;
            set
            {
                if (value)
                    Current.Background |= (int)FilterLists.Background.GuildArtisan;
                else
                    Current.Background &= ~(int)FilterLists.Background.GuildArtisan;
                OnPropertyChanged(nameof(BackgroundGuildArtisan));
            }
        }
        public bool BackgroundHermit
        {
            get => (Current.Background & (int)FilterLists.Background.Hermit) != 0;
            set
            {
                if (value)
                    Current.Background |= (int)FilterLists.Background.Hermit;
                else
                    Current.Background &= ~(int)FilterLists.Background.Hermit;
                OnPropertyChanged(nameof(BackgroundHermit));
            }
        }
        public bool BackgroundNoble
        {
            get => (Current.Background & (int)FilterLists.Background.Noble) != 0;
            set
            {
                if (value)
                    Current.Background |= (int)FilterLists.Background.Noble;
                else
                    Current.Background &= ~(int)FilterLists.Background.Noble;
                OnPropertyChanged(nameof(BackgroundNoble));
            }
        }
        public bool BackgroundOutlander
        {
            get => (Current.Background & (int)FilterLists.Background.Outlander) != 0;
            set
            {
                if (value)
                    Current.Background |= (int)FilterLists.Background.Outlander;
                else
                    Current.Background &= ~(int)FilterLists.Background.Outlander;
                OnPropertyChanged(nameof(BackgroundOutlander));
            }
        }
        public bool BackgroundSage
        {
            get => (Current.Background & (int)FilterLists.Background.Sage) != 0;
            set
            {
                if (value)
                    Current.Background |= (int)FilterLists.Background.Sage;
                else
                    Current.Background &= ~(int)FilterLists.Background.Sage;
                OnPropertyChanged(nameof(BackgroundSage));
            }
        }
        public bool BackgroundSailor
        {
            get => (Current.Background & (int)FilterLists.Background.Sailor) != 0;
            set
            {
                if (value)
                    Current.Background |= (int)FilterLists.Background.Sailor;
                else
                    Current.Background &= ~(int)FilterLists.Background.Sailor;
                OnPropertyChanged(nameof(BackgroundSailor));
            }
        }
        public bool BackgroundSoldier
        {
            get => (Current.Background & (int)FilterLists.Background.Soldier) != 0;
            set
            {
                if (value)
                    Current.Background |= (int)FilterLists.Background.Soldier;
                else
                    Current.Background &= ~(int)FilterLists.Background.Soldier;
                OnPropertyChanged(nameof(BackgroundSoldier));
            }
        }
        public bool BackgroundUrchin
        {
            get => (Current.Background & (int)FilterLists.Background.Urchin) != 0;
            set
            {
                if (value)
                    Current.Background |= (int)FilterLists.Background.Urchin;
                else
                    Current.Background &= ~(int)FilterLists.Background.Urchin;
                OnPropertyChanged(nameof(BackgroundUrchin));
            }
        }
        #endregion

        public async Task LoadAsync(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var t = await db.GetTraitAsync(id.Value);
                if (t != null)
                {
                    Current = t;
                    if (!Enum.TryParse<FilterLists.Source>(Current.Source, out var parsedSource))
                        parsedSource = (FilterLists.Source)Sources.GetValue(0);
                    selectedSource = parsedSource;
                    OnPropertyChanged(nameof(Current));
                    OnPropertyChanged(nameof(SelectedSource));

                    OnPropertyChanged(nameof(ClassArtificer));
                    OnPropertyChanged(nameof(ClassBard));
                    OnPropertyChanged(nameof(ClassCleric));
                    OnPropertyChanged(nameof(ClassDruid));
                    OnPropertyChanged(nameof(ClassPaladin));
                    OnPropertyChanged(nameof(ClassRanger));
                    OnPropertyChanged(nameof(ClassSorcerer));
                    OnPropertyChanged(nameof(ClassMonk));
                    OnPropertyChanged(nameof(ClassWarlock));
                    OnPropertyChanged(nameof(ClassWizard));

                    OnPropertyChanged(nameof(RaceDwarf));
                    OnPropertyChanged(nameof(RaceElf));
                    OnPropertyChanged(nameof(RaceHalfling));
                    OnPropertyChanged(nameof(RaceHuman));
                    OnPropertyChanged(nameof(RaceDragonborn));
                    OnPropertyChanged(nameof(RaceGnome));
                    OnPropertyChanged(nameof(RaceHalfElf));
                    OnPropertyChanged(nameof(RaceHalfOrc));
                    OnPropertyChanged(nameof(RaceTiefling));

                    OnPropertyChanged(nameof(BackgroundAcolyte));
                    OnPropertyChanged(nameof(BackgroundCharlatan));
                    OnPropertyChanged(nameof(BackgroundCriminal));
                    OnPropertyChanged(nameof(BackgroundEntertainer));
                    OnPropertyChanged(nameof(BackgroundGuildArtisan));
                    OnPropertyChanged(nameof(BackgroundHermit));
                    OnPropertyChanged(nameof(BackgroundNoble));
                    OnPropertyChanged(nameof(BackgroundOutlander));
                    OnPropertyChanged(nameof(BackgroundSage));
                    OnPropertyChanged(nameof(BackgroundSailor));
                    OnPropertyChanged(nameof(BackgroundSoldier));
                    OnPropertyChanged(nameof(BackgroundUrchin));
                }
            }
            else
            {
                Current = new Trait();
                selectedSource = (FilterLists.Source)Sources.GetValue(0);
                OnPropertyChanged(nameof(Current));
                OnPropertyChanged(nameof(SelectedSource));
            }
        }

        async Task SaveAsync()
        {
            await db.SaveTraitAsync(Current);
            // rely on MainPage.OnAppearing to refresh the list
            await Shell.Current.GoToAsync("..");
        }
    }
}
