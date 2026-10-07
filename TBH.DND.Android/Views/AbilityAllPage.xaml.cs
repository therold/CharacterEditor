using TBH.DND.Android.Models;
using TBH.DND.Android.ViewModels;

namespace TBH.DND.Android.Views;

public partial class AbilityAllPage : ContentPage
{
    private AbilityAllViewModel? vm;

    public AbilityAllPage()
    {
        InitializeComponent();
        vm = App.Services?.GetService(typeof(AbilityAllViewModel)) as AbilityAllViewModel;
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
        if (sender is Switch sw && sw.BindingContext is Ability ability)
        {
            // Persist the change
            if (vm != null)
            {
                await vm.SaveAbilityAsync(ability);
            }
        }
    }
    private async void OnAddClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AbilityEditorPage");
    }
    private async void OnEnableClicked(object? sender, EventArgs e)
    {
        if (vm != null)
        {
            var abilities = vm.Abilities.ToList();
            foreach (var a in abilities)
            {
                a.Active = true;
                await vm.SaveAbilityAsync(a);
            }
            vm.LoadAsync();
        }
    }
    private async void OnDisableClicked(object? sender, EventArgs e)
    {
        if (vm != null)
        {
            var abilities = vm.Abilities.ToList();
            foreach (var a in abilities)
            {
                a.Active = false;
                await vm.SaveAbilityAsync(a);
            }
            vm.LoadAsync();
        }
    }
    private async void OnEditSwipeItemInvoked(object? sender, EventArgs e)
    {
        if (sender is SwipeItem si)
        {
            if (si.CommandParameter is Ability a)
            {
                await Shell.Current.GoToAsync($"AbilityEditorPage?id={a.Id}");
                // Persist the change
                if (vm != null)
                {
                    await vm.SaveAbilityAsync(a);
                }
            }
        }
    }

    private async void OnDeleteSwipeItemInvoked(object? sender, EventArgs e)
    {
        var si = sender as SwipeItem;
        if (si != null)
        {
            if (si.CommandParameter is Ability a && vm != null)
            {
                var ok = await DisplayAlertAsync("Delete", $"Delete '{a.Name}'?", "Delete", "Cancel");
                if (!ok)
                    return;
                await vm.DeleteAbilityAsync(a);
            }
        }
    }
    private async void OnItemTapped(object? sender, EventArgs e)
    {
        var ve = sender as VisualElement;
        if (ve != null)
        {
            if (ve.BindingContext is Ability a)
            {
                a.IsExpanded = !a.IsExpanded;
            }
        }
    }
}