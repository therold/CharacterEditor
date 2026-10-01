using System;
using Microsoft.Maui.Controls;
using TBH.DND.Android.ViewModels;
using TBH.DND.Android.Models;

namespace TBH.DND.Android.Views
{
    public partial class AllSpellsPage : ContentPage
    {
        AllSpellsViewModel vm;

        public AllSpellsPage()
        {
            InitializeComponent();
            vm = App.Services?.GetService(typeof(AllSpellsViewModel)) as AllSpellsViewModel;
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (vm != null)
                await vm.LoadAsync();
        }

        private async void OnActiveToggled(object sender, ToggledEventArgs e)
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
