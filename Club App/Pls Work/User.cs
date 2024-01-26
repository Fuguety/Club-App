using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pls_Work
{
    public class User
    {
        public int Code { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public DateTime datetime { get; set; }
        public bool isPartner { get; set; }
        public string gender { get; set; }

        public ObservableCollection<Activity> activities { get; set; }

        public User() 
        {
            activities = activities ?? new ObservableCollection<Activity>();
        }

        
    }
}
