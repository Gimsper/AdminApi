using AdminApp.Core.Context;
using AdminApp.Core.Entities;
using AdminApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdminApp.Infrastructure.Repositories
{
    public class RoleRepository : _BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(DBContext context) : base(context)
        {
        }

        public override async Task<List<Role>> GetAllAsync()
        {
            return await _context.Role.Include(i => i.Users).ToListAsync();
        }

        public override async Task<Role> GetByAsync(Expression<Func<Role, bool>> func)
        {
            return await _context.Role.Include(i => i.Users).FirstOrDefaultAsync(func);
        }

        public override async Task<Role> GetByIdAsync(int id)
        {
            return await _context.Role.Include(i => i.Users).FirstOrDefaultAsync(i => i.RoleId == id);
        }

        public override async Task<Role> AddAsync(Role entity)
        {
            await _context.Role.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task UpdateAsync(Role entity)
        {
            _context.Role.Update(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                _context.Role.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
