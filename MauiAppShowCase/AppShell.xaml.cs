using MauiAppShowCase.View;

namespace MauiAppShowCase
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //nameof(DetailsPage) == "DetailsPage"
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(LoginPage),typeof(LoginPage));
            Routing.RegisterRoute(nameof(ProductManagePage), typeof(ProductManagePage));
            
        }
    }
}