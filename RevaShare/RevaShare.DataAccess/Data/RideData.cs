using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.Data
{
  public partial class RevaShareData
  {
    /// <summary>
    /// Create a new Ride.
    /// </summary>
    /// <param name="ride">The Ride to create.</param>
    /// <returns>True if the creation was successful.</returns>
    public bool CreateRide(Ride ride)
    {
      ride.Active = true;
      context.Rides.Add(ride);
      return context.SaveChanges() > 0;
    }

    /// <summary>
    /// Get a Ride from the user Id and day of week for Sunday.
    /// </summary>
    /// <param name="userId">The user Id.</param>
    /// <param name="startOfWeek">Sunday for the current week.</param>
    /// <returns>The Ride if it exists, null if it does not.</returns>
    public Ride GetRide(string userId, DateTime startOfWeek)
    {
      return context.Rides.FirstOrDefault(r => r.Vehicle.OwnerID == userId && r.StartOfWeekDate == startOfWeek && r.Active);
    }

    /// <summary>
    /// List all of the rides at a given Apartment.
    /// </summary>
    /// <param name="apartmentId">The Id of the Apartment to get Rides from.</param>
    /// <returns>The List of Rides.</returns>
    public List<Ride> ListRidesAtApartment(string name)
    {
      return context.Rides.Where(r => r.Vehicle.UserInfo.Apartment.Name == name && r.Active).ToList();
    }

    public bool UpdateRide(Ride ride)
    {
      var result = context.Rides.SingleOrDefault(x => x.ID == ride.ID);

      if (result != null)
      {
        if (ride.ID != 0)
          result.ID = ride.ID;

        if (ride.VehicleID != 0)
          result.VehicleID = ride.VehicleID;

        if (ride.StartOfWeekDate != null)
          result.StartOfWeekDate = ride.StartOfWeekDate;

        if (ride.DepartureTime != null)
          result.DepartureTime = ride.DepartureTime;

        result.IsOnTime = ride.IsOnTime;

        result.Active = ride.Active;
      }
      return context.SaveChanges() > 0;
    }

    public bool DeleteRide(Ride ride)
    {
      ride.Active = false;
      return context.SaveChanges() > 0;
    }
  }
}
