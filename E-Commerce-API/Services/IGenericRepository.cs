using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce_API.Models;
using E_Commerce_API.Specifications;

namespace E_Commerce_API.Services
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}