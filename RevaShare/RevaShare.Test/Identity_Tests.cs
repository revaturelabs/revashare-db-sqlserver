using RevaShare.DataAccess.Data;
using RevaShare.DataClient;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RevaShare.Test
{
    public class Identity_Tests
    {
        IdentityControlls control = new IdentityControlls();

        [Fact]
        public void Signup_Test()
        {
            var expected = true;
            var actual = control.Signup("Ryan", "ASDasd123");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Login_Test()
        {
            var expected = true;
            var actual = control.Login("Ryan", "ASDasd123");
            Assert.Equal(expected, actual);

            var expected2 = false;
            var actual2 = control.Login("Ryan", "ASD123");

            Assert.Equal(expected2, actual2);
        }

        [Fact]
        public void CreateApartment_Test()
        {
            RevaShareDataService svc = new RevaShareDataService();
            var expected = true;
            var actual = svc.AddApartment(new ApartmentDAO { Name = "Townes", Latitude = "31", Longitude = "32" });

            Assert.Equal(expected, actual);
        }

    }
}
