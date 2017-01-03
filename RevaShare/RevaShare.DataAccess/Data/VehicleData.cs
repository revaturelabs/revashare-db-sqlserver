using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RevaShare.DataAccess.Data
{
   public partial class RevaShareData
   {

      public List<Vehicle> GetVehicles()
      {
         return context.Vehicles.ToList().Where(m => m.Active).ToList();
      }

      public bool AddVehicle(Vehicle vehicle)
      {

         if (vehicle.LicensePlate.Length <= 10 && vehicle.LicensePlate.Length > 0)
            {
                if (context.Vehicles.Where(m => m.LicensePlate.Equals(vehicle.LicensePlate) && m.Active).Count() < 1)
                {
                    vehicle.Active = true;
                    context.Vehicles.Add(vehicle);
                    return context.SaveChanges() > 0;
                }
                else return false;
            }
            else return false;
        }

      public bool UpdateVehicle(Vehicle vehicle)
      {
         vehicle.ID = GetVehicles().Where(m => m.LicensePlate.Equals(vehicle.LicensePlate)).FirstOrDefault().ID;
         var result = context.Vehicles.SingleOrDefault(x => x.ID == vehicle.ID);

         if (result != null)
         {
            if (vehicle.ID != 0)
               result.ID = vehicle.ID;

            if (vehicle.Make != null)
               result.Make = vehicle.Make;

            if (vehicle.Model != null)
               result.Model = vehicle.Model;

            if (vehicle.LicensePlate != null)
               result.LicensePlate = vehicle.LicensePlate;

            if (vehicle.Color != null)
               result.Color = vehicle.Color;

            if (vehicle.Capacity != 0)
               result.Capacity = vehicle.Capacity;

            if (vehicle.OwnerID != null)
               result.OwnerID = vehicle.OwnerID;

            result.Active = vehicle.Active;
         }
         return context.SaveChanges() > 0;
      }

      public bool DeleteVehicle(Vehicle vehicle)
      {
         var actualVehicle = GetVehicles().Where(m => m.LicensePlate.Equals(vehicle.LicensePlate)).FirstOrDefault();
         actualVehicle.Active = false;
         return UpdateVehicle(actualVehicle);
      }

      public Vehicle GetVehicleByID(int id)
      {
         var result = context.Vehicles.Where(a => a.ID == id && a.Active).FirstOrDefault();
         return result;
      }

        public Vehicle GetVehicleByLicensePlate(string licensePlateNumber)
        {
            Vehicle result = context.Vehicles.Where(v => v.LicensePlate == licensePlateNumber && v.Active).FirstOrDefault();
            return result;
        }

        public Vehicle GetVehicleByOwner(string username)
      {
         return context.Vehicles.FirstOrDefault(v => v.OwnerID == GetUserId(username));
      }
   }
}
