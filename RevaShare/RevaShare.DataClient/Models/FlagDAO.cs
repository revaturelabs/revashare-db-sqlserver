﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RevaShare.DataClient.Models
{
    [DataContract]
    public class FlagDAO
    {
        [DataMember]
        public int FlagID { get; set; }
        [DataMember]
        public UserDAO Driver { get; set; }
        [DataMember]
        public UserDAO Rider { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}