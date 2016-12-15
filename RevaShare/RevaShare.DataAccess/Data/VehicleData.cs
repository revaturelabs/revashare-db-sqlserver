using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RevaShare.DataAccess.Data
{
  public partial class RevaShareData
  {
    public List<Vehicle> GetVehicles()
    {
      return context.Vehicles.ToList();
    }

    public bool AddVehicle(Vehicle vehicle)
    {
      context.Vehicles.Add(vehicle);
      return context.SaveChanges() > 0;
    }   

    public bool UpdateVehicle(Vehicle vehicle)
    {
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
      vehicle.Active = false;
      return context.SaveChanges() > 0;
    }

    public Vehicle GetVehicleByID(int id)
    {
      var result = context.Vehicles.Where(a => a.ID == id && a.Active).FirstOrDefault();
      return result;
    }
  }
}
