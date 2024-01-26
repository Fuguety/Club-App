using Xamarin.Forms;
using System.Linq;
using System;
using System.Threading.Tasks;


namespace Pls_Work
{
    public partial class UserDetails : ContentPage
    {
        private UserManagment UserManagment;

        public User currentUser { get; set; }

        public UserDetails(User selectedUser, UserManagment userManagment)
        {
            InitializeComponent();
            currentUser = selectedUser;
            UserManagment = userManagment;

            BindingContext = this; // Set the binding context to the instance of UserDetails


            codeLabel.Text = $"Code: {currentUser.Code}";
            nameLabel.Text = $"Name: {currentUser.name}";
            lastNameLabel.Text = $"Last Name: {currentUser.lastName}";
            isPartnerLabel.Text = $"Partner: {(currentUser.isPartner ? "Yes" : "No")}";
            genderLabel.Text = $"Gender: {currentUser.gender}";
            bdayLabel.Text = $"Bday: {currentUser.datetime.ToString("dd/MM/yyyy")}";

            checkActivities();

            partnerSwitch.Toggled += ChangePartner;

            // Saves when users enters page
            UserManagment.UpdateUser(selectedUser);

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
                UserManagment.users.Remove(currentUser); // Delete user
                JsonManager.SaveUsers(UserManagment.users); // Update JSON file
                await Navigation.PopAsync();
            }
        }

        // Saves on Button click
        private async void OnUpdateUser(object sender, EventArgs e)
        { 
            UserManagment.UpdateUser(currentUser);
            await DisplayAlert("Success", "User updated successfully", "OK");
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

        // Saves on exit
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            UserManagment.UpdateUser(currentUser);
            if (Navigation.NavigationStack.Last() is List userListPage)
            {
                userListPage.RefreshUserList(); 
            }
        }

    }
}
