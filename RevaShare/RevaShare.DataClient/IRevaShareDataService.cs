using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RevaShare.DataClient
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRevaShareDataService" in both code and config file together.
  [ServiceContract]
  public interface IRevaShareDataService
  {

    [OperationContract]
    RideDAO passRide();
    [OperationContract]
    UserDAO passUser();
    [OperationContract]
    RideRidersDAO passRideRider();
    [OperationContract]
    UserDAO logIn();
    [OperationContract]
    UserDAO register();

    [OperationContract]
    ApartmentDAO GetApartment(int id);
    [OperationContract]
    ApartmentDAO GetApartmentByName(string name);

    [OperationContract]
    RideRidersDAO GetRideRiders();
    [OperationContract]
    RideRidersDAO GetRideRiderById(int id);

    [OperationContract]
    VehicleDAO GetVehicleById(int id);



  }
}
