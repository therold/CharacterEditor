using System;
using Microsoft.Maui.Controls;
using TBH.DND.Android.ViewModels;

namespace TBH.DND.Android.Views
{
    [QueryProperty(nameof(SpellId), "id")]
    public partial class SpellEditorPage : ContentPage
    {
        private SpellEditorViewModel? vm;

        private string spellId = string.Empty;
        public string SpellId
        {
            get => spellId;
            set
            {
                spellId = value;
                if (int.TryParse(spellId, out var id))
                {
                    vm?.LoadAsync(id);
                }
                else
                {
                    vm?.LoadAsync(null);
                }
            }
        }

        public SpellEditorPage()
        {
            InitializeComponent();
            vm = App.Services?.GetService(typeof(SpellEditorViewModel)) as SpellEditorViewModel;
            BindingContext = vm;
        }
    }
}
