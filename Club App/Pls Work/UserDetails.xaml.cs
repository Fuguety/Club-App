using Xamarin.Forms;
using System.Linq;
using System;


namespace Pls_Work
{
    public partial class UserDetails : ContentPage
    {
        
        public User currentUser { get; set; }

        public UserDetails(User selectedUser)
        {
            InitializeComponent();
            currentUser = selectedUser;

            BindingContext = this; // Set the binding context to the instance of UserDetails



            nameLabel.Text = $"Name: {currentUser.name}";
            lastNameLabel.Text = $"Last Name: {currentUser.lastName}";
            isPartnerLabel.Text = $"Partner: {(currentUser.isPartner ? "Yes" : "No")}";
            genderLabel.Text = $"Gender: {currentUser.gender}";
            bdayLabel.Text = $"Bday: {currentUser.datetime.ToString("dd/MM/yyyy")}";

            checkActivities();

            partnerSwitch.Toggled += ChangePartner;

        }

        private async void OnManageActivitiesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Activities(currentUser));
        }

        private void ChangePartner(object sender, ToggledEventArgs e)
        {
            currentUser.isPartner = e.Value;
            isPartnerLabel.Text = $"Partner: {(currentUser.isPartner ? "Yes" : "No")}";
        }

        private async void OnDeleteUserClicked(object sender, EventArgs e)
        {
            // Confirm
            bool answer = await DisplayAlert("Confirm Deletion", "Are you sure you want to delete this user?", "Yes", "No");

            if (answer)
            {
                User.users.Remove(currentUser); // Delete user
                await Navigation.PopAsync();
            }
        }

        private void checkActivities()
        {
            if (currentUser.activities.Any())
            {
                ActivitiesHeader.Text = "Activities:";
                enrolledActivitiesListView.ItemsSource = currentUser.activities;
            }
            else
            {
                ActivitiesHeader.Text = "No Activities";
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            checkActivities();
        }

    }
}
