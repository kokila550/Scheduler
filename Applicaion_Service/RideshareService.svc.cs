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
        public int Login(string phoneno)
        {

            AccessData ad  = new AccessData();
            return ad.Login(phoneno);
        }


        public string RegisterCustomer(string phoneno, string email, string fname, string lname, string password)
        {
            AccessData ad = new AccessData();
            return ad.RegisterCustomer(phoneno, email, fname, lname, password);
        }

        public int LoginDriver(string phoneno, string password)
        {
            AccessData ad = new AccessData();
            return ad.LoginDriver(phoneno, password);
        }

        public List<VehicleInfo> GetTaxiList()
        {
            AccessData ad = new AccessData();
            return ad.GetTaxiList();
        }
       


    }
}
