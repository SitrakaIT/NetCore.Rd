using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore.Rd.Data.Entities
{
    [Table("Apartment")]
    public class Apartment
    {
        public int ID { get; set; }
        public Guid IdentifierApartment { get; set; }
        public string ApartmentName { get; set; }
        public int ApartmentNumber { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateEdition { get; set; }
        [ForeignKey("OwnerID")]
        public int? OwnerID { get; set; }
        public Owner Owner { get; set; }
    }
}