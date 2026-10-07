using TBH.DND.Android.Models;
using TBH.DND.Android.ViewModels;

namespace TBH.DND.Android.Views;

public partial class TraitAllPage : ContentPage
{
    private TraitAllViewModel? vm;

    public TraitAllPage()
    {
        InitializeComponent();
        vm = App.Services?.GetService(typeof(TraitAllViewModel)) as TraitAllViewModel;
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
        if (sender is Switch sw && sw.BindingContext is Trait trait)
        {
            // Persist the change
            if (vm != null)
            {
                await vm.SaveTraitAsync(trait);
            }
        }
    }
    private async void OnAddClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("TraitEditorPage");
    }
    private async void OnEnableClicked(object? sender, EventArgs e)
    {
        if (vm != null)
        {
            var traits = vm.Traits.ToList();
            foreach (var t in traits)
            {
                t.Active = true;
                await vm.SaveTraitAsync(t);
            }
            vm.LoadAsync();
        }
    }
    private async void OnDisableClicked(object? sender, EventArgs e)
    {
        if (vm != null)
        {
            var traits = vm.Traits.ToList();
            foreach (var t in traits)
            {
                t.Active = false;
                await vm.SaveTraitAsync(t);
            }
            vm.LoadAsync();
        }
    }
    private async void OnEditSwipeItemInvoked(object? sender, EventArgs e)
    {
        if (sender is SwipeItem si)
        {
            if (si.CommandParameter is Trait t)
            {
                await Shell.Current.GoToAsync($"TraitEditorPage?id={t.Id}");
                // Persist the change
                if (vm != null)
                {
                    await vm.SaveTraitAsync(t);
                }
            }
        }
    }

    private async void OnDeleteSwipeItemInvoked(object? sender, EventArgs e)
    {
        var si = sender as SwipeItem;
        if (si != null)
        {
            if (si.CommandParameter is Trait t && vm != null)
            {
                var ok = await DisplayAlertAsync("Delete", $"Delete '{t.Name}'?", "Delete", "Cancel");
                if (!ok)
                    return;
                await vm.DeleteTraitAsync(t);
            }
        }
    }
    private async void OnItemTapped(object? sender, EventArgs e)
    {
        var ve = sender as VisualElement;
        if (ve != null)
        {
            if (ve.BindingContext is Trait t)
            {
                t.IsExpanded = !t.IsExpanded;
            }
        }
    }
}