using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevaShare.DataClient {
    public partial class RevaShareDataService {
        public ApartmentDAO GetApartmentByName(string name) {
            return ApartmentMapper.MapToApartmentDAO(data.GetApartmentByName(name));
        }

        public bool AddApartment(ApartmentDAO apartment) {
            return data.CreateApartment(ApartmentMapper.MapToApartment(apartment));
        }

        public List<ApartmentDAO> ListApartments() {
            var r = new List<ApartmentDAO>();

            foreach (var apartment in data.ListApartments()) {
                r.Add(ApartmentMapper.MapToApartmentDAO(apartment));
            }
            return r;
        }

        public bool UpdateApartment(ApartmentDAO apartment) {
            return data.UpdateApartment(ApartmentMapper.MapToApartment(apartment));
        }

        public bool DeleteApartment(string apartmentName) {
            return data.DeleteApartment(apartmentName);
        }
    }
}