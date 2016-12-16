using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.MoqRepo
{
  public class RideRepo : IRide
  {
    public List<Ride> ListRides()
    {
      var rideList = new List<Ride>();
      rideList.Add(
        new Ride
        {
          ID = 1,
          VehicleID = 1,
          StartOfWeekDate = DateTime.Parse("12/12/2016"),
          DepartureTime = TimeSpan.Parse("08:00"),
          IsOnTime = true,
          Active= true
        });
      rideList.Add(
       new Ride
       {
         ID = 2,
         VehicleID = 2,
         StartOfWeekDate = DateTime.Parse("12/13/2016"),
         DepartureTime = TimeSpan.Parse("08:30"),
         IsOnTime = true,
         Active = true
       });
      return rideList;
    }
  }
}
