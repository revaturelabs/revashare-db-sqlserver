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
    
    public partial class RideRider
    {
        public int RideID { get; set; }
        public string RiderID { get; set; }
        public bool Accepted { get; set; }
        public bool Active { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Ride Ride { get; set; }
    }
}
