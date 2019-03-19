using System;
using System.Collections.Generic;
using NetCore.Rd.Data.Entities;

namespace NetCore.Rd.Data.Dto
{
    public class ApartmentDto
    {
        public int ID { get; set; }
        public string ApartmentName { get; set; }
        public int ApartmentNumber { get; set; }
        // public int? OwnerID { get; set; }
        public Owner Owner { get; set; }
        
        
    }
}