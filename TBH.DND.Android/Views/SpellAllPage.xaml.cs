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
                    await vm.SaveSpellAsync(spell);
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
                    if (s.IsExpanded)
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
                        await vm.SaveSpellAsync(s);
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
    }
}
