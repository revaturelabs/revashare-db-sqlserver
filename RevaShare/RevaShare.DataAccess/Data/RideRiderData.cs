using Microsoft.AspNet.Identity.EntityFramework;
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
    private static UserStore<IdentityUser> credentials = new UserStore<IdentityUser>(new Q());

    public bool AddRideRider(UserInfo user, Ride ride)
    {
      var riderider = new RideRider();
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

    public bool AcceptRider(RideRider riderider)
    {
      riderider.Accepted = true;
      UpdateRideRider(riderider);
      return context.SaveChanges() > 0;
    }

    public bool DeleteRideRider(RideRider riderider)
    {
      riderider.Active = false;
      return context.SaveChanges() > 0;
    }

    public RideRider GetRideRiderByID(string id)
    {
      var result = context.RideRiders.Where(a => a.RiderID == id && a.Active).FirstOrDefault();
      return result;
    }

    public RideRider GetRideRiderByName(string name)
    {
            return context.RideRiders.FirstOrDefault(a => a.UserInfo.Name == name && a.Active);           
    }
  }
}
