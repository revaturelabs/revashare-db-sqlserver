using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.Data
{
  public partial class RevaShareData
  {
    public List<RideRider> GetRideRiders()
    {
      
      return context.RideRiders.ToList();
    }

    public bool AddRideRider(Ride ride, RideRider riderider)
    {     
      riderider.RideID = ride.ID;
      //v.ID = r.VehicleID;
      
      context.RideRiders.Add(riderider);
      return context.SaveChanges() > 0;
    }

    public bool UpdateRideRider(RideRider riderider)
    {
      var result = context.RideRiders.SingleOrDefault(x => x.RiderID == riderider.RiderID);

      if (result != null)
      {
        if (riderider.RideID != 0)
          result.RideID = riderider.RideID;

        if (riderider.RiderID != null)
          result.RiderID = riderider.RiderID;

        result.Accepted = riderider.Accepted;        

        result.Active = riderider.Active;
      }
      return context.SaveChanges() > 0;
    }

    public bool DeleteRideRider(string id)
    {
      var riderider = context.RideRiders.Where(x => x.RiderID == id).FirstOrDefault();
      context.RideRiders.Remove(riderider);
      return context.SaveChanges() > 0;
    }

    public List<RideRider> GetRideRiderByID(string id)
    {
      var result = context.RideRiders.Where(a => a.RiderID == id);
      return result.ToList();
    }
  }
}
