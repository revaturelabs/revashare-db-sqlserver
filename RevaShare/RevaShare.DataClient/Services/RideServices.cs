using RevaShare.DataAccess;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient
{
   public partial class RevaShareDataService
   {
      public bool AddRide(RideDAO ride)
      {
         return data.CreateRide(RideMapper.MapToRide(ride));
      }

      public bool UpdateRide(RideDAO ride)
      {
         return data.UpdateRide(RideMapper.MapToRide(ride));
      }

      public bool DeleteRide(RideDAO ride)
      {
         return data.DeleteRide(RideMapper.MapToRide(ride));
      }

      public List<RideDAO> ListRidesAtApartment(string apartmentName)
      {
         List<RideDAO> rides = new List<RideDAO>();

         foreach (Ride ride in data.ListRidesAtApartment(apartmentName))
         {
            rides.Add(RideMapper.MapToRideDAO(ride));
         }

         return rides;
      }

      public int GetOpenSeats(RideDAO ride)
      {
         var riders = GetRideRiders().Where(m => m.Ride.Vehicle.LicensePlate.Equals(ride.Vehicle.LicensePlate));
         return ride.Vehicle.Capacity - riders.ToList().Count - 1;
      }

      public List<UserDAO> getRidersInRide(RideDAO ride)
      {
         var riders = GetRideRiders().Where(m => m.Ride.Vehicle.LicensePlate.Equals(ride.Vehicle.LicensePlate));
         var list = new List<UserDAO>();
         foreach (var item in riders)
         {
            list.Add(item.Rider);
         }
         return list;
      }

   }
      public List<RideDAO> ListRidesAtApartmentAM(string apartmentName)
      {
         return ListRidesAtApartment(apartmentName).Where(m => m.IsAmRide).ToList();
      }

      public List<RideDAO> ListRidesAtApartmentPM(string apartmentName)
      {
         return ListRidesAtApartment(apartmentName).Where(m => !m.IsAmRide).ToList();
      }

      
   }
}