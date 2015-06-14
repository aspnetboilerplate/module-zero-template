using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace AbpZeroSample
{
    [DependsOn(typeof(AbpWebApiModule), typeof(AbpZeroSampleApplicationModule))]
    public class AbpZeroSampleWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(AbpZeroSampleApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
