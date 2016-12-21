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

    public List<RideDAO> GetAllRides()
    {
      List<Ride> allRides = data.ListAllRides();
      List<RideDAO> allRidesDAO = new List<RideDAO>();

      foreach (Ride ride in allRides)
      {
        allRidesDAO.Add(RideMapper.MapToRideDAO(ride));
      }

      return allRidesDAO;
    }

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
      Ride rideToDelete = data.GetRide(UserMapper.MapToUser(ride.Vehicle.Owner).UserID, ride.StartOfWeek);
      return data.DeleteRide(rideToDelete);
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
