using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VegaApp.API.Models;

namespace VegaApp.API.Data
{
    public class VegaRepository : IVegaRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion

        #region Ctor
        public VegaRepository(DataContext context) {
            _context = context;
        }
        #endregion

        #region Methods
        public void Add<T>(T entity) where T : class {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll() {
            // If there are one or more changes being saved to the database,
            // then this method will return true or else, it will return false
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Make>> GetMakes() {
            var makes = await _context.Makes
                .Include(m => m.Models)
                .OrderBy(m => m.Name)
                .ToListAsync();

            return makes;
        }

        public async Task<IEnumerable<Feature>> GetFeatures() {
            var features = await _context.Features
                .OrderBy(f => f.Name)
                .ToListAsync();

            return features;
        }
        
        #endregion
    }
}