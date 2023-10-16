using DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices
{
    public interface IPlayerDAO
    {
        Task Create(Player player);
        Task<List<Player>> Read();
        Task<Player> ReadByEmail(string email);
        Task Update(Player player);
        Task Delete(string email);
    }
}
