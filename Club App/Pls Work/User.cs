using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pls_Work
{
    public class User
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public DateTime datetime { get; set; }
        public bool isPartner { get; set; }
        public string gender { get; set; }

        public ObservableCollection<Activity> activities { get; set; }

        public User() { activities = new ObservableCollection<Activity>(); }

        public static List<User> users { get; set; } = new List<User>();

        public static void SaveUser(string name, string lastName, DateTime bday, bool isPartner, string gender)
        {
            User newUser = new User
            {
                name = name,
                lastName = lastName,
                datetime = bday,
                isPartner = isPartner,
                gender = gender,
                activities = new ObservableCollection<Activity>()
            };

            users.Add(newUser);
        }
    }
}
