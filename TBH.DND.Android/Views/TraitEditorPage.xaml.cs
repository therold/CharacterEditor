using TBH.DND.Android.Models;
using TBH.DND.Android.ViewModels;

namespace TBH.DND.Android.Views;

[QueryProperty(nameof(TraitId), "id")]
public partial class TraitEditorPage : ContentPage
{
    private TraitEditorViewModel? vm;

    private string traitId = string.Empty;
    public string TraitId
    {
        get => traitId;
        set
        {
            traitId = value;
            if (int.TryParse(traitId, out var id))
            {
                vm?.LoadAsync(id);
            }
            else
            {
                vm?.LoadAsync(null);
            }
        }
    }

    public TraitEditorPage()
    {
        InitializeComponent();
        vm = App.Services?.GetService(typeof(TraitEditorViewModel)) as TraitEditorViewModel;
        BindingContext = vm;
    }
}