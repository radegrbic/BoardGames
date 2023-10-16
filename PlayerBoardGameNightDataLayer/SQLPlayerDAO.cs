using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainCore;
using DomainServices;
using Microsoft.EntityFrameworkCore;

namespace PlayerBoardGameNightDataLayer
{
    internal class SQLPlayerDAO : IPlayerDAO
    {
        private PlayerBoardGameNightDbContext _dbContext;

        public SQLPlayerDAO(PlayerBoardGameNightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /**
         * Create Player in database
         * Create IdentityUser in database
         * Param: new player, new IdentityUser
         */
        public async Task Create(Player player)
        {
            await _dbContext.Player.AddAsync(player);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Player>> Read()
        {
            return await _dbContext.Player.ToListAsync();
        }

        /**
         * Read Player by email
         * Param: email to find Player
         */
        public async Task<Player?> ReadByEmail(string email)
        {
            return email != null ? await _dbContext.Player.FirstOrDefaultAsync<Player>(player => player.Email.Equals(email)) : null;
        }

        /**
         * Find Player by email
         * Update Player
         * Param: new Player 
         */
        public async Task Update(Player newPlayer)
        {
            _dbContext.Player.Update(newPlayer);
            await _dbContext.SaveChangesAsync();
        }

        /**
         * Find Player by email
         * Delete Player by email
         * Param: Player's email 
         */
        public async Task Delete(string email)
        {
            var foundCustomer = await ReadByEmail(email);

            if(foundCustomer != null)
            {
                _dbContext.Player.Remove(foundCustomer);
                await _dbContext.SaveChangesAsync();
            } 

            
        }
    }
}
