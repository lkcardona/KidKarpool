using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KidKarpool.Models
{
    public class Request

    { 
        
        public int RequestID { get; set; }
        
        [System.ComponentModel.DisplayName("Student Name")]
        public string StudentName { get; set; }

        [System.ComponentModel.DisplayName("Student Class")]
        public string StudentClass { get; set; }
       
        [System.ComponentModel.DisplayName("Time of Pickup")]
        public DateTime TimeOfPickUp { get; set; }
       
        [System.ComponentModel.DisplayName("Identify Lot")]
        public string IdentifyLot { get; set; }
       
        [System.ComponentModel.DisplayName("Ride Start Time")]
        public DateTime RideStartTime { get; set; }
        
        [System.ComponentModel.DisplayName("Ride End Time")]
        public DateTime RideEndTime { get; set; }
       
        
        //After clicking the accept button, the following info will be displayed
        [System.ComponentModel.DisplayName("Parent Name")]
        public string ParentName { get; set; }

        [System.ComponentModel.DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [System.ComponentModel.DisplayName("Driver Phone Number")]
        public string DriverPhoneNumber { get; set; }

        [System.ComponentModel.DisplayName("Parent Accepting Name")]
        public string ParentAcceptingName { get; set; }

        [System.ComponentModel.DisplayName("Driver Make Model")]
        public string CarMakeModel { get; set; }

    }
}
