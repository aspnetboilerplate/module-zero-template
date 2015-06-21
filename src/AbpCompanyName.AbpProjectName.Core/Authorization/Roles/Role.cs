using Abp.Authorization.Roles;
using AbpCompanyName.AbpProjectName.MultiTenancy;
using AbpCompanyName.AbpProjectName.Users;

namespace AbpCompanyName.AbpProjectName.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}