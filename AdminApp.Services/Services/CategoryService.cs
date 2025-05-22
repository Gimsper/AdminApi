using AdminApp.Core.Entities;
using AdminApp.Infrastructure.Interfaces;
using AdminApp.Services.Interfaces;

namespace AdminApp.Services.Services
{
    public class CategoryService : _BaseService<Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository) : base(repository)
        {
        }
    }
}
