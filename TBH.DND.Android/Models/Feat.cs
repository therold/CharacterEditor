using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TBH.DND.Android.Models
{
    public class Feat : BaseModel
    {
        public int Id { get; set; }

        private string name = string.Empty;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string description = string.Empty;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

    }
}
