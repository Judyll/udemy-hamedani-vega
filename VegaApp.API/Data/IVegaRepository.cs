using System.Collections.Generic;
using System.Threading.Tasks;
using VegaApp.API.Models;

namespace VegaApp.API.Data
{
    public interface IVegaRepository
    {
        // This is a generic method
        // In our case, T might be a type of Make class or type of Model class
        // And we contraint the method to accept only type of 'class' 
        // by using the where clause
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();

        /// <summary>
        /// Get the list of makes
        /// </summary>
        /// <returns></returns>       
        Task<IEnumerable<Make>> GetMakes();

        /// <summary>
        /// Get the list of features
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Feature>> GetFeatures();
    }
}