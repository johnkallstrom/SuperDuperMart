using Microsoft.EntityFrameworkCore;

namespace SuperDuperMart.Core.Data.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly SuperDuperMartDbContext _context;

        public LocationRepository(SuperDuperMartDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Location>> GetAsync()
        {
            var locations = await _context.Locations.ToListAsync();
            return locations;
        }

        public Task<PagedList<Location>> GetAsync(IQueryParams parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<Location?> GetByIdAsync(int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);
            return location;
        }

        public async Task<Location?> GetByUserIdAsync(int userId)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.UserId == userId);
            return location;
        }

        public async Task<Location> CreateAsync(Location entity)
        {
            var entry = await _context.Locations.AddAsync(entity);
            return entry.Entity;
        }

        public void Update(Location entity)
        {
            entity.LastModified = DateTime.Now;
            _context.Locations.Update(entity);
        }

        public void Delete(Location entity) => _context.Locations.Remove(entity);

        public Task<Location?> GetByIdAsync<TProperty>(int id, Expression<Func<Location, TProperty>> include)
        {
            throw new NotImplementedException();
        }
    }
}
