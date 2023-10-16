using DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices
{
    internal interface IOrganisorDAO
    {
        Task Create(Organisor organisor);
        Task<List<Organisor>> Read();
        Task<Organisor> ReadById(int id);
        Task Update(Organisor organisor);
        Task Delete(int id);
    }
}
