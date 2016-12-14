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
    /// <summary>
    /// User section
    /// </summary>
    /// <returns></returns>
    
    [OperationContract]
    UserDAO passUser();
    
    [OperationContract]
    UserDAO logIn();
    [OperationContract]
    UserDAO register();

    /// <summary>
    /// Apartment section
    /// </summary>
    
    [OperationContract]
    ApartmentDAO GetApartment(int id);
    [OperationContract]
    ApartmentDAO GetApartmentByName(string name);

    /// <summary>
    /// Flag section
    /// </summary>




    /// <summary>
    /// Ride section
    /// </summary>
    [OperationContract]
    RideDAO passRide();
    [OperationContract]
    bool AddRide(RideDAO ride);
    [OperationContract]
    bool UpdateRide(RideDAO ride);
    [OperationContract]
    bool DeleteRide(string id);

    /// <summary>
    /// RideRider section
    /// </summary>
    [OperationContract]
    List<RideRidersDAO> GetRideRiders();
    [OperationContract]
    RideRidersDAO GetRideRiderById(string id);
    [OperationContract]
    RideRidersDAO passRideRider();
    [OperationContract]
    bool AddRideRiders(RideDAO ride, RideRidersDAO rideriders);
    [OperationContract]
    bool UpdateRideRider(RideRidersDAO riderider);
    [OperationContract]
    bool DeleteRideRider(string id);


    /// <summary>
    /// Vehicle section
    /// </summary>    
    [OperationContract]
    VehicleDAO GetVehicleById(int id);

    [OperationContract]
    bool AddVehicle(VehicleDAO vehicle);

    [OperationContract]
    bool UpdateVehicle(VehicleDAO vehicle);
    [OperationContract]
    bool DeleteVehicle(int id);
   



  }
}
