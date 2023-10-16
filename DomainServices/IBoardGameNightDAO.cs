using DomainCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices
{
    internal interface IBoardGameNightDAO
    {
        Task Create(BoardGameNight boardGameNight);
        Task<List<BoardGameNight>> Read();
        Task<BoardGameNight> ReadById(int id);
        Task Update(BoardGameNight boardGameNight);
        Task Delete(int id);
    }
}
