using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient.Mappers
{
   public class FlagMapper
   {
      private static RevaShareData data = new RevaShareData();
      public static Flag MapToFlag(FlagDAO flag)
      {
         var u = new Flag();
         u.ID = (flag.FlagID - 2) / 3;
         u.DriverID = data.GetUserId(flag.Driver.UserName);
         u.RiderID = data.GetUserId(flag.Rider.UserName);
         u.Type = flag.Type;
         u.Message = flag.Message;
         u.Active = true;
         

         return u;
      }

      public static FlagDAO MapToFlagDAO(Flag flag)
      {
         var driver = data.GetIdentityUser(flag.DriverID);
         var driverInfo = data.GetUser(driver.UserName);

         var rider = data.GetIdentityUser(flag.RiderID);
         var riderInfo = data.GetUser(rider.UserName);

         var u = new FlagDAO();
         u.FlagID = flag.ID;
         u.Driver = UserMapper.MapToUserDAO(driver, driverInfo);
         u.Rider = UserMapper.MapToUserDAO(rider, riderInfo);
         u.Type = flag.Type;
         u.Message = flag.Message;

         return u;
      }
   }
}