using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
using RevaShare.DataClient.Mappers;

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
  public partial class RevaShareDataService : IRevaShareDataService
  {
    private RevaShareDBEntities _context;
    public RevaShareDataService(RevaShareDBEntities context)
    {
      _context = context;
    }

    public RevaShareDataService()
        {
            _context = new RevaShareDBEntities();
        }

    RevaShareData data = new RevaShareData();


    



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


    public List<RideDAO> ApartmentRides()

  
    {
      throw new NotImplementedException();
    }
  }
}
