using TBH.DND.Android.Models;
using TBH.DND.Android.ViewModels;

namespace TBH.DND.Android.Views;

[QueryProperty(nameof(FeatId), "id")]
public partial class FeatEditorPage : ContentPage
{
    private FeatEditorViewModel? vm;

    private string featId = string.Empty;
    public string FeatId
    {
        get => featId;
        set
        {
            featId = value;
            if (int.TryParse(featId, out var id))
            {
                vm?.LoadAsync(id);
            }
            else
            {
                vm?.LoadAsync(null);
            }
        }
    }

    public FeatEditorPage()
	{
		InitializeComponent();
        vm = App.Services?.GetService(typeof(FeatEditorViewModel)) as FeatEditorViewModel;
        BindingContext = vm;
    }
}