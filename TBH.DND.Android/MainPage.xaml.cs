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
        private AbilityDatabase? abilityDb;
        private FeatDatabase? featDb;

        public MainPage()
        {
            InitializeComponent();
            vm = App.Services?.GetService(typeof(MainPageViewModel)) as MainPageViewModel;
            db = App.Services?.GetService(typeof(SpellDatabase)) as SpellDatabase;
            abilityDb = App.Services?.GetService(typeof(AbilityDatabase)) as AbilityDatabase;
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
                else if (ve.BindingContext is Ability a)
                {
                    a.IsExpanded = !a.IsExpanded;
                    if (a.IsExpanded)
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
                    if (f.IsExpanded)
                    {
                        var webView = ve.FindByName<WebView>("webView");
                        if (webView != null)
                        {
                            await webViewVisible(webView);
                        }
                    }
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
                else if (si.CommandParameter is Ability a)
                {
                    await Shell.Current.GoToAsync($"AbilityEditorPage?id={a.Id}");
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
                else if (si.CommandParameter is Ability a && abilityDb != null)
                {
                    var ok = await DisplayAlertAsync("Delete", $"Delete '{a.Name}'?", "Delete", "Cancel");
                    if (!ok)
                        return;
                    await abilityDb.DeleteAbilityAsync(a.Id);
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
        private async void OnSpellsAllMenuClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SpellAllPage");
        }
        private async void OnSpellsCollapseMenuClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                foreach (var spell in vm.Spells)
                {
                    spell.IsExpanded = false;
                }
            }
        }
        private async void OnSpellsExpandMenuClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                foreach (var spell in vm.Spells)
                {
                    spell.IsExpanded = true;
                }
                var spellsView = this.FindByName<CollectionView>("SpellsView");
                var webViews = spellsView.GetVisualTreeDescendants().OfType<WebView>().Where(x => x.BindingContext is Spell).ToList();
                foreach (var view in webViews)
                    await webViewVisible(view);
            }
        }

        private async void OnAbilitiesAllMenuClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AbilityAllPage");
        }
        private async void OnAbilitiesCollapseMenuClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                foreach (var ability in vm.Abilities)
                {
                    ability.IsExpanded = false;
                }
            }
        }
        private async void OnAbilitiesExpandMenuClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                foreach (var ability in vm.Abilities)
                {
                    ability.IsExpanded = true;
                }
                var abilitiesView = this.FindByName<CollectionView>("AbilitiesView");
                var webViews = abilitiesView.GetVisualTreeDescendants().OfType<WebView>().Where(x => x.BindingContext is Ability).ToList();
                foreach (var view in webViews)
                    await webViewVisible(view);
            }
        }

        private async void OnFeatsAllMenuClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("FeatAllPage");
        }
        private async void OnFeatsCollapseMenuClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                foreach (var feat in vm.Feats)
                {
                    feat.IsExpanded = false;
                }
            }
        }
        private async void OnFeatsExpandMenuClicked(object? sender, EventArgs e)
        {
            if (vm != null)
            {
                foreach (var feat in vm.Feats)
                {
                    feat.IsExpanded = true;
                }
                var featsView = this.FindByName<CollectionView>("FeatsView");
                var webViews = featsView.GetVisualTreeDescendants().OfType<WebView>().Where(x => x.BindingContext is Feat).ToList();
                foreach (var view in webViews)
                    await webViewVisible(view);
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
    }
}
