using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
﻿using RevaShare.DataAccess.Data;
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

    public RideRidersDAO GetRideRiderById(string id)
    {
      return RideRiderMapper.MapToRideRiderDAO(data.GetRideRiderByID(id));
    }

    public List<RideRidersDAO> GetRideRiders()
    {
      var r = new List<RideRidersDAO>();

      foreach (var rider in data.GetRideRiders())
      {
        r.Add(RideRiderMapper.MapToRideRiderDAO(rider));
      }
      return r;      
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

    public bool AddRideRiders(RideDAO ride, RideRidersDAO rideriders)
    {
      return data.AddRideRider(RideMapper.MapToRide(ride),RideRiderMapper.MapToRideRider(rideriders));
    }

    public bool UpdateRideRider(RideRidersDAO riderider)
    {
      return data.UpdateRideRider(RideRiderMapper.MapToRideRider(riderider));
    }

    public bool DeleteRideRider(RideRidersDAO rider)
    {
      return data.DeleteRideRider(RideRiderMapper.MapToRideRider(rider));
    }

    public bool AddVehicle(VehicleDAO vehicle)
    {
      return data.AddVehicle(VehicleMapper.MapToVehicle(vehicle));
    }

    public bool UpdateVehicle(VehicleDAO vehicle)
    {
      return data.UpdateVehicle(VehicleMapper.MapToVehicle(vehicle));
    }

    public bool DeleteVehicle(VehicleDAO vehicle)
    {
      return data.DeleteVehicle(VehicleMapper.MapToVehicle(vehicle));
    }

    public VehicleDAO GetVehicleByID(int id)
    {
      return VehicleMapper.MapToVehicleDAO(data.GetVehicleByID(id));
    }

    public bool AddApartment(ApartmentDAO apartment)
    {
      return data.CreateApartment(ApartmentMapper.MapToApartment( apartment));
    }

    public List<ApartmentDAO> ListApartments()
    {
      var r = new List<ApartmentDAO>();

      foreach (var apartment in data.ListApartments())
      {
        r.Add(ApartmentMapper.MapToApartmentDAO(apartment));
      }
      return r;
    }

    public bool UpdateApartment(ApartmentDAO apartment)
    {
      return data.UpdateApartment(ApartmentMapper.MapToApartment(apartment));
    }

    public bool DeleteApartment(ApartmentDAO apartment)
    {
      return data.DeleteApartment(ApartmentMapper.MapToApartment(apartment));
    }
  }
}
