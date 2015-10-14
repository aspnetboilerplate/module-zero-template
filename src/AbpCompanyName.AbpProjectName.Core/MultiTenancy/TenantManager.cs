using Abp.MultiTenancy;
using AbpCompanyName.AbpProjectName.Authorization.Roles;
using AbpCompanyName.AbpProjectName.Editions;
using AbpCompanyName.AbpProjectName.Users;

namespace AbpCompanyName.AbpProjectName.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(EditionManager editionManager)
            : base(editionManager)
        {

        }
    }
}