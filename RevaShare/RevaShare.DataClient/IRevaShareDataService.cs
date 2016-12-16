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
        bool Login(string username, string password);
        [OperationContract]
        bool register(UserDAO user, string username, string password);
        [OperationContract]
        bool DeleteUser(string username);
        [OperationContract]
        bool UpdateUserRole(string username, string role);
        [OperationContract]
        bool ApproveDriver(string username);
        [OperationContract]
        bool ApproveUser(string username);
        [OperationContract]
        List<UserDAO> PendingRegistrations();
        [OperationContract]
        List<UserDAO> PendingDriverApprovals();
        [OperationContract]
        bool UpdateUser(UserDAO user);
        [OperationContract]
        bool UpdatePassword(string username, string currentPassword, string newPassword);

        /// <summary>
        /// Apartment section
        /// </summary>

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
        bool DeleteRide(RideDAO ride);
        [OperationContract]
        List<RideDAO> ApartmentRides();
        [OperationContract]
        int GetOpenSeats(string username, DateTime startOfWeekDate);

        /// <summary>
        /// RideRider section
        /// </summary>
        [OperationContract]
        List<RideRidersDAO> GetRideRiders();
        //[OperationContract]
        //RideRidersDAO GetRideRiderById(string id);
        [OperationContract]
        RideRidersDAO passRideRider();
        [OperationContract]
        bool AddRideRiders(UserDAO user, RideDAO ride);
        [OperationContract]
        bool UpdateRideRider(RideRidersDAO riderider);
        [OperationContract]
        bool Accept(RideRidersDAO riderider);
        [OperationContract]
        bool DeleteRideRider(RideRidersDAO riderider);


        /// <summary>
        /// Vehicle section
        /// </summary>    
        //[OperationContract]
        //VehicleDAO GetVehicleById(int id);

        [OperationContract]
        bool AddVehicle(VehicleDAO vehicle);

        [OperationContract]
        bool UpdateVehicle(VehicleDAO vehicle);
        [OperationContract]
        bool DeleteVehicle(VehicleDAO vehicle);
        [OperationContract]
        bool CreateFlag(FlagDAO flag);
        [OperationContract]
        FlagDAO GetFlagByID(int id);
        [OperationContract]
        List<FlagDAO> GetAllFlags();


    }
}
