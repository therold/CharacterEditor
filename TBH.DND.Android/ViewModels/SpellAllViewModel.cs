using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;

namespace TBH.DND.Android.ViewModels
{
    public class SpellAllViewModel : BindableObject
    {
        readonly SpellDatabase db;

        public Array Classes { get; } = Enum.GetNames(typeof(Spell.SpellClass)).Prepend("All").ToArray();

        private string selectedClass;
        public string SelectedClass
        {
            get => selectedClass;
            set
            {
                if (selectedClass == value) return;
                selectedClass = value;
                this.LoadAsync();
                OnPropertyChanged(nameof(SelectedClass));
            }
        }
        public ObservableCollection<Spell> Spells { get; } = new ObservableCollection<Spell>();

        public SpellAllViewModel(SpellDatabase database)
        {
            db = database;
            this.SelectedClass = "All";
        }

        public async Task LoadAsync()
        {
            Spells.Clear();
            var items = await db.GetAllSpellsAsync();
            foreach (var s in items)
            {
                if (SelectedClass == "All")
                {
                    Spells.Add(s);
                }
                else
                {
                    var selectedClassEnum = (Spell.SpellClass)Enum.Parse(typeof(Spell.SpellClass), SelectedClass);
                    if ((s.Class & (int)selectedClassEnum) != 0)
                    {
                        Spells.Add(s);
                    }
                }
            }
        }

        public async Task SaveSpellAsync(Spell s)
        {
            await db.SaveSpellAsync(s);
        }
    }
}
