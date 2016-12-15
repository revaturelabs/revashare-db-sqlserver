using RevaShare.DataAccess;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient
{
  public class RideRiderMapper
  {
    public static RideRidersDAO MapToRideRiderDAO(RideRider riderider)
    {
      var u = new RideRidersDAO();
      u.Ride = RideMapper.MapToRideDAO(riderider.Ride);
      u.Rider = UserMapper.MapToUserDAO(riderider.AspNetUser);
      u.Accepted = riderider.Accepted;
      

      return u;
    }

    public static RideRider MapToRideRider(RideRidersDAO riderider)
    {
      var u = new RideRider();
      u.Ride = RideMapper.MapToRide(riderider.Ride);
      u.AspNetUser = UserMapper.MapToUser(riderider.Rider);
      u.Accepted = riderider.Accepted;

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