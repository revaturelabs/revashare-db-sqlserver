using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.MoqRepo
{
  public class RideRiderRepo : IRideRider
  {
    public List<RideRider> ListRideRiders()
    {
      var rrList = new List<RideRider>();
      rrList.Add(
      new RideRider
      {
          RideID = 1,
          RiderID = "user6",
          Active = true
      });
      rrList.Add(
     new RideRider
     {
       RideID = 2,
       RiderID = "user4",
       Active = true
     });
      rrList.Add(
     new RideRider
     {
       RideID = 2,
       RiderID = "user5",
       Active = true
     });
      return rrList;
    }
  }
}
