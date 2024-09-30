using MauiApp2.Pages;

namespace MauiApp2
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            // Retrieve MainPage from the service provider
            MainPage = serviceProvider.GetRequiredService<Pages.MainPage>();
        }
    }
}
