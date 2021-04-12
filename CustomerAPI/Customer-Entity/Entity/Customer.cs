using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Customer_Entity.Entity
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [StringLength(11)]
        [Required]
        public string RNC { get; set; }

        [StringLength(300)]
        [Required]
        public string Name { get; set; }

        [Required]
        public bool Active { get; set; }

        [StringLength(15)]
        [Required]
        public string CreatedUserid { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public ICollection<CustomerAddres> CustomerAddreses { get; set; }

    }
}
