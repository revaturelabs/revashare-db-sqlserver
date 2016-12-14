using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.Data {
    public partial class RevaShareData {
        /// <summary>
        /// Create a new Ride.
        /// </summary>
        /// <param name="ride">The Ride to create.</param>
        /// <returns>True if the creation was successful.</returns>
        public bool CreateRide(Ride ride) {
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
        public Ride GetRide(string userId, DateTime startOfWeek) {
            return context.Rides.FirstOrDefault(r => r.Vehicle.OwnerID == userId && r.StartOfWeekDate == startOfWeek && r.Active);
        }

        /// <summary>
        /// List all of the rides at a given Apartment.
        /// </summary>
        /// <param name="apartmentId">The Id of the Apartment to get Rides from.</param>
        /// <returns>The List of Rides.</returns>
        public List<Ride> ListRidesAtApartment(int apartmentId) {
            return context.Rides.Where(r => r.Vehicle.AspNetUser.Apartment.ID == apartmentId && r.Active).ToList();
        }
    }
}
