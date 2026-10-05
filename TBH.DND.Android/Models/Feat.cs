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
        public HtmlWebViewSource DescriptionHtml => new HtmlWebViewSource
        {
            Html = $"<html><body style=\"color:#FFFFFF;font-size:16px;\">{Description}</body></html>"
        };

        private bool active;
        public bool Active
        {
            get => active;
            set => SetProperty(ref active, value);
        }

    }
}
