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
    public class PartController : ControllerBase
    {
        private readonly LegoContext _context;

        public PartController(LegoContext context)
        {
            _context = context;
        }

        // GET: api/Part/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Part>> GetPart(long id)
        {
            Part part = await _context.Parts
                .Include(e => e.Images)
                .Include(e => e.SetParts).ThenInclude(e => e.Set).ThenInclude(e => e.Images)
                .Include(e => e.SetParts).ThenInclude(e => e.Set).ThenInclude(e => e.Dimensions).FirstOrDefaultAsync(e=>e.PartID==id);

            if (part == null)
            {
                return NotFound();
            }

            return part;
        }

        [HttpGet]
        [Route("PartsWithSets")]
        public async Task<ActionResult<IEnumerable<Part>>> GetPartsWithSets()
        {
            return await _context.Parts
                .Include(e => e.Images)
                .Include(e => e.SetParts).ThenInclude(e => e.Set).ThenInclude(e => e.Images)
                .Include(e => e.SetParts).ThenInclude(e => e.Set).ThenInclude(e => e.Dimensions)
                .ToListAsync();
        }

        [HttpGet]
        [Route("AddPartToWishList")]
        public async Task<ActionResult<User>> AddSetToWishlist(long userId, long partId)
        {
            User user = await ReturnUser(userId);

            Part part = await ReturnPart(partId);

            if (!user.WishlistParts.Contains(part))
            {
                user.WishlistParts.Add(part);
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpGet]
        [Route("AddPartToFavorites")]
        public async Task<ActionResult<User>> AddPartToFavorites(long userId, long partId)
        {
            User user = await ReturnUser(userId);

            Part part = await ReturnPart(partId);

            if (!user.FavoriteParts.Contains(part))
            {
                user.FavoriteParts.Add(part);
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpGet]
        [Route("AddPartToCollection")]
        public async Task<ActionResult<User>> AddPartToCollection(long userId, long partId)
        {
            User user = await ReturnUser(userId);

            Part part = await ReturnPart(partId);

            if (!user.CollectionParts.Contains(part))
            {
                user.CollectionParts.Add(part);
            }
            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return user;
        }

        [HttpGet]
        [Route("RemovePartFromWishlist")]
        public async Task<ActionResult<User>> RemovePartFromWishlist(long userId, long partId)
        {
            User user = await ReturnUser(userId);

            Part part = user.WishlistParts.FirstOrDefault(e => e.PartID == partId);

            user.WishlistParts.Remove(part);

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpGet]
        [Route("RemovePartFromFavorites")]
        public async Task<ActionResult<User>> RemovePartFromFavorites(long userId, long partId)
        {
            User user = await ReturnUser(userId);

            Part part = user.FavoriteParts.FirstOrDefault(e => e.PartID == partId);

            user.FavoriteParts.Remove(part);

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpGet]
        [Route("RemovePartFromCollection")]
        public async Task<ActionResult<User>> RemovePartFromCollection(long userId, long partId)
        {
            User user = await ReturnUser(userId);

            Part part = user.CollectionParts.FirstOrDefault(e => e.PartID == partId);

            user.CollectionParts.Remove(part);

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }

        [HttpGet]
        [Route("GetThemes")]
        public async Task<ActionResult<IEnumerable<Theme>>> GetThemes()
        {
            return await _context.Themes.ToListAsync();
        }

        [HttpPost]
        [Route("AddPart")]
        public async Task<ActionResult<long>> AddPart(Part part)
        {

            if (!PartExists(part.LegoCode))
            {
                _context.Parts.Add(part);
                await _context.SaveChangesAsync();
                return part.PartID;
            }
            return NotFound();
        }

        private async Task<Part> ReturnPart(long partID)
        {
            Part part = await _context.Parts
                .Include(e => e.Images)
                .Include(e => e.SetParts).ThenInclude(e => e.Set).ThenInclude(e => e.Images)
                .Include(e => e.SetParts).ThenInclude(e => e.Set).ThenInclude(e => e.Dimensions)
                .FirstOrDefaultAsync(e => e.PartID==partID);

            return part;
        }

        private async Task<User> ReturnUser(long userID)
        {
            User user = await _context.Users.Include(e => e.CollectionParts)
                .Include(e => e.CollectionSets)
                .Include(e => e.FavoriteParts)
                .Include(e => e.FavoriteSets)
                .Include(e => e.WishlistParts)
                .Include(e => e.WishlistSets)
                .FirstOrDefaultAsync(e => e.UserID == userID);

            return user;
        }

        private bool PartExists(int legocode)
        {
            return _context.Parts.Any(e => e.LegoCode == legocode);
        }
    }
}
