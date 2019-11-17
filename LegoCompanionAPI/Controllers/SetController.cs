using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LegoCompanionAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace LegoCompanionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetController : ControllerBase
    {
        private readonly LegoContext _context;

        public SetController(LegoContext context)
        {
            _context = context;
        }

        // GET: api/Set
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Set>>> GetSets()
        {
            return await _context.Sets.ToListAsync();
        }

        // GET: api/SetWithParts
        [HttpGet]
        [Route("SetWithParts")]
        public async Task<ActionResult<IEnumerable<Set>>> GetSetsWithParts()
        {
            return await _context.Sets
                .Include(e => e.Images)
                .Include(e => e.Dimensions)
                .Include(e => e.SetParts).ThenInclude(e=>e.Part).ThenInclude(e=>e.Images)
                .ToListAsync();
        }

        [HttpGet]
        [Route("AddSetToWishList")]
        public async Task<ActionResult<User>> AddSetToWishlist(long userId, long setId)
        {
            User user = await ReturnUser(userId);

            Set set = await ReturnSet(setId);

            if (!user.WishlistSets.Contains(set))
            {
                user.WishlistSets.Add(set);
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpGet]
        [Route("AddSetToFavorites")]
        public async Task<ActionResult<User>> AddSetToFavorites(long userId, long setId)
        {
            User user = await ReturnUser(userId);

            Set set = await ReturnSet(setId);

            if (!user.FavoriteSets.Contains(set))
            {
                user.FavoriteSets.Add(set);
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpGet]
        [Route("AddSetToCollection")]
        public async Task<ActionResult<User>> AddSetToCollection(long userId, long setId)
        {
            User user = await ReturnUser(userId);

            Set set = await ReturnSet(setId);

            if (!user.CollectionSets.Contains(set))
            {
                user.CollectionSets.Add(set);
            }
            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return user;
        }

        [HttpGet]
        [Route("RemoveSetFromWishlist")]
        public async Task<ActionResult<User>> RemoveSetFromWishlist(long userId, long setId)
        {
            User user = await ReturnUser(userId);

            Set set = user.WishlistSets.FirstOrDefault(e => e.SetID == setId);

            user.WishlistSets.Remove(set);

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpGet]
        [Route("RemoveSetFromFavorites")]
        public async Task<ActionResult<User>> RemoveSetFromFavorites(long userId, long setId)
        {
            User user = await ReturnUser(userId);

            Set set = user.FavoriteSets.FirstOrDefault(e => e.SetID == setId);

            user.FavoriteSets.Remove(set);

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpGet]
        [Route("RemoveSetFromCollection")]
        public async Task<ActionResult<User>> RemoveSetFromCollection(long userId, long setId)
        {
            User user = await ReturnUser(userId);

            Set set = user.CollectionSets.FirstOrDefault(e => e.SetID == setId);

            user.CollectionSets.Remove(set);

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }

        // GET: api/Set/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Set>> GetSet(long id)
        {
            Set @set = await ReturnSet(id);

            if (@set == null)
            {
                return NotFound();
            }

            return @set;
        }

        private async Task<Set> ReturnSet(long setID)
        {
            Set set =await _context.Sets
                .Include(e => e.Images)
                .Include(e => e.Dimensions)
                .Include(e => e.SetParts).ThenInclude(e => e.Part).ThenInclude(e => e.Images)
                .FirstOrDefaultAsync(e => e.SetID == setID);

            return set;
        }

        private async Task<User> ReturnUser(long userID) {
            User user = await _context.User.Include(e => e.CollectionParts)
                .Include(e => e.CollectionSets)
                .Include(e => e.FavoriteParts)
                .Include(e => e.FavoriteSets)
                .Include(e => e.WishlistParts)
                .Include(e => e.WishlistSets)
                .FirstOrDefaultAsync(e => e.UserID == userID);

            return user;
        }
    }
}
