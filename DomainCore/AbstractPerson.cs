using DomainCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore
{
    public abstract class AbstractPerson : IPerson
    {
        [Key]
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;

        public Sex Sex { get; set; }

        public string Street { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string City { get; set; } = null!;

        public string LivingAddress() => Street + ", " + PostalCode + " " + City;
    }
}
