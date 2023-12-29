using Xamarin.Forms;
using System;

namespace Pls_Work
{
    public partial class AddUser : ContentPage
    {
        public AddUser()
        {
            InitializeComponent();
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


            // Save user
            User.SaveUser(name, lastName, bday, isPartner, gender);

            // Show saving succesfull
            await DisplayAlert("Nice", "User saved correctly", "OK");

            await Navigation.PopAsync();
        }
    }
}
