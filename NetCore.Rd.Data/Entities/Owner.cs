using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Rd.Data.Entities
{
    [Table("Owner")]
    public class Owner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateEdition { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
    }
}