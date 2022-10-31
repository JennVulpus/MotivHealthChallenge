using Microsoft.AspNetCore.Mvc;

namespace MotivHealthChallenge.Controllers
{

    [Route("[Controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;
        private readonly DataContext _context;

        public FavoriteController(IDataRepository dataRepo, DataContext context)
        {
            _context = context;
            _dataRepository = dataRepo;
        }

        [HttpGet]
        public async Task<List<User>> GetAllUsers()
        {
            return await _dataRepository.GetAllUsers();
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            var user = await _dataRepository.GetUser(username);
            if (user == null)
                return NotFound("User not found");
            return Ok(user);
        }
        [HttpGet]
        [Route("count")]
        public async Task<ActionResult<List<Favorite>>> GetCount()
        {
            int count = 0;
            var data = await _context.Favorites.ToListAsync(); //_dataRepository.GetFavorites();
         
            foreach(var item in data)
            {
                count += 1;
            }
            return Ok(count);
        }
        [HttpGet]
        [Route("unique")]
        public async Task<ActionResult<List<Favorite>>> GetUnique()
        {
            int count = 0;
            Dictionary<string,int> memo = new();
            var data = await _context.Favorites.ToListAsync();
            foreach (var item in data)
            {
                if (!memo.ContainsKey(item.Name))
                {
                    memo[item.Name] = 1;
                    count += 1;
                }
            }
            return Ok(count);
        }

        [HttpPost("{username}")]
        public async Task<ActionResult<User>> PostUser(string username, List<Favorite> favorites)
        {
            var user = await _dataRepository.GetUser(username);
            if (user == null)
                return NotFound("User not found");

            user.Favorites = favorites;

            await _context.SaveChangesAsync();

            return Ok(user.Username);
        }

        [HttpPut("{username}")]
        public async Task<ActionResult<List<User>>> PutUser(string username, List<Favorite> favorites)
        {
            var user = await _dataRepository.GetUser(username);
            if (user == null)
                return NotFound("User not found");

            
            var favs = await _context.Favorites
                .Where(fav => fav.UserId == user.Id)
                .ToListAsync();
            
            foreach(var fav in favs)
            {
                _context.Favorites.Remove(fav);
            }
            user.Favorites = favorites;
            await _context.SaveChangesAsync();

            return Ok(user);
        }
        [HttpPatch("{username}")]
        public async Task<ActionResult<List<User>>> PatchUser(string username, List<Favorite> favorites)
        {
            var user = await _dataRepository.GetUser(username);
            if (user == null)
                return NotFound("User not found");

            user.Favorites = favorites;

            await _context.SaveChangesAsync();

            return Ok(user);
        }
        [HttpDelete("{username}")]
        public async Task<ActionResult<List<User>>> DeleteUser(string username)
        {
            var users = await _context.Users
                .Where(user => user.Username == username)
                .Include(user => user.Favorites)
                .ToListAsync();
            if (users == null)
                return NotFound("User not found");
            foreach(var user in users)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }
    }
}
