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

            UserDAO testUser = new UserDAO { Name = "ray2 bob", UserName = "ray2bob", Email = "ray2bob@gmail.com", PhoneNumber = "402-283-2816", Apartment = existingApt };
            bool resultRegister = svc.RegisterUser(testUser, "ray2bob", "ray2123");
            bool resultDelete = svc.DeleteUser("ray2bob");

            Assert.True(resultRegister && resultDelete);
        }
        
    }
}
