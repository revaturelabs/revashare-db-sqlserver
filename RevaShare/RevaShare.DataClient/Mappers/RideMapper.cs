using RevaShare.DataAccess;
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

      return u;
    }

    public static Ride MapToRide(RideDAO ride)
    {
      var u = new Ride();
      u.Vehicle = VehicleMapper.MapToVehicle(ride.Vehicle);
      u.DepartureTime = ride.DepartureTime;
      u.StartOfWeekDate = ride.StartOfWeek;
      u.IsOnTime = ride.IsOnTime;
      u.IsAmRide = ride.IsAmRide;

      return u;
    }   
  }
}