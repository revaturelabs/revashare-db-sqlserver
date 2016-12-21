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
        public void GetUserByUsername_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();
            UserDAO actual = svc.GetUserByUsername("jimbob");
           
            Assert.NotNull(actual);
        }

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

            UserDAO testUser = new UserDAO { Name = "ray admin", UserName = "rayadmin", Email = "rayadmin@gmail.com", PhoneNumber = "422-283-2816", Apartment = existingApt };
            bool resultAddAdmin = svc.AddAdmin(testUser, "rayadmin", "ray2123");
            bool resultDeleteUser = svc.DeleteUser("rayadmin");

            Assert.True(resultAddAdmin && resultDeleteUser);
        }

    }
}
