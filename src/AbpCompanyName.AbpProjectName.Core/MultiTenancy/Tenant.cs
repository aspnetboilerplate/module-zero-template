using Abp.MultiTenancy;
using AbpCompanyName.AbpProjectName.Users;

namespace AbpCompanyName.AbpProjectName.MultiTenancy
{
    public class Tenant : AbpTenant<Tenant, User>
    {

    }
}