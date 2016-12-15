using RevaShare.DataAccess;
using RevaShare.DataClient;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using RevaShare.DataAccess.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.Test
{
  public class MockContext : DbContext
  {
    public virtual DbSet<Apartment> Apartments { get; set; }
    public virtual DbSet<Ride> Rides { get; set; }
    public virtual DbSet<RideRider> RideRiders { get; set; }
    public virtual DbSet<Vehicle> Vehicles { get; set; }
    public virtual DbSet<Flag> Flags { get; set; }
    public virtual DbSet<UserInfo> UserInfoes { get; set; }
    MockContext _context;
    internal Apartment GetApartment(int id)
    {
      throw new NotImplementedException();
    }

    internal RideRider GetRideRiderByID(string id)
    {
      throw new NotImplementedException();
    }

    internal IEnumerable<RideRider> GetRideRiders()
    {
      throw new NotImplementedException();
    }

    internal Vehicle GetVehicleByID(int id)
    {
      throw new NotImplementedException();
    }

    internal Apartment GetApartmentByName(string name)
    {
      throw new NotImplementedException();
    }

    internal bool AcceptRider(RideRider rideRider)
    {
      throw new NotImplementedException();
    }

    internal bool UpdateRideRider(RideRider rideRider)
    {
      throw new NotImplementedException();
    }

    internal bool DeleteRideRider(RideRider rideRider)
    {
      throw new NotImplementedException();
    }

    internal bool AddVehicle(Vehicle vehicle)
    {
      throw new NotImplementedException();
    }

    internal bool UpdateVehicle(Vehicle vehicle)
    {
      throw new NotImplementedException();
    }

    internal bool DeleteVehicle(Vehicle vehicle)
    {
      throw new NotImplementedException();
    }

    internal bool CreateApartment(Apartment apartment)
    {
      var f = new Apartment { ID = apartment.ID, Name = apartment.Name, Latitude = apartment.Latitude, Longitude = apartment.Longitude, Active = apartment.Active };
      _context.Apartments.Add(f);

      return _context.SaveChanges() > 0;
    }

    internal List<Apartment> ListApartments()
    {
      var query = from b in _context.Apartments
                  orderby b.Name
                  select b;

      return query.ToList();
    }

    internal bool UpdateApartment(Apartment apartment)
    {
      throw new NotImplementedException();
    }

    internal bool DeleteApartment(Apartment apartment)
    {
      throw new NotImplementedException();
    }

    internal bool Create(Flag flag)
    {
      var f = new Flag {ID = flag.ID,  DriverID = flag.DriverID, RiderID = flag.RiderID, Type = flag.Type, Message = flag.Message, Active = flag.Active };
      _context.Flags.Add(f);     

      return _context.SaveChanges() > 0; 
    }

    internal Flag GetFlag(int id)
    {
      throw new NotImplementedException();
    }

    internal IEnumerable<Flag> ListFlags()
    {
      var query = from b in _context.Flags
                  orderby b.DriverID
                  select b;

      return query.ToList();

    }

    internal bool MarkFlagAsRead(Flag flag)
    {
      throw new NotImplementedException();
    }
  }

  

  

  public class MockService
  {
    private MockContext _context;

    public MockService(MockContext context)
    {
      _context = context;
    }

    public ApartmentDAO GetApartment(int id)
    {
      return ApartmentMapper.MapToApartmentDAO(_context.GetApartment(id));
    }

    public RideRidersDAO GetRideRiderById(string id)
    {
      return RideRiderMapper.MapToRideRiderDAO(_context.GetRideRiderByID(id));
    }

    public List<RideRidersDAO> GetRideRiders()
    {
      var r = new List<RideRidersDAO>();

      foreach (var rider in _context.GetRideRiders())
      {
        r.Add(RideRiderMapper.MapToRideRiderDAO(rider));
      }
      return r;
    }

    public VehicleDAO GetVehicleById(int id)
    {
      return VehicleMapper.MapToVehicleDAO(_context.GetVehicleByID(id));
    }

    public ApartmentDAO GetApartmentByName(string name)
    {
      return ApartmentMapper.MapToApartmentDAO(_context.GetApartmentByName(name));
    }

    public UserDAO logIn()
    {
      throw new NotImplementedException();
    }

    public RideDAO passRide()
    {
      return new RideDAO();
    }

    public RideRidersDAO passRideRider()
    {
      return new RideRidersDAO();
    }

    public UserDAO passUser()
    {
      return new UserDAO();
    }

    public UserDAO register()
    {
      throw new NotImplementedException();
    }

    public bool AddRide(RideDAO ride)
    {
      throw new NotImplementedException();
    }

    public bool UpdateRide(RideDAO ride)
    {
      throw new NotImplementedException();
    }

    public bool DeleteRide(RideDAO ride)
    {
      throw new NotImplementedException();
    }

    public bool AddRideRiders(UserDAO user, RideDAO ride)
    {
      // return _context.AddRideRider(UserMapper.MapToUser(user) ,RideMapper.MapToRide(ride));
      return false;
    }

    public bool Accept(RideRidersDAO riderider)
    {
      return _context.AcceptRider(RideRiderMapper.MapToRideRider(riderider));
    }

    public bool UpdateRideRider(RideRidersDAO riderider)
    {
      return _context.UpdateRideRider(RideRiderMapper.MapToRideRider(riderider));
    }

    public bool DeleteRideRider(RideRidersDAO rider)
    {
      return _context.DeleteRideRider(RideRiderMapper.MapToRideRider(rider));
    }

    public bool AddVehicle(VehicleDAO vehicle)
    {
      return _context.AddVehicle(VehicleMapper.MapToVehicle(vehicle));
    }

    public bool UpdateVehicle(VehicleDAO vehicle)
    {
      return _context.UpdateVehicle(VehicleMapper.MapToVehicle(vehicle));
    }

    public bool DeleteVehicle(VehicleDAO vehicle)
    {
      return _context.DeleteVehicle(VehicleMapper.MapToVehicle(vehicle));
    }

    public VehicleDAO GetVehicleByID(int id)
    {
      return VehicleMapper.MapToVehicleDAO(_context.GetVehicleByID(id));
    }

    public bool AddApartment(ApartmentDAO apartment)
    {
      return _context.CreateApartment(ApartmentMapper.MapToApartment(apartment));
    }

    public List<ApartmentDAO> ListApartments()
    {
      var r = new List<ApartmentDAO>();

      foreach (var apartment in _context.ListApartments())
      {
        r.Add(ApartmentMapper.MapToApartmentDAO(apartment));
      }
      return r;
    }

    public bool UpdateApartment(ApartmentDAO apartment)
    {
      return _context.UpdateApartment(ApartmentMapper.MapToApartment(apartment));
    }

    public bool DeleteApartment(ApartmentDAO apartment)
    {
      return _context.DeleteApartment(ApartmentMapper.MapToApartment(apartment));
    }

    public bool Create(FlagDAO flag)
    {
      return _context.Create(FlagMapper.MapToFlag(flag));
    }

    public FlagDAO GetFlag(int id)
    {
      return FlagMapper.MapToFlagDAO(_context.GetFlag(id));
    }

    public List<FlagDAO> ListFlags()
    {
      var r = new List<FlagDAO>();

      foreach (var flag in _context.ListFlags())
      {
        r.Add(FlagMapper.MapToFlagDAO(flag));
      }
      return r;
    }

    public bool MarkFlagAsRead(FlagDAO flag)
    {
      return _context.MarkFlagAsRead(FlagMapper.MapToFlag(flag));
    }

  }
}
