using RevaShare.DataAccess;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient
{
    public class ApartmentMapper
    {
        public static ApartmentDAO MapToApartmentDAO(Apartment apartment)
        {
            var c = new ApartmentDAO();
            c.Name = apartment.Name;
            c.Latitude = apartment.Latitude;
            c.Longitude = apartment.Longitude;

            return c;
        }

        public static Apartment MapToApartment(ApartmentDAO apartment)
        {
            var c = new Apartment();
            c.Name = apartment.Name;
            c.Latitude = apartment.Latitude;
            c.Longitude = apartment.Longitude;

            return c;
        }

    }
}