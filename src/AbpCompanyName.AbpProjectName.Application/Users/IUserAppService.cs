using System.Threading.Tasks;
using Abp.Application.Services;
using AbpCompanyName.AbpProjectName.Users.Dto;

namespace AbpCompanyName.AbpProjectName.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}