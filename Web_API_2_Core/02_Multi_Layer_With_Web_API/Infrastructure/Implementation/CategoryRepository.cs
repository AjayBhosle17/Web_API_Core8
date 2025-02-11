using Data;
using Data.Entities;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        CoreDbContext _context;

        public CategoryRepository(CoreDbContext context)
        {
            _context = context;
        }

        public async Task Create(Category category)
        { 
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int? id)
        {

            var category = await _context.Categories.FindAsync(id);

             _context.Categories.Remove(category);
            await _context.SaveChangesAsync();


        }

        public async Task Edit(Category category)
        {

            _context.Categories.Attach(category);

            _context.Entry(category).State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }

        public async Task<List<Category>> GetAll()
        {
           
            var categories = await _context.Categories.ToListAsync();

            return categories;
        }

        public async Task<Category> GetById(int? id)
        {
           
            var category = await _context.Categories.FindAsync(id);

            return category;

            
        }
    }
}
