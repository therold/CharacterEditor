using TBH.DND.Android.Models;
using TBH.DND.Android.ViewModels;

namespace TBH.DND.Android.Views;

[QueryProperty(nameof(CharacterId), "id")]
public partial class CharacterEditorPage : ContentPage
{
    private CharacterEditorViewModel? vm;

    private string characterId = string.Empty;
    public string CharacterId
    {
        get => characterId;
        set
        {
            characterId = value;
            if (int.TryParse(characterId, out var id))
            {
                vm?.LoadAsync(id);
            }
            else
            {
                vm?.LoadAsync(null);
            }
        }
    }

    public CharacterEditorPage()
    {
        InitializeComponent();
        vm = App.Services?.GetService(typeof(CharacterEditorViewModel)) as CharacterEditorViewModel;
        BindingContext = vm;
    }
}