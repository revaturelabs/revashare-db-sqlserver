using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.MoqRepo
{
  public class ApartmentRepo : IApartment
  {
    public List<Apartment> ListApartments()
    {
      var apartmentList = new List<Apartment>();
      apartmentList.Add(
        new Apartment
        {
          ID = 1,
          Name = "The Townes",
          Latitude = "50.3",
          Longitude = "120.2"
        });
      apartmentList.Add(
        new Apartment
        {
          ID = 2,
          Name = "The Townes",
          Latitude = "50.4",
          Longitude = "120.7"
        });
      return apartmentList;
    }
  }
}
