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

    }
}
