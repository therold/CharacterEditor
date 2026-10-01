using System;
using Microsoft.Maui.Controls;
using TBH.DND.Android.ViewModels;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Views
{
    public partial class SpellAllPage : ContentPage
    {
        private SpellAllViewModel? vm;

        public SpellAllPage()
        {
            InitializeComponent();
            vm = App.Services?.GetService(typeof(SpellAllViewModel)) as SpellAllViewModel;
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void OnActiveToggled(object? sender, ToggledEventArgs e)
        {
            if (sender is Switch sw && sw.BindingContext is Spell spell)
            {
                // Persist the change
                if (vm != null)
                {
                    await vm.SaveSpellAsync(spell);
                }
            }
        }
    }
}
