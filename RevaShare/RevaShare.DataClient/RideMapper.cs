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
      u.RideID = ride.ID;
      u.Vehicle = VehicleMapper.MapToVehicleDAO(ride.Vehicle);
      u.DepartureTime = ride.DepartureTime;
      u.StartOfWeek = ride.StartOfWeekDate;
      u.IsOnTime = ride.IsOnTime;

      return u;
    }

    public static Ride MapToRide(RideDAO ride)
    {
      var u = new Ride();
      u.ID = ride.RideID;
      u.Vehicle = VehicleMapper.MapToVehicle(ride.Vehicle);
      u.DepartureTime = ride.DepartureTime;
      u.StartOfWeekDate = ride.StartOfWeek;
      u.IsOnTime = ride.IsOnTime;

      return u;
    }


    // this is an example of "Reflection"
    public static object MapTo(object o)
    {
      var properties = o.GetType().GetProperties();
      var ob = new object();

      foreach (var item in properties.ToList())
      {
        ob.GetType().GetProperty(item.Name).SetValue(ob, item.GetValue(item));
      }
      return ob;
    }
  }
}