//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RevaShare.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ride
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ride()
        {
            this.RideRiders = new HashSet<RideRider>();
        }
    
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public System.DateTime StartOfWeekDate { get; set; }
        public Nullable<System.TimeSpan> DepartureTime { get; set; }
        public bool IsAmRide { get; set; }
        public bool IsOnTime { get; set; }
        public bool Active { get; set; }
    
        public virtual Vehicle Vehicle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RideRider> RideRiders { get; set; }
    }
}
