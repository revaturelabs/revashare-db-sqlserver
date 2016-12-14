using RevaShare.DataAccess.Data;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RevaShare.DataClient
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RevaShareDataService" in code, svc and config file together.
  // NOTE: In order to launch WCF Test Client for testing this service, please select RevaShareDataService.svc or RevaShareDataService.svc.cs at the Solution Explorer and start debugging.
  public class RevaShareDataService : IRevaShareDataService
  {
    RevaShareData data = new RevaShareData();
    public ApartmentDAO GetApartment(int id)
    {
      return ApartmentMapper.MapToApartmentDAO(data.GetApartment(id));
    }

    public RideRidersDAO GetRideRiderById(int id)
    {
      throw new NotImplementedException();
    }

    public RideRidersDAO GetRideRiders()
    {
      throw new NotImplementedException();
    }

    public VehicleDAO GetVehicleById(int id)
    {
      return VehicleMapper.MapToVehicleDAO(data.GetVehicleByID(id));
    }

    public ApartmentDAO GetApartmentByName(string name)
    {
      return ApartmentMapper.MapToApartmentDAO(data.GetApartmentByName(name));
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
  }
}
