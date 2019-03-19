using System;
using System.Collections.Generic;
using NetCore.Rd.Data.Entities;

namespace NetCore.Rd.Data.Dto
{
    public class OwnerDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        // public ICollection<Apartment> Apartments { get; set; }
    }
}