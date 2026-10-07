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
            if (vm != null)
                await vm.LoadAsync();
        }

        private async void OnActiveToggled(object? sender, ToggledEventArgs e)
        {
            if (sender is Switch sw && sw.BindingContext is Spell spell)
            {
                // Persist the change
                if (vm != null)
                {
                    await vm.SaveSpellAsync(spell, false);
                }
            }
        }
        private async void OnItemTapped(object? sender, EventArgs e)
        {
            var ve = sender as VisualElement;
            if (ve != null)
            {
                if (ve.BindingContext is Spell s)
                {
                    s.IsExpanded = !s.IsExpanded;
                }
            }
        }
        private async void OnEditSwipeItemInvoked(object? sender, EventArgs e)
        {
            if (sender is SwipeItem si)
            {
                if (si.CommandParameter is Spell s)
                {
                    await Shell.Current.GoToAsync($"SpellEditorPage?id={s.Id}");
                    // Persist the change
                    if (vm != null)
                    {
                        await vm.SaveSpellAsync(s, true);
                    }
                }
            }
        }

        private async void OnDeleteSwipeItemInvoked(object? sender, EventArgs e)
        {
            var si = sender as SwipeItem;
            if (si != null)
            {
                if (si.CommandParameter is Spell s && vm != null)
                {
                    var ok = await DisplayAlertAsync("Delete", $"Delete '{s.Name}'?", "Delete", "Cancel");
                    if (!ok)
                        return;
                    await vm.DeleteSpellAsync(s);
                }
            }
        }
        private async void OnAddClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SpellEditorPage");
        }
        private async void OnEnableClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                var spells = vm.Spells.ToList();
                foreach (var s in spells)
                {
                    s.Active = true;
                    await vm.SaveSpellAsync(s, false);
                }
                vm.LoadAsync();
            }
        }
        private async void OnDisableClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                var spells = vm.Spells.ToList();
                foreach (var s in spells)
                {
                    s.Active = false;
                    await vm.SaveSpellAsync(s, false);
                }
                vm.LoadAsync();
            }
        }
        private async void OnSortClicked(object? sender, EventArgs e)
        {
            var action = await DisplayActionSheetAsync("Sort", "Cancel", null, "Level", "Name");
            if (action == "Level")
            {
                //await Shell.Current.GoToAsync("SpellEditorPage");
                vm.SortOrder = "Level";
            }
            else if (action == "Name")
            {
                //await Shell.Current.GoToAsync("SpellEditorPage");
                vm.SortOrder = "Name";
            }
        }
    }
}
