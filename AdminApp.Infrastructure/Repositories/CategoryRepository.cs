using AdminApp.Core.Context;
using AdminApp.Core.Entities;
using AdminApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdminApp.Infrastructure.Repositories
{
    public class CategoryRepository : _BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DBContext context) : base(context)
        {
        }

        public override async Task<List<Category>> GetAllAsync()
        {
            return await _context.Category.Include(i => i.Items).ToListAsync();
        }

        public override async Task<Category> GetByAsync(Expression<Func<Category, bool>> func)
        {
            return await _context.Category.Include(i => i.Items).FirstOrDefaultAsync(func);
        }

        public override async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Category.Include(i => i.Items).FirstOrDefaultAsync(i => i.CategoryId == id);
        }

        public override async Task<Category> AddAsync(Category entity)
        {
            await _context.Category.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task UpdateAsync(Category entity)
        {
            _context.Category.Update(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                _context.Category.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
