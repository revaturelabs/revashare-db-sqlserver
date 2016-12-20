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
      /// <summary>
      /// Create an Apartment.
      /// </summary>
      /// <param name="apartment">The apartment to create.</param>
      /// <returns>True if the addition was successful.</returns>
      public bool CreateApartment(Apartment apartment)
      {
         apartment.Active = true;
         context.Apartments.Add(apartment);
         return context.SaveChanges() > 0;
      }

      /// <summary>
      /// Get a single Apartment object.
      /// </summary>
      /// <param name="apartmentId">The Id of the Apartment.</param>
      /// <returns>The Apartment object if it exists or null if it does not.</returns>
      public Apartment GetApartment(int apartmentId)
      {
         return context.Apartments.FirstOrDefault(a => a.ID == apartmentId && a.Active);
      }

      /// <summary>
      /// Get a single Apartment object by its name.
      /// </summary>
      /// <param name="name">The name of the Apartment.</param>
      /// <returns>The Apartment object if it exists or null if it does not.</returns>
      public Apartment GetApartmentByName(string name)
      {
         return context.Apartments.FirstOrDefault(a => a.Name == name && a.Active);
      }

      /// <summary>
      /// List all of the Apartment objects.
      /// </summary>
      /// <returns>The List of Apartments.</returns>
      public List<Apartment> ListApartments()
      {
         return context.Apartments.Where(a => a.Active).ToList();
      }

      /// <summary>
      /// Update an Apartment. Make sure to get the original Apartment using
      /// GetApartment or GetApartmentByName.
      /// </summary>
      /// <param name="apartment">The Apartment to update.</param>
      /// <returns>True if the update was successful.</returns>
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

      /// <summary>
      /// Delete an Apartment. Make sure to get the original Apartment using
      /// GetApartment or GetApartmentByName.
      /// </summary>
      /// <param name="apartment">The Apartment to delete.</param>
      /// <returns>True if the deletion was successful.</returns>
      public bool DeleteApartment(string apartmentName)
      {
         var apartment = GetApartmentByName(apartmentName);
         apartment.Active = false;
         return UpdateApartment(apartment);
      }
   }
}
