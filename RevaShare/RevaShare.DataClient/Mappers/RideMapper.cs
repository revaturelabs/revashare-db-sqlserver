using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient
{
  public class RideMapper
  {
    public static RideDAO MapToRideDAO(Ride ride)
    {
      var u = new RideDAO();
      u.Vehicle = VehicleMapper.MapToVehicleDAO(ride.Vehicle);
      u.DepartureTime = ride.DepartureTime;
      u.StartOfWeek = ride.StartOfWeekDate;
      u.IsOnTime = ride.IsOnTime;
      u.IsAmRide = ride.IsAmRide;
      u.NumberOfRidersInRide = ride.RideRiders.Count();
      
      return u;
    }

    public static Ride MapToRide(RideDAO ride)
    {
      RevaShareData data = new RevaShareData();

      var u = new Ride();
      
      //If ride is already in DB, copy over the ride id
      var rideInDB = data.GetRide(data.GetUser(ride.Vehicle.Owner.UserName).UserID, ride.StartOfWeek, ride.IsAmRide);
      if (rideInDB != null)
      {
          u.ID = rideInDB.ID;
      }

      u.VehicleID = data.GetVehicleByLicensePlate(ride.Vehicle.LicensePlate).ID;
      u.DepartureTime = ride.DepartureTime;
      u.StartOfWeekDate = ride.StartOfWeek;
      u.IsOnTime = true;
      u.IsAmRide = ride.IsAmRide;
      u.Active = true;

      return u;
    }   
  }
}