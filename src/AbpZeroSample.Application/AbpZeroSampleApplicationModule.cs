using System.Reflection;
using Abp.Modules;

namespace AbpZeroSample
{
    [DependsOn(typeof(AbpZeroSampleCoreModule))]
    public class AbpZeroSampleApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
