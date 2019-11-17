using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LegoCompanionAPI.Models;

namespace LegoCompanionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LegoContext _context;

        public UserController(LegoContext context)
        {
            _context = context;
        }

        // GET: api/User/5
        [HttpGet]
        [Route("UserData")]
        public async Task<ActionResult<User>> GetUserData(string id,string email)
        {
            User user = await _context.User
                .Include(e=>e.CollectionParts).ThenInclude(e => e.Images)
                .Include(e => e.CollectionSets).ThenInclude(e => e.Images)
                .Include(e => e.FavoriteParts).ThenInclude(e => e.Images)
                .Include(e => e.FavoriteSets).ThenInclude(e => e.Images)
                .Include(e => e.WishlistParts).ThenInclude(e => e.Images)
                .Include(e => e.WishlistSets).ThenInclude(e=>e.Images)
                .FirstOrDefaultAsync(e => e.GoogleID==id&e.Email==email);

            if (user == null)
            {
                user = new User()
                {
                    GoogleID = id,
                    Email = email,
                };

                _context.User.Add(user);
            }
            await _context.SaveChangesAsync();
            return user;
        }

        // GET: api/User/5
        [HttpGet]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            User user = await _context.User
                .Include(e => e.CollectionParts).ThenInclude(e => e.Images)
                .Include(e => e.CollectionSets).ThenInclude(e => e.Images)
                .Include(e => e.FavoriteParts).ThenInclude(e => e.Images)
                .Include(e => e.FavoriteSets).ThenInclude(e => e.Images)
                .Include(e => e.WishlistParts).ThenInclude(e => e.Images)
                .Include(e => e.WishlistSets).ThenInclude(e => e.Images)
                .FirstOrDefaultAsync(e=>e.UserID==id);

            return user;
        }

    }
}
