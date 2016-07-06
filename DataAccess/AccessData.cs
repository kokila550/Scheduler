using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class AccessData
    {
        //Login Customer


        //
        public List<UserLogin> Login(string username, string password)
        {
            using (rideshareEntities entities = new rideshareEntities())
            {
                var userlogin = new List<UserLogin>();

             //   var a = (from c in entities.tbl_customer where v.cus_email == username && v.cus_password = password select 1);
                var isprecent = (from c in entities.tbl_customer where (c.cus_email == username && c.cus_password == password) select 1).ToList();
                       


                
                foreach (var k in isprecent)
                {
                    userlogin.Add(new UserLogin()
                    {
                        Loginstatus = "1"
                      

                    });
                }
                return userlogin; ;
            }

        }
        //public int Login(string username, string password)
        //{
        //    using (rideshareEntities entities = new rideshareEntities())
        //    {

        //        var isprecent = entities.tbl_customer.SingleOrDefault(customer => customer.cus_email == username && customer.cus_password == password);
        //        //var query = entities.tbl_customer.Where(p => p.cus_email == 'a' && p.product_price > 500 && p.product_price < 10000)
        //       // var queary = entities.tbl_customer.SingleOrDefault(customer => customer.cus_email == username && customer.cus_password == password);


        //        if (isprecent != null)
        //        {
        //            return 1;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }



        //}

        //Register Customer
        public List<RegisterStatus> RegisterCustomer(string phoneno, string email, string fname, string lname, string password)
        {
            var registerstatus = new List<RegisterStatus>();
            using (rideshareEntities entities = new rideshareEntities())
            {
                var a = (from c in entities.tbl_customer where (c.cus_email == email || c.cus_phoneno== phoneno) select 1);
                //var a = entities.tbl_customer.SingleOrDefault(customer => customer.cus_phoneno == phoneno);

                var firstOrDefault = a.FirstOrDefault();
                if (firstOrDefault == 1  )
                {
                    if (a != null)
                    {
                        registerstatus.Add(new RegisterStatus()
                        {
                            registration = "Email Already Exist"


                        });
                        return registerstatus; ;

                    }
                    return registerstatus; ;
                }


               
                else
                {
                    tbl_customer customer = new tbl_customer { cus_phoneno = phoneno, cus_password = password, cus_fname = fname, cus_lname = lname, cus_email = email };
                    entities.tbl_customer.Add(customer);
                    entities.SaveChanges();
                    registerstatus.Add(new RegisterStatus()
                    {
                        registration = "Registration Succsess"


                    });
                    return registerstatus; ;
                }

            }
        }


        //Login Driver
        public List<LoginDriver> DriverLogin(string phoneno, string password)
        {
            using (rideshareEntities entities = new rideshareEntities())
            {
                var driverlogin = new List<LoginDriver>();
                var a = (from c in entities.tbl_driver where (c.dri_phoneno == phoneno &&  c.dri_password == password) select 1);
               // var isprecent = from d in entities.tbl_driver where d.dri_phoneno == phoneno && d.dri_password == password select 1;
                var firstOrDefault = a.FirstOrDefault();

                foreach (var k in a)
                {
                    driverlogin.Add(new LoginDriver()
                    {
                        loginstatus = "1"


                    });
                }
                return driverlogin; ;

            }
        }

        //Get Vehicle List
        public List<VehicleInfo> GetTaxiList()
        {
            using (rideshareEntities entities = new rideshareEntities())
            {
                var vehicleInfo = new List<VehicleInfo>();

                var a = (from v in entities.tbl_vehicle
                         join d in entities.tbl_driver on v.veh_driverid equals d.dri_id
                         select new { v.veh_regno, v.veh_type, v.veh_location, v.veh_description, d.dri_lname, d.dri_phoneno, v.veh_Latitude, v.veh_Longitude });
                foreach (var k in a)
                {
                    vehicleInfo.Add(new VehicleInfo()
                    {
                        veh_regno = k.veh_regno,
                        veh_type = k.veh_type,
                        veh_location = k.veh_location,
                        veh_description = k.veh_description,
                        dri_lname = k.dri_lname,
                        dri_phoneno = k.dri_phoneno,
                        veh_Latitude= k.veh_Latitude,
                        veh_Longitude = k.veh_Longitude

                    });
                }
                  return vehicleInfo; ;
            }
        }


        //UpdateCustomerDetails
        public string Updateuser(string address,string nic, string phoneno,string fname,string lname, string vehicleno, string licenceno)
        {
            try
            {
                using (rideshareEntities entities = new rideshareEntities())
                {

                    tbl_driver driver = entities.tbl_driver.SingleOrDefault(dri => dri.dri_nic == nic);
                    if (nic != "")
                    {
                        driver.dri_nic = nic;

                    }
                    if (fname != "")
                    {
                        driver.dri_fname = fname;
                    }
                    if (lname != "")
                    {
                        driver.dri_lname = lname;

                    }
                    if (licenceno != "")
                    {
                        driver.dri_licence = licenceno;
                    }
                    if (phoneno != "")
                    {
                        driver.dri_phoneno = phoneno;
                    }

                    if (address != "")
                    {
                        driver.dri_address = address;
                    }

                    entities.SaveChanges();
                                       
                    return "Sucess";

                }
            }
            catch (Exception)
            {

                throw new  Exception("Oops something wrong try again");
            }
           

        }

        //Add New vehicle
        public string AddTaxi( string regno , string type, string description, string driver)
        {
            using (rideshareEntities entities = new rideshareEntities())
            {
                 var a = entities.tbl_vehicle.SingleOrDefault(vehicle => vehicle.veh_regno == regno);
                if (a != null)
                {
                    return string.Format("Vehicle Already Exist");
                }
                else
                {
                    tbl_vehicle vehicle = new tbl_vehicle { veh_regno = regno, veh_type = type, veh_description = description   , veh_driverid = int.Parse(driver), active = "T"};
                    entities.tbl_vehicle.Add(vehicle);
                    entities.SaveChanges();
                    return null;
                }

            }
            
        }

        //Add New Driver
        public string AddDriver(string fname, string lname, string address, string nic)
        {
            using (rideshareEntities entities = new rideshareEntities())
            {

                var a = entities.tbl_driver.SingleOrDefault(driver => driver.dri_nic == nic );
                if (a != null)
                {
                    return string.Format("Vehicle Already Exist");
                }
                else
                {
                    tbl_driver driver = new tbl_driver { dri_nic = nic, dri_address = address, dri_fname = fname, dri_lname = lname , active = "T" };
                    entities.tbl_driver.Add(driver);
                    entities.SaveChanges();
                    return null;
                }

            }

        }


        //Update Vehicle Details
        public string UpdateTaxi(string vehid,string regno, string type, string description, string driver, string active)
        {
            try
            {
                using (rideshareEntities entities = new rideshareEntities())
                {

                    tbl_vehicle vehicle = entities.tbl_vehicle.SingleOrDefault(veh => veh.veh_id == int.Parse(vehid));
                    if (regno != "")
                    {
                        vehicle.veh_regno = regno;

                    }
                    if (type != "")
                    {
                        vehicle.veh_type = type;
                    }
                    if (description != "")
                    {
                        vehicle.veh_description = description;

                    }
                    if (driver != "")
                    {
                        vehicle.veh_driverid = int.Parse(driver);
                    }
                    if (active != "")
                    {
                        vehicle.active = active;
                    }


                    entities.SaveChanges();

                    return "Sucess";

                }
            }
            catch (Exception)
            {

                throw new Exception("Oops something wrong try again");
            }


        }


        //Update Driver Details
        public string UpdateDriver(string driid,string fname, string lname, string address, string nic, string licenceno)
        {
            try
            {
                using (rideshareEntities entitis = new rideshareEntities())
                {
                    tbl_driver driver = entitis.tbl_driver.SingleOrDefault(dri => dri.dri_id == int.Parse(driid));
                    if (lname  != "")
                    {
                        driver.dri_lname = lname;
                    }
                    if (address != "")
                    {
                        driver.dri_address = address;
                    }
                    if (nic !="")
                    {
                        driver.dri_nic = nic;
                    }
                    entitis.SaveChanges();
                    return "Sucess";

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }  
  
}
