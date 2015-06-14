using Abp.Domain.Repositories;
using Abp.MultiTenancy;

namespace AbpZeroSample.Authorization
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(IRepository<Tenant> tenantRepository)
            : base(tenantRepository)
        {

        }
    }
}