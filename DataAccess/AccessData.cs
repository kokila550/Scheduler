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
        public int Login(string phoneno)
        {
            using (rideshareEntities entities = new rideshareEntities())
            {

                var isprecent = entities.tbl_customer.SingleOrDefault(customer => customer.cus_phoneno == phoneno);


                if (isprecent != null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }



        }

        //Register Customer
        public string RegisterCustomer(string phoneno, string email, string fname, string lname, string password)
        {

            using (rideshareEntities entities = new rideshareEntities())
            {
                var a = entities.tbl_customer.SingleOrDefault(customer => customer.cus_phoneno == phoneno);
                if (a != null)
                {
                    return string.Format("Email Already Exist");
                }
                else
                {
                    tbl_customer customer = new tbl_customer { cus_phoneno = phoneno, cus_password = password, cus_fname = fname, cus_lname = lname, cus_email = email };
                    entities.tbl_customer.Add(customer);
                    entities.SaveChanges();
                    return null;
                }

            }
        }


        //Login Driver
        public int LoginDriver(string phoneno, string password)
        {
            using (rideshareEntities entities = new rideshareEntities())
            {
                var isprecent = from d in entities.tbl_driver where d.dri_phoneno == phoneno && d.dri_password == password select 1;
                if (isprecent == null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }

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
                         select new { v.veh_regno, v.veh_type, v.veh_location, v.veh_description, d.dri_lname, d.dri_phoneno });
                foreach (var k in a)
                {
                    vehicleInfo.Add(new VehicleInfo()
                    {
                        veh_regno = k.veh_regno,
                        veh_type = k.veh_type,
                        veh_location = k.veh_location,
                        veh_description = k.veh_description,
                        dri_lname = k.dri_lname,
                        dri_phoneno = k.dri_phoneno

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
