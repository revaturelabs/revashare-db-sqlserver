using RevaShare.DataAccess.Data;
using RevaShare.DataClient;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RevaShare.Test
{
    public class UserCRUD
    {
        //Create and Delete Related Methods
        [Fact]
        public void RegisterUserDeleteUser_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();
            ApartmentDAO existingApt = svc.ListApartments().First();

            UserDAO testUser = new UserDAO { Name = "ray bob", UserName = "raybob", Email = "raybob@gmail.com", PhoneNumber = "402-283-2816", Apartment = existingApt };
            bool resultRegisterUser = svc.RegisterUser(testUser, "raybob", "ray2123");
            bool resultDeleteUser = svc.DeleteUser("raybob");

            Assert.True(resultRegisterUser && resultDeleteUser);
        }

        [Fact]
        public void AddAdminDeleteUser_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();
            ApartmentDAO existingApt = svc.ListApartments().First();

            UserDAO testUser = new UserDAO { Name = "ray admin", UserName = "rayadmin", Email = "rayadmin@gmail.com", PhoneNumber = "422-283-2816", Apartment = null };
            bool resultAddAdmin = svc.AddAdmin(testUser, "rayadmin", "ray2123");
            bool resultDeleteUser = svc.DeleteUser("rayadmin");

            Assert.True(resultAddAdmin && resultDeleteUser);
        }


        //Read Related Methods
        [Fact]
        public void GetAllUsers_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();
            List<UserDAO> actual = svc.GetAllUsers();

            foreach (UserDAO user in actual)
            {
                Debug.WriteLine(user.UserName);
            }

            Assert.NotNull(actual);
        }

        [Fact]
        public void GetRiders_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();
            List<UserDAO> actual = svc.GetRiders();

            Assert.NotNull(actual);
        }

        [Fact]
        public void GetDrivers_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();
            List<UserDAO> actual = svc.GetDrivers();

            Assert.NotNull(actual);
        }

        [Fact]
        public void GetAdmins_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();
            List<UserDAO> actual = svc.GetAdmins();

            Assert.NotNull(actual);
        }

        [Fact]
        public void GetPendingRiders_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();
            List<UserDAO> actual = svc.GetPendingRiders();

            Assert.NotNull(actual);
        }

        [Fact]
        public void GetPendingDrivers_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();
            List<UserDAO> actual = svc.GetPendingDrivers();

            Assert.NotNull(actual);
        }

        [Fact]
        public void GetUserByUsername_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();
            UserDAO actual = svc.GetUserByUsername("jimbob");

            Assert.NotNull(actual);
        }


        //Update Related Methods
        [Fact]
        public void UpdateUser_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();
            List<UserDAO> allUsers = svc.GetAllUsers();
            UserDAO userToChange = allUsers.First();

            userToChange.Name = userToChange.Name + " Updated";

            bool actual = svc.UpdateUser(userToChange);

            Assert.True(actual);
        }

        [Fact]
        public void UpdatePassword_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();
            UserDAO userToChange = svc.GetUserByUsername("ray2bob");
            bool change = svc.UpdatePassword("ray2bob", "ray2bob1234", "ray2bob123");
            bool undoChange = svc.UpdatePassword("ray2bob", "ray2bob123", "ray2bob1234");

            Assert.True(change && undoChange);
        }

        [Fact]
        public void Update_User_Privileges_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();

            //Register Test Rider
            ApartmentDAO existingApt = svc.ListApartments().First();
            UserDAO testUser = new UserDAO { Name = "test bob", UserName = "testbob", Email = "testbob@gmail.com", PhoneNumber = "813-283-2816", Apartment = existingApt };
            bool resultRegisterRider = svc.RegisterUser(testUser, "testbob", "testbob123");

            //Approve Rider
            bool resultApproveRider = svc.ApproveRider(testUser.UserName);

            //Rider Requests To Be Driver
            bool resultRequestToBeDriver = svc.RequestToBeDriver(testUser.UserName);

            //Driver Is Approved
            bool resultApproveDriver = svc.ApproveDriver(testUser.UserName);

            //Remove Driver Privileges
            bool resultRemoveDriverPrivileges = svc.RemoveDriverPrivileges(testUser.UserName);

            //Delete Test Driver
            bool resultDriverDeleted = svc.DeleteUser(testUser.UserName);

            Assert.True(
                resultRegisterRider &&
                resultApproveRider &&
                resultRequestToBeDriver &&
                resultApproveDriver &&
                resultRemoveDriverPrivileges &&
                resultDriverDeleted
                );
        }

    }
}
