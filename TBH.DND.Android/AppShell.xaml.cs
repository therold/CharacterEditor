using TBH.DND.Android.Views;

namespace TBH.DND.Android
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("SpellEditorPage", typeof(SpellEditorPage));
            Routing.RegisterRoute("AllSpellsPage", typeof(AllSpellsPage));
        }
    }
}
