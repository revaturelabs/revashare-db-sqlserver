using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
using RevaShare.DataClient;
using RevaShare.DataClient.Models;
using Xunit;

namespace RevaShare.Test
{
   public class RideRider_Tests
   {
      RevaShareData Data = new RevaShareData();
      private RevaShareDataService svc = new RevaShareDataService();

      #region RideRider Tests

      //Create and Delete Related Methods
      [Fact]
      public void AddRideRider_Test()
      {
         var ride = svc.ListRidesAtApartment("abc").FirstOrDefault();
         var rider = svc.GetUserByUsername("johnbob");
         var actual = svc.AddRideRiders(rider, ride);
         Assert.True(actual);
      }

      [Fact]
      public void DeleteRideRider_Test()
      {
         var rr = svc.GetRideRiders().Where(rideRider => rideRider.Rider.UserName == "johnbob").First();

         var actual = svc.DeleteRideRider(rr);
         Assert.True(actual);
      }


      //Read Related Methods
      [Fact]
      public void GetRideRiders_Test()
      {
         var rr = svc.GetRideRiders();
         Assert.NotNull(rr);
      }

      [Fact]
      public void GetRiders_Tests()
      {
         var ride = svc.ListRidesAtApartment("abc");
         UserDAO actual = null;
         foreach (var item in ride)
         {
            actual = svc.getRidersInRide(item).FirstOrDefault();
         }

         Assert.NotNull(actual);
      }
    

      //Update Related Methods
      [Fact]
      public void UpdateRideRider_Test()
      {
         var rr = svc.GetRideRiders().FirstOrDefault();
         rr.Accepted = true;
         var actual = svc.UpdateRideRider(rr);
         Assert.True(actual);

      }

      [Fact]
      public void AcceptRideRider_Test()
      {
         var rr = svc.GetRideRiders().FirstOrDefault();

         var actual = svc.AcceptRideRequest(rr);
         Assert.True(actual);
      }

      #endregion
   }
}
