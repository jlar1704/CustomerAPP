using System;
using System.ComponentModel.DataAnnotations;

namespace Customer_Entity.Entity
{
    public class CustomerAddres
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string CountryId { get; set; }

        [StringLength(20)]
        [Required]
        public string Zone { get; set; }

        [StringLength(100)]
        [Required]
        public string Street { get; set; }

        [StringLength(10)]
        [Required]
        public string Number { get; set; }

        [StringLength(7)]
        [Required]
        public string PostalCode { get; set; }

        [StringLength(10)]
        [Required]
        public string Phone { get; set; }

        [StringLength(100)]
        [Required]
        public string Contact { get; set; }

        [StringLength(15)]
        [Required]
        public string CreatedUserid { get; set; }

        [Required]
        public DateTime Created { get; set; }
    }
}
