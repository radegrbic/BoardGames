using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Domain
{
    internal interface IPerson
    {
        string Name { get; }
        string Email { get; }
        Sex Sex { get; }
        string Street { get; }
        string PostalCode { get; }
        string City { get; }
        string LivingAddress();
    }
}
