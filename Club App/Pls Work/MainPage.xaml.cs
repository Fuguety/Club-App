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
        User currentUser;

        public MainPage(User user)
        {
            InitializeComponent();
            currentUser = user;
        }
        
        async void AddUsers(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddUser());
        }

        
        async void Activities(System.Object sender, System.EventArgs e)
        {

            if (User.users.Count > 0)
            {
                User currentUser = User.users.Last(); // Get recent user
                await Navigation.PushAsync(new Activities(currentUser));
            }
            else
            {
                await DisplayAlert("Error", "No current user selected", "Close");
            }
        }

        
        async void UserList(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new List(User.users));
        }
    }
}
