using TBH.DND.Android.Views;

namespace TBH.DND.Android
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("FeatAllPage", typeof(FeatAllPage));
            Routing.RegisterRoute("FeatEditorPage", typeof(FeatEditorPage));
            Routing.RegisterRoute("AbilityAllPage", typeof(AbilityAllPage));
            Routing.RegisterRoute("AbilityEditorPage", typeof(AbilityEditorPage));
            Routing.RegisterRoute("SpellAllPage", typeof(SpellAllPage));
            Routing.RegisterRoute("SpellEditorPage", typeof(SpellEditorPage));
            Routing.RegisterRoute("TraitAllPage", typeof(TraitAllPage));
            Routing.RegisterRoute("TraitEditorPage", typeof(TraitEditorPage));
            Routing.RegisterRoute("CharacterEditorPage", typeof(CharacterEditorPage));
        }
    }
}
