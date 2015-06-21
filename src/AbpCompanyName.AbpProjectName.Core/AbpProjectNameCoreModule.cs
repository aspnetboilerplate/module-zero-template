using System.Reflection;
using Abp.Modules;
using Abp.Zero;

namespace AbpCompanyName.AbpProjectName
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AbpProjectNameCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
