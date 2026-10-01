using Microsoft.Maui.Controls;
using TBH.DND.Android.ViewModels;
using TBH.DND.Android.Models;
using TBH.DND.Android.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace TBH.DND.Android
{
    public partial class MainPage : ContentPage
    {
        private SpellListViewModel? vm;
        private SpellDatabase? db;

        public MainPage()
        {
            InitializeComponent();
            vm = App.Services?.GetService(typeof(SpellListViewModel)) as SpellListViewModel;
            db = App.Services?.GetService(typeof(SpellDatabase)) as SpellDatabase;
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (vm != null)
                await vm.LoadAsync();
        }

        private async void OnAddSpellClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SpellEditorPage");
        }

        private async void OnEditSpellListClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AllSpellsPage");
        }

         private void OnItemTapped(object? sender, EventArgs e)
        {
            if (sender is VisualElement ve && ve.BindingContext is Spell s)
            {
                s.IsExpanded = !s.IsExpanded;
            }
        }

        private async void OnEditSwipeItemInvoked(object? sender, EventArgs e)
        {
            if (sender is SwipeItem si)
            {
                if (si.CommandParameter is Spell s)
                {
                    await Shell.Current.GoToAsync($"SpellEditorPage?id={s.Id}");
                }
            }
        }

        private async void OnDeleteSwipeItemInvoked(object? sender, EventArgs e)
        {
            if (sender is SwipeItem si && si.CommandParameter is Spell s)
            {
                var ok = await DisplayAlertAsync("Delete", $"Delete '{s.Name}'?", "Delete", "Cancel");
                if (!ok)
                    return;

                if (db != null)
                {
                    await db.DeleteSpellAsync(s.Id);
                    if (vm != null)
                        await vm.LoadAsync();
                }
            }
        }

        private async void OnHeaderMenuClicked(object? sender, EventArgs e)
        {
            var action = await DisplayActionSheetAsync("Menu", "Cancel", null, "Add Spell", "Edit Spell List", "Expand All", "Collapse All");
            if (action == "Add Spell")
            {
                await Shell.Current.GoToAsync("SpellEditorPage");
            }
            else if (action == "Edit Spell List")
            {
                await Shell.Current.GoToAsync("AllSpellsPage");
            }
            else if (action == "Expand All")
            {
                if (vm != null)
                {
                    foreach (var spell in vm.Spells)
                    {
                        spell.IsExpanded = true;
                    }
                }
            }
            else if (action == "Collapse All")
            {
                if (vm != null)
                {
                    foreach (var spell in vm.Spells)
                    {
                        spell.IsExpanded = false;
                    }
                }
            }
        }
    }
}
