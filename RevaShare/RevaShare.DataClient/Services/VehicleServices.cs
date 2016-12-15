using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient
{
    public partial class RevaShareDataService
    {
        public bool AddVehicle(VehicleDAO vehicle)
        {
            return data.AddVehicle(VehicleMapper.MapToVehicle(vehicle));
        }

        public bool UpdateVehicle(VehicleDAO vehicle)
        {
            return data.UpdateVehicle(VehicleMapper.MapToVehicle(vehicle));
        }

        public bool DeleteVehicle(VehicleDAO vehicle)
        {
            return data.DeleteVehicle(VehicleMapper.MapToVehicle(vehicle));
        }
    }
}