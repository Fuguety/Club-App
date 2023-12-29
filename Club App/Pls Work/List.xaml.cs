using System.Linq;
using Xamarin.Forms;
using System;
using System.Collections.Generic;

namespace Pls_Work
{
    public partial class List : ContentPage
    {
        List<User> userList;
        public List(List<User> users)
        {
            InitializeComponent();

            userListView.ItemsSource = User.users;

            userListView.ItemTemplate = new DataTemplate(() =>
            {
                var fullNameLabel = new Label();

                var stackLayout = new StackLayout
                {
                    Children = { fullNameLabel }
                };

                var viewCell = new ViewCell
                {
                    View = stackLayout
                };

                viewCell.BindingContextChanged += (sender, e) =>
                {
                    if (viewCell.BindingContext is User user)
                    {
                        string fullName = $"{user.name} {user.lastName}";
                        fullNameLabel.Text = fullName;
                    }
                };

                return viewCell;
            });

            userListView.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var selectedUser = e.SelectedItem as User;

                // Navigate to UserDetailsPage and pass the selected user
                await Navigation.PushAsync(new UserDetails(selectedUser));

                // Deselect the item
                userListView.SelectedItem = null;
            };
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            userListView.ItemsSource = null;
            userListView.ItemsSource = User.users;
        }

    }
}
