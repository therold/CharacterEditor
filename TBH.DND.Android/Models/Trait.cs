using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TBH.DND.Android.Models
{
    public class Trait : BaseModel
    {
        public int Id { get; set; }

        private string name = string.Empty;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        private int @class;
        public int Class
        {
            get => @class;
            set => SetProperty(ref @class, value);
        }
        private int race;
        public int Race
        {
            get => race;
            set => SetProperty(ref race, value);
        }
        private int background;
        public int Background
        {
            get => background;
            set => SetProperty(ref background, value);
        }

        private string description = string.Empty;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private string source = string.Empty;
        public string Source
        {
            get => source;
            set => SetProperty(ref source, value);
        }

        private bool active;
        public bool Active
        {
            get => active;
            set => SetProperty(ref active, value);
        }

    }
}
