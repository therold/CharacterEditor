using TBH.DND.Android.Views;

namespace TBH.DND.Android
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("SpellEditorPage", typeof(SpellEditorPage));
            // Register route for AllSpellsPage so Shell navigation can navigate to it by route name.
            Routing.RegisterRoute("AllSpellsPage", typeof(TBH.DND.Android.Views.AllSpellsPage));
        }

        private async void OnAddSpellFlyoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SpellEditorPage");
        }

        private async void OnEditActiveSpellsFlyoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AllSpellsPage");
        }
    }
}
