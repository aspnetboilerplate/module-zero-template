using Abp.MultiTenancy;

namespace AbpZeroSample.Authorization
{
    public class Tenant : AbpTenant<Tenant, User>
    {

    }
}