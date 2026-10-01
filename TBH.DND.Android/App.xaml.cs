using Microsoft.Maui.Handlers;

namespace TBH.DND.Android
{
    public partial class App : Application
    {
        public static IServiceProvider? Services { get; set; }

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}