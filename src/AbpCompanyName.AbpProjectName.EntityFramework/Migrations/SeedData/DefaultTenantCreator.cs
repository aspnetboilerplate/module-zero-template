using System.Linq;
using AbpCompanyName.AbpProjectName.EntityFramework;
using AbpCompanyName.AbpProjectName.MultiTenancy;

namespace AbpCompanyName.AbpProjectName.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly AbpProjectNameDbContext _context;

        public DefaultTenantCreator(AbpProjectNameDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == "Default");
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = "Default", Name = "Default"});
                _context.SaveChanges();
            }
        }
    }
}