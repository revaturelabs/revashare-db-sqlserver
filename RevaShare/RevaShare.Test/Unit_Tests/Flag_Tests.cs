using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
using RevaShare.DataClient;
using RevaShare.DataClient.Models;

namespace RevaShare.Test
{
   public class Flag_Tests
   {
      RevaShareData Data = new RevaShareData();
      private RevaShareDataService svc = new RevaShareDataService();

      #region Flag Tests

      //Create and Delete Related Methods
      [Fact]
      public void CreateFlag_Test()
      {
         RevaShareDataService svc = new RevaShareDataService();
         var flag = new FlagDAO();
         var rider = svc.GetUserByUsername("kimbob");
         var driver = svc.GetUserByUsername("jimbob");
         flag.Driver = driver;
         flag.Rider = rider;
         flag.Message = "test message";
         flag.Type = "unknown";
         var actual = svc.CreateFlag(flag);
         Assert.True(actual);
      }
    

      //Read Related Methods
      [Fact]
      public void GetAllFlags_Test()
      {
         var actual = svc.GetAllFlags();
         Assert.NotEmpty(actual);
      }

      [Fact]
      public void GetFlagByID_Test()
      {
         var actual = svc.GetFlagByID(svc.GetAllFlags().First().FlagID);
         Assert.NotNull(actual);
      }


      //Update Related Methods
      [Fact]
      public void UpdateFlag_Test()
      {
         var flag = svc.GetAllFlags().FirstOrDefault();
         flag.Type = "this is the new type";
         var actual = svc.UpdateFlag(flag);
         Assert.True(actual);
      }

      [Fact]
      public void MarkFlagAsRead_Test()
      {
         var flag = svc.GetAllFlags().FirstOrDefault();
         var actual = svc.MarkFlagAsRead(flag);
         Assert.True(actual);
      }

      #endregion
   }
}
