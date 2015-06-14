using System.Reflection;
using Abp.Modules;
using Abp.Zero;

namespace AbpZeroSample
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AbpZeroSampleCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
