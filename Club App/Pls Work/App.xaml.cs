using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pls_Work
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            User user = new User(); // Enters as a new user 
            MainPage = new NavigationPage(new MainPage(user)); // Replace MainPage with your actual starting page
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
