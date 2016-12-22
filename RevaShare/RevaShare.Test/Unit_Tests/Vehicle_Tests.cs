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
   public class Vehicle_Tests
   {
      RevaShareData Data = new RevaShareData();
      private RevaShareDataService svc = new RevaShareDataService();

      #region Vehicle tests

      //Create and Delete Related Methods
      [Fact]
      public void AddVehicle_Test()
      {
         var owner = svc.GetAllUsers().FirstOrDefault();
         var vehicle = new VehicleDAO() { Capacity = 4, Color = "orange", LicensePlate = "qwe-ewq", Make = "test make2", Model = "test model2", Owner = owner };
         var actual = svc.AddVehicle(vehicle);
         Assert.True(actual);
      }

      [Fact]
      public void DeleteVehicle_Test()
      {
         var car = svc.GetVehicles().Where(m => m.Color.Equals("yellow")).FirstOrDefault();

         var actual = svc.DeleteVehicle(car);
         Assert.True(actual);
      }
    

      //Read Related Methods
      [Fact]
      public void GetVehicles_Test()
      {
         var actual = svc.GetVehicles();
         Assert.NotEmpty(actual);
      }

    
      //Update Related Methods
      [Fact]
      public void UpdateVehicle_Test()
      {
         var car = svc.GetVehicles().FirstOrDefault();
         car.Color = "green grey";
         var actual = svc.UpdateVehicle(car);
         Assert.True(actual);
      }

      #endregion
   }
}
