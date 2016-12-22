using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RevaShare.DataClient
{
   [ServiceContract]
   public interface IRevaShareDataService
   {
      //User CRUD
      [OperationContract]
      bool RegisterUser(UserDAO user, string username, string password);

      [OperationContract]
      List<UserDAO> GetAllUsers();

      [OperationContract]
      UserDAO GetUserByUsername(string username);

      [OperationContract]
      List<UserDAO> GetRiders();

      [OperationContract]
      List<UserDAO> GetDrivers();

      [OperationContract]
      List<UserDAO> GetAdmins();

      [OperationContract]
      UserDAO GetAdminByUsername(string username);

      [OperationContract]
      bool UpdateUser(UserDAO user);

      [OperationContract]
      bool DeleteUser(string username);

      [OperationContract]
      bool AddAdmin(UserDAO user, string username, string password);

    
      //Other User Related Methods
      [OperationContract]
      UserDAO Login(string username, string password);

      [OperationContract]
      bool ApproveDriver(string username);

      [OperationContract]
      bool ApproveRider(string username);

      [OperationContract]
      bool RequestToBeDriver(string username);

      [OperationContract]
      bool RemoveDriverPrivileges(string username);

      [OperationContract]
      List<UserDAO> GetPendingRiders();

      [OperationContract]
      List<UserDAO> GetPendingDrivers();

      [OperationContract]
      bool UpdatePassword(string username, string currentPassword, string newPassword);


      //Apartment section
      [OperationContract]
      ApartmentDAO GetApartmentByName(string name);

      [OperationContract]
      bool AddApartment(ApartmentDAO apartment);

      [OperationContract]
      List<ApartmentDAO> ListApartments();

      [OperationContract]
      bool UpdateApartment(ApartmentDAO apartment);

      [OperationContract]
      bool DeleteApartment(string apartment);


      //Ride section
      [OperationContract]
      bool AddRide(RideDAO ride);

      [OperationContract]
      List<RideDAO> GetAllRides();

      [OperationContract]
      bool UpdateRide(RideDAO ride);

      [OperationContract]
      bool DeleteRide(RideDAO ride);

      [OperationContract]
      List<RideDAO> ListRidesAtApartment(string apartmentName);

      [OperationContract]
      int GetOpenSeats(RideDAO ride);

      [OperationContract]
      List<RideDAO> ListRidesAtApartmentAM(string apartmentName);

      [OperationContract]
      List<RideDAO> ListRidesAtApartmentPM(string apartmentName);
    

      //RideRider section
      [OperationContract]
      List<RideRidersDAO> GetRideRiders();

      [OperationContract]
      bool AddRideRiders(UserDAO user, RideDAO ride);

      [OperationContract]
      bool UpdateRideRider(RideRidersDAO riderider);

      [OperationContract]
      bool AcceptRideRequest(RideRidersDAO riderider);

      [OperationContract]
      bool DeleteRideRider(RideRidersDAO riderider);

      [OperationContract]
      List<UserDAO> getRidersInRide(RideDAO ride);


      //Vehicle section
      [OperationContract]
      bool AddVehicle(VehicleDAO vehicle);

      [OperationContract]
      bool UpdateVehicle(VehicleDAO vehicle);

      [OperationContract]
      bool DeleteVehicle(VehicleDAO vehicle);

      [OperationContract]
      List<VehicleDAO> GetVehicles();


      //Flag section
      [OperationContract]
      bool CreateFlag(FlagDAO flag);

      [OperationContract]
      FlagDAO GetFlagByID(int id);

      [OperationContract]
      List<FlagDAO> GetAllFlags();

      [OperationContract]
      bool MarkFlagAsRead(FlagDAO flag);

      [OperationContract]
      bool UpdateFlag(FlagDAO flag);

   }
}
