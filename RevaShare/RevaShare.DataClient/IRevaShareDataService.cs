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
        List<UserDAO> GetAdmins();
        [OperationContract]
        UserDAO GetAdminByUsername(string username);
        [OperationContract]
        bool UpdateUser(UserDAO user);
        [OperationContract]
        bool DeleteUser(string username);


        //Other User Related Methods
        [OperationContract]
        bool Login(string username, string password);
        [OperationContract]
        bool ApproveDriver(string username);
        [OperationContract]
        bool ApproveUser(string username);
        [OperationContract]
        bool RequestToBeDriver(string username);
        [OperationContract]
        List<UserDAO> PendingRegistrations();
        [OperationContract]
        List<UserDAO> PendingDriverApprovals();
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
        bool UpdateRide(RideDAO ride);
        [OperationContract]
        bool DeleteRide(RideDAO ride);
        [OperationContract]
        List<RideDAO> ListRidesAtApartment(string apartmentName);
        [OperationContract]
        int GetOpenSeats(string username, DateTime startOfWeekDate);


        //RideRider section
        [OperationContract]
        List<RideRidersDAO> GetRideRiders();
        [OperationContract]
        bool AddRideRiders(UserDAO user, RideDAO ride);
        [OperationContract]
        bool UpdateRideRider(RideRidersDAO riderider);
        [OperationContract]
        bool Accept(RideRidersDAO riderider);
        [OperationContract]
        bool DeleteRideRider(RideRidersDAO riderider);


        //Vehicle section
        [OperationContract]
        bool AddVehicle(VehicleDAO vehicle);
        [OperationContract]
        bool UpdateVehicle(VehicleDAO vehicle);
        [OperationContract]
        bool DeleteVehicle(VehicleDAO vehicle);


        //Flag Section
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
   }
}
