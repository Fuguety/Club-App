using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pls_Work
{
    public class UserManagment
    {

        // Instance property for users list
        public List<User> users { get; private set; }
        private static List<int> UsedCodes = new List<int>();


        // Constructor to initialize the users list
        public UserManagment()
        {
            users = JsonManager.LoadUsers() ?? new List<User>();
        }


        public void CreateUser(string name, string lastName, DateTime bday, bool isPartner, string gender)
        {
            // Create a new user
            User newUser = new User
            {
                name = name,
                lastName = lastName,
                datetime = bday,
                isPartner = isPartner,
                gender = gender,
                activities = new ObservableCollection<Activity>(),
                Code = GenerateUniqueCode()
            };

            // Add to list
            users.Add(newUser);

            // Save to Json
            JsonManager.SaveUsers(users);
        }



        public void UpdateUser(User user)
        {
            User existingUser = users.FirstOrDefault(u => u.Code == user.Code);

            if (existingUser != null)
            {
                // Update the existing user
                Console.WriteLine(existingUser.name);
                existingUser.isPartner = user.isPartner;
                existingUser.activities = user.activities; // Assuming you want to update activities too
            }

            JsonManager.SaveUsers(users);
        }




        private static int GenerateUniqueCode()
        {
            int newCode = 1;

            if (UsedCodes.Any())
            {
                newCode = UsedCodes.Max() + 1;
            }

            UsedCodes.Add(newCode);

            return newCode;
        }


    }
}
