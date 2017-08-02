using System.Threading.Tasks;
using Abp.Application.Services;
using AbpCompanyName.AbpProjectName.Configuration.Dto;

namespace AbpCompanyName.AbpProjectName.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}