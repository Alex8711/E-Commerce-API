﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_API.Database;
using E_Commerce_API.Models;
using E_Commerce_API.Specifications;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseModel
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec); 
        }
    }
}