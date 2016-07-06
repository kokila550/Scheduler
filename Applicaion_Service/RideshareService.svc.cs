using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccess;


namespace Applicaion_Service
{
     
    public class RideshareService : IRideshareService
    {
        public List<UserLogin> Login(string username, string password)
        {

            AccessData ad  = new AccessData();
            return ad.Login(username, password);
        }

   
        public List<RegisterStatus> RegisterCustomer(string phoneno, string email, string fname, string lname, string password)
        {
            AccessData ad = new AccessData();
            return ad.RegisterCustomer(phoneno, email, fname, lname, password);
        }

        public List<LoginDriver> DriverLogin(string phoneno, string password)
        {
            AccessData ad = new AccessData();
            return ad.DriverLogin(phoneno, password);
        }

        //public int LoginDriver(string phoneno, string password)
        //{
        //    AccessData ad = new AccessData();
        //    return ad.DriverLogin(phoneno, password);
        //}

        public List<VehicleInfo> GetTaxiList()
        {
            AccessData ad = new AccessData();
            return ad.GetTaxiList();
        }

        public string Updateuser(string address, string nic, string phoneno, string fname, string lname, string vehicleno, string licenceno)
        {
            AccessData ad = new AccessData();
            return ad.Updateuser(address, nic, phoneno, fname, lname, vehicleno, licenceno);
        }




    }
}
