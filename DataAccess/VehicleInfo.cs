using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class VehicleInfo
    {
        public string veh_regno { get; set; }
        public string veh_type { get; set; }
        public string veh_location { get; set; }
        public string veh_description { get; set; }
        public string dri_lname { get; set; }
        public string dri_phoneno { get; set; }
        public string veh_Latitude { get; set; }
        public string veh_Longitude { get; set; }
    }

    public class UserLogin
    { 
        public string Loginstatus { get; set;}
    }

    public class RegisterStatus
    {
        public string registration { get; set; }
    }
    public class LoginDriver
    {
        public string  loginstatus{ get; set; }
    }
   
}
