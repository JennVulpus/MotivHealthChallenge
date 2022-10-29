using System;

namespace MotivHealthChallenge
{
    public interface IDataRepository
    {
        Task<User> GetUser(string username);
    }

    public class DataRepository : IDataRepository
    {
        private readonly DataContext _context;

        public DataRepository(DataContext ctx)
        {
            this._context = ctx;
        }

        public async Task<User> GetUser(string username)
        {
            var user = await _context.Users
                .Where(user => user.Username == username)
                .Include(user => user.Favorites)
                .ToListAsync();

            return user.Single();
        }
    }
}
