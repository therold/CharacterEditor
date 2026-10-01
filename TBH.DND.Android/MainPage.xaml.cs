using Microsoft.Maui.Controls;
using TBH.DND.Android.ViewModels;
using TBH.DND.Android.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;

namespace TBH.DND.Android
{
    public partial class MainPage : ContentPage
    {
        SpellListViewModel vm;
        TBH.DND.Android.Services.SpellDatabase db;

        public MainPage()
        {
            InitializeComponent();
            vm = App.Services?.GetService(typeof(SpellListViewModel)) as SpellListViewModel;
            db = App.Services?.GetService(typeof(TBH.DND.Android.Services.SpellDatabase)) as TBH.DND.Android.Services.SpellDatabase;
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (vm != null)
                await vm.LoadAsync();
        }

        //// Handler for the hamburger menu button. Presents a simple action sheet with menu choices.
        //private async void OnMenuClicked(object sender, EventArgs e)
        //{
        //    var action = await DisplayActionSheet("Menu", "Cancel", null, "Add Spell");
        //    if (action == "Add Spell")
        //    {
        //        await Shell.Current.GoToAsync("SpellEditorPage");
        //    }
        //}

        private async void OnAddSpellClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SpellEditorPage");
        }

        private async void OnEditSpellListClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AllSpellsPage");
        }

         private void OnItemTapped(object sender, EventArgs e)
        {
            if (sender is VisualElement ve && ve.BindingContext is Spell s)
            {
                s.IsExpanded = !s.IsExpanded;
            }
        }
        // Pressed/Released handlers removed; using SwipeView Edit action instead for per-item edit.

        //private async void OnEditMenuClicked(object sender, EventArgs e)
        //{
        //    if (sender is MenuFlyoutItem mfi)
        //    {
        //        if (mfi.CommandParameter is Spell s)
        //        {
        //            // navigate and pass the integer Id as query parameter expected by SpellEditorPage
        //            await Shell.Current.GoToAsync($"SpellEditorPage?id={s.Id}");
        //        }
        //    }
        //}

        private async void OnEditSwipeItemInvoked(object sender, EventArgs e)
        {
            if (sender is SwipeItem si)
            {
                if (si.CommandParameter is Spell s)
                {
                    await Shell.Current.GoToAsync($"SpellEditorPage?id={s.Id}");
                }
            }
        }

        private async void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
        {
            if (sender is SwipeItem si && si.CommandParameter is Spell s)
            {
                var ok = await DisplayAlert("Delete", $"Delete '{s.Name}'?", "Delete", "Cancel");
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

        private async void OnHeaderMenuClicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Menu", "Cancel", null, "Add Spell", "Edit Spell List");
            if (action == "Add Spell")
            {
                await Shell.Current.GoToAsync("SpellEditorPage");
            }
            else if (action == "Edit Spell List")
            {
                await Shell.Current.GoToAsync("AllSpellsPage");
            }
        }
    }
}
