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
            Routing.RegisterRoute("SpellAllPage", typeof(SpellAllPage));
            Routing.RegisterRoute("SpellEditorPage", typeof(SpellEditorPage));
        }
    }
}
