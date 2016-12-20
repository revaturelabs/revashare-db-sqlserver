using RevaShare.DataAccess;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient
{
  public class VehicleMapper
  {
    public static VehicleDAO MapToVehicleDAO(Vehicle vehicle)
    {
      var c = new VehicleDAO();
      //c.Owner = UserMapper.MapToUserDAO(vehicle.AspNetUser);
      c.Make = vehicle.Make;
      c.Model = vehicle.Model;
      c.Color = vehicle.Color;
      c.Capacity = vehicle.Capacity;
      c.LicensePlate = vehicle.LicensePlate;
      
      return c;
    }
      public static Vehicle MapToVehicle(VehicleDAO vehicle)
      {
         RevaShareDataService svc = new RevaShareDataService();
         var c = new Vehicle();
         c.OwnerID = svc.GetUsersByUsername(vehicle.Owner.Name).UserName;
         c.Make = vehicle.Make;
         c.Model = vehicle.Model;
         c.Color = vehicle.Color;
         c.Capacity = vehicle.Capacity;
         c.LicensePlate = vehicle.LicensePlate;

         return c;
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