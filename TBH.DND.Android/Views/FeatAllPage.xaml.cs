using TBH.DND.Android.Models;
using TBH.DND.Android.ViewModels;

namespace TBH.DND.Android.Views;

public partial class FeatAllPage : ContentPage
{
    private FeatAllViewModel? vm;

    public FeatAllPage()
    {
        InitializeComponent();
        vm = App.Services?.GetService(typeof(FeatAllViewModel)) as FeatAllViewModel;
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
        if (sender is Switch sw && sw.BindingContext is Feat feat)
        {
            // Persist the change
            if (vm != null)
            {
                await vm.SaveFeatAsync(feat);
            }
        }
    }
    private async void OnAddClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("FeatEditorPage");
    }
    private async void OnEnableClicked(object? sender, EventArgs e)
    {
        if (vm != null)
        {
            var feats = vm.Feats.ToList();
            foreach (var f in feats)
            {
                f.Active = true;
                await vm.SaveFeatAsync(f);
            }
            vm.LoadAsync();
        }
    }
    private async void OnDisableClicked(object? sender, EventArgs e)
    {
        if (vm != null)
        {
            var feats = vm.Feats.ToList();
            foreach (var f in feats)
            {
                f.Active = false;
                await vm.SaveFeatAsync(f);
            }
            vm.LoadAsync();
        }
    }
    private async void OnEditSwipeItemInvoked(object? sender, EventArgs e)
    {
        if (sender is SwipeItem si)
        {
            if (si.CommandParameter is Feat f)
            {
                await Shell.Current.GoToAsync($"FeatEditorPage?id={f.Id}");
                // Persist the change
                if (vm != null)
                {
                    await vm.SaveFeatAsync(f);
                }
            }
        }
    }

    private async void OnDeleteSwipeItemInvoked(object? sender, EventArgs e)
    {
        var si = sender as SwipeItem;
        if (si != null)
        {
            if (si.CommandParameter is Feat f && vm != null)
            {
                var ok = await DisplayAlertAsync("Delete", $"Delete '{f.Name}'?", "Delete", "Cancel");
                if (!ok)
                    return;
                await vm.DeleteFeatAsync(f);
            }
        }
    }
    private async void OnItemTapped(object? sender, EventArgs e)
    {
        var ve = sender as VisualElement;
        if (ve != null)
        {
            if (ve.BindingContext is Feat f)
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