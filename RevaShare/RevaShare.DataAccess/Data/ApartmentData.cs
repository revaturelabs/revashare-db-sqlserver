using RevaShare.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevaShare.DataAccess.Data
{
   public partial class RevaShareData
   {

      public bool CreateApartment(Apartment apartment)
      {
         apartment.Active = true;
         context.Apartments.Add(apartment);
         return context.SaveChanges() > 0;
      }

      public Apartment GetApartment(int apartmentId)
      {
         return context.Apartments.FirstOrDefault(a => a.ID == apartmentId && a.Active);
      }

      public Apartment GetApartmentByName(string name)
      {
         return context.Apartments.FirstOrDefault(a => a.Name == name && a.Active);
      }

      public List<Apartment> ListApartments()
      {
         return context.Apartments.Where(a => a.Active).ToList();
      }

      public bool UpdateApartment(Apartment apartment)
      {
         var actualApartment = GetApartmentByName(apartment.Name);
         actualApartment.Active = apartment.Active;
         actualApartment.Latitude = apartment.Latitude;
         actualApartment.Longitude = apartment.Longitude;
         actualApartment.Name = apartment.Name;
         DbEntityEntry<Apartment> entry = context.Entry(actualApartment);
         entry.State = System.Data.Entity.EntityState.Modified;
         return context.SaveChanges() > 0;
      }

      public bool DeleteApartment(string apartmentName)
      {
         var apartment = GetApartmentByName(apartmentName);
         apartment.Active = false;
         return UpdateApartment(apartment);
      }
   }
}
