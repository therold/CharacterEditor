using TBH.DND.Android.Models;
using TBH.DND.Android.ViewModels;

namespace TBH.DND.Android.Views;

[QueryProperty(nameof(AbilityId), "id")]
public partial class AbilityEditorPage : ContentPage
{
    private AbilityEditorViewModel? vm;

    private string abilityId = string.Empty;
    public string AbilityId
    {
        get => abilityId;
        set
        {
            abilityId = value;
            if (int.TryParse(abilityId, out var id))
            {
                vm?.LoadAsync(id);
            }
            else
            {
                vm?.LoadAsync(null);
            }
        }
    }

    public AbilityEditorPage()
    {
        InitializeComponent();
        vm = App.Services?.GetService(typeof(AbilityEditorViewModel)) as AbilityEditorViewModel;
        BindingContext = vm;
    }
}