﻿using RevaShare.DataAccess;
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
      var c = new Vehicle();
      //c.AspNetUser = UserMapper.MapToUser(vehicle.Owner);
      c.Make = vehicle.Make;
      c.Model = vehicle.Model;
      c.Color = vehicle.Color;
      c.Capacity = vehicle.Capacity;
      c.LicensePlate = vehicle.LicensePlate;

      return c;
    }    
  }
}