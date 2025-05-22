using AdminApp.Core.Entities;
using AdminApp.Infrastructure.Interfaces;
using AdminApp.Services.Interfaces;

namespace AdminApp.Services.Services
{
    public class RoleService : _BaseService<Role>, IRoleService
    {
        public RoleService(IRoleRepository repository) : base(repository) { }
    }
}
