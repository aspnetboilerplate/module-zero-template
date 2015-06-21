using Abp.Authorization.Users;
using AbpCompanyName.AbpProjectName.MultiTenancy;

namespace AbpCompanyName.AbpProjectName.Users
{
    public class User : AbpUser<Tenant, User>
    {

    }
}