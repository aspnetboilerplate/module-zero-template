using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using AbpZeroSample.EntityFramework;

namespace AbpZeroSample
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(AbpZeroSampleCoreModule))]
    public class AbpZeroSampleDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<AbpZeroSampleDbContext>(null);
        }
    }
}
