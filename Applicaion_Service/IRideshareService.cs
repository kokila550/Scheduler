using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Applicaion_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRideshareService" in both code and config file together.
    [ServiceContract]
    public interface IRideshareService
    {
  

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Auth/{phoneno}")]
        int Login(string phoneno);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "AddUser/{phoneno},{email},{fname},{lname},{password}")]
        string RegisterCustomer(string phoneno, string email, string fname, string lname, string password);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "AuthDriver/{phoneno}/{password}")]
        int LoginDriver(string phoneno, string password);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetCars/")]
        List<VehicleInfo> GetTaxiList();


    }
}
