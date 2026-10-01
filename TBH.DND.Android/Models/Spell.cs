using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TBH.DND.Android.Models
{
    public class Spell : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string name = string.Empty;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private int level;
        public int Level
        {
            get => level;
            set => SetProperty(ref level, value);
        }

        public string LevelDisplay => Level == 0 ? "Cantrip" : $"{Level}";

        private string @class = string.Empty;
        public string Class
        {
            get => @class;
            set => SetProperty(ref @class, value);
        }

        private string school = string.Empty;
        public string School
        {
            get => school;
            set => SetProperty(ref school, value);
        }

        private string castingTime = string.Empty;
        public string CastingTime
        {
            get => castingTime;
            set => SetProperty(ref castingTime, value);
        }

        private string range = string.Empty;
        public string Range
        {
            get => range;
            set => SetProperty(ref range, value);
        }

        private string components = string.Empty;
        public string Components
        {
            get => components;
            set => SetProperty(ref components, value);
        }

        private string duration = string.Empty;
        public string Duration
        {
            get => duration;
            set => SetProperty(ref duration, value);
        }

        private string description = string.Empty;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private bool active;
        public bool Active
        {
            get => active;
            set => SetProperty(ref active, value);
        }

        public enum SpellSchool
        {
            Abjuration,
            Conjuration,
            Divination,
            Enchantment,
            Evocation,
            Illusion,
            Necromancy,
            Transmutation
        }

        // UI property, not persisted
        private bool isExpanded;
        public bool IsExpanded
        {
            get => isExpanded;
            set => SetProperty(ref isExpanded, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
