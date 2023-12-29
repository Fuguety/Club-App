using Xamarin.Forms;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pls_Work
{
    public partial class Activities : ContentPage
    {
        User user;

        public Activities(User currentUser)
        {
            InitializeComponent();
            user = currentUser;

            enrolledActivitiesListView.ItemsSource = user.activities;
        }

        private void OnSaveActivity(object sender, EventArgs e)
        {
            DateTime dateVisit = datePicker.Date;
            string activity = activityPicker.SelectedItem as string;

            // Check if an activity is selected
            if (!string.IsNullOrEmpty(activity))
            {
                // Create a new activity entry
                Activity newActivity = new Activity
                {
                    Date = dateVisit,
                    ActivityType = activity
                };

                // Save the activity to the user
                user.activities.Add(newActivity);

                // Clear page
                activityPicker.SelectedItem = null;
                datePicker.Date = DateTime.Today;

                // Show Enrolled activities
                enrolledActivitiesListView.ItemsSource = user.activities;

                DisplayAlert("Nice", "Activity recorded with success", "OK");
            }

            else { DisplayAlert("Error", "Please select an activity", "OK"); }
        }

        // Remove Activity
        private void OnRemoveActivity(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Activity activity)
            {
                user.activities.Remove(activity);
                enrolledActivitiesListView.ItemsSource = null;
                enrolledActivitiesListView.ItemsSource = user.activities;
            }
        }

    }
}
