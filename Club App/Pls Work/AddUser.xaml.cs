using Xamarin.Forms;
using System;
using System.Collections.Generic;

namespace Pls_Work
{
    public partial class AddUser : ContentPage
    {
        UserManagment UserManagment;

        public AddUser()
        {
            InitializeComponent();

            UserManagment = new UserManagment();
        }

        private async void OnSaveUserClicked(object sender, EventArgs e)
        {

            string name = entryName.Text;
            string lastName = entryLastName.Text;
            DateTime bday = dateOfBirth.Date;
            bool isPartner = partner.IsToggled;
            string gender = genderPicker.SelectedItem as string;


            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName))
            {
                await DisplayAlert("Error", "Please fill your Name and Last Name.", "OK");
                return; // Go back
            }

            if (string.IsNullOrWhiteSpace(gender))
            {
                await DisplayAlert("Error", "Please insert your gender.", "OK");
                return;
            }

            List<Activity> emptyActivityList = new List<Activity>();

            // Save user
            UserManagment.CreateUser(name, lastName, bday, isPartner, gender);

            // Show saving succesfull
            await DisplayAlert("Nice", "User saved correctly", "OK");

            await Navigation.PopAsync();
        }
    }
}
