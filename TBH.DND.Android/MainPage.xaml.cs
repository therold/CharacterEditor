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
        private MainPageViewModel? vm;
        private SpellDatabase? db;
        private FeatDatabase? featDb;

        public MainPage()
        {
            InitializeComponent();
            vm = App.Services?.GetService(typeof(MainPageViewModel)) as MainPageViewModel;
            db = App.Services?.GetService(typeof(SpellDatabase)) as SpellDatabase;
            featDb = App.Services?.GetService(typeof(FeatDatabase)) as FeatDatabase;
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (vm != null)
                await vm.LoadAsync();
        }

         private void OnItemTapped(object? sender, EventArgs e)
        {
            var ve = sender as VisualElement;
            if (ve != null)
            {
                if (ve.BindingContext is Spell s)
                {
                    s.IsExpanded = !s.IsExpanded;
                }
                else if (ve.BindingContext is Feat f)
                {
                    f.IsExpanded = !f.IsExpanded;
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
                }
                else if (si.CommandParameter is Feat f)
                {
                    // TODO
                    //await Shell.Current.GoToAsync($"SpellEditorPage?id={s.Id}");
                }
            }
        }

        private async void OnDeleteSwipeItemInvoked(object? sender, EventArgs e)
        {
            var si = sender as SwipeItem;
            if (si != null)
            {
                if (si.CommandParameter is Spell s && db != null)
                {
                    var ok = await DisplayAlertAsync("Delete", $"Delete '{s.Name}'?", "Delete", "Cancel");
                    if (!ok)
                        return;
                    await db.DeleteSpellAsync(s.Id);
                }
                else if (si.CommandParameter is Feat f && featDb != null)
                {
                    var ok = await DisplayAlertAsync("Delete", $"Delete '{f.Name}'?", "Delete", "Cancel");
                    if (!ok)
                        return;
                    await featDb.DeleteFeatAsync(f.Id);
                }

                if (vm != null)
                    await vm.LoadAsync();
            }
            
        }

        private async void OnHeaderMenuClicked(object? sender, EventArgs e)
        {
            var action = await DisplayActionSheetAsync("Menu", "Cancel", null, "Add Spell", "Edit Spells", "Expand All", "Collapse All");
            if (action == "Add Spell")
            {
                await Shell.Current.GoToAsync("SpellEditorPage");
            }
            else if (action == "Edit Spells")
            {
                await Shell.Current.GoToAsync("SpellAllPage");
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

        private async void OnFeatHeaderMenuClicked(object? sender, EventArgs e)
        {
            var action = await DisplayActionSheetAsync("Menu", "Cancel", null, "Add Feat", "Edit Feats", "Expand All", "Collapse All");
            if (action == "Add Feat")
            {
                await Shell.Current.GoToAsync("FeatEditorPage");
            }
            else if (action == "Edit Feats")
            {
                await Shell.Current.GoToAsync("FeatAllPage");
            }
            else if (action == "Expand All")
            {
                if (vm != null)
                {
                    foreach (var feat in vm.Feats)
                    {
                        feat.IsExpanded = true;
                    }
                }
            }
            else if (action == "Collapse All")
            {
                if (vm != null)
                {
                    foreach (var feat in vm.Feats)
                    {
                        feat.IsExpanded = false;
                    }
                }
            }
        }
    }
}
