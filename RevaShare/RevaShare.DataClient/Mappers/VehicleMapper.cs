using Microsoft.AspNet.Identity;
using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
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

            c.OwnerID = RevaShareIdentity.Instance.Manager.FindByName(vehicle.Owner.UserName).Id;
            c.Make = vehicle.Make;
            c.Model = vehicle.Model;
            c.Color = vehicle.Color;
            c.Capacity = vehicle.Capacity;
            c.LicensePlate = vehicle.LicensePlate;

            return c;
        }
    }
}