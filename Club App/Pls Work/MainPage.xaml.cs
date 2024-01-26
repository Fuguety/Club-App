using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pls_Work
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }
        
        async void AddUsers(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddUser());
        }


        
        async void UserList(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new List());
        }
    }
}
