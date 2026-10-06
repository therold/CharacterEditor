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
}