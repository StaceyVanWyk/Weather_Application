using Microsoft.Extensions.DependencyInjection;

namespace MauiWeather_Application
{
    public partial class App : Application
    {
        public App(AppShell appShell)
        {
            InitializeComponent();
            MainPage = appShell;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(MainPage!);
        }
    }
}