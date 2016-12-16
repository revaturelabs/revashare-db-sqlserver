using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.MoqRepo
{
  public class VehicleRepo : IVehicle
  {
    public List<Vehicle> ListVehicles()
    {
      var vehicleList = new List<Vehicle>();
      vehicleList.Add(
      new Vehicle
      {
        ID = 1,
        OwnerID = "user1",
        Make = "Toyota",
        Model = "Tacoma",
        LicensePlate = "OU812",
        Color= "Green",
        Capacity = 2,
        Active = true
      });
      vehicleList.Add(
      new Vehicle
      {
        ID = 2,
        OwnerID = "user2",
        Make = "Chevy",
        Model = "S10",
        LicensePlate = "WXK294",
        Color = "Red",
        Capacity = 1,
        Active = true
      });
      vehicleList.Add(
      new Vehicle
      {
        ID = 3,
        OwnerID = "user3",
        Make = "Ford",
        Model = "Pinto",
        LicensePlate = "001SUX",
        Color = "Yellow",
        Capacity = 3,
        Active = true
      });
      return vehicleList;
    }
  }
}
