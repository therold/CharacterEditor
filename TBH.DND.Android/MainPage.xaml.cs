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

         private async void OnItemTapped(object? sender, EventArgs e)
        {
            var ve = sender as VisualElement;
            if (ve != null)
            {
                if (ve.BindingContext is Spell s)
                {
                    s.IsExpanded = !s.IsExpanded;
                    if (s.IsExpanded)
                    {
                        var webView = ve.FindByName<WebView>("webView");
                        if (webView != null)
                        {
                            await webViewVisible(webView);
                        }
                    }
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
                    await Shell.Current.GoToAsync($"FeatEditorPage?id={f.Id}");
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
                var spellsView = this.FindByName<CollectionView>("SpellsView");
                var webViews = spellsView.GetVisualTreeDescendants().OfType<WebView>().Where(x => x.BindingContext is Spell).ToList();
                foreach (var view in webViews)
                    await webViewVisible(view);
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

        private async Task webViewVisible(WebView webView)
        {
            if (webView != null)
            {
                Thread.Sleep(50);
                webView.HeightRequest = 1;
                Thread.Sleep(50);
                var height = await webView.EvaluateJavaScriptAsync("document.documentElement.scrollHeight");
                // Query the document for its full height (cover several properties for reliability)
                var js = "Math.max(document.body.scrollHeight, document.documentElement.scrollHeight, document.body.offsetHeight, document.documentElement.offsetHeight).toString();";
                var result = await webView.EvaluateJavaScriptAsync(js);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    webView.HeightRequest = Convert.ToDouble(result);
                }
                else
                {
                    // As a fallback, leave the current HeightRequest or set a reasonable default
                    webView.HeightRequest = Math.Max(webView.HeightRequest, 100);
                }
            }
        }

        private void Grid_Loaded(object sender, EventArgs e)
        {

        }
    }
}
