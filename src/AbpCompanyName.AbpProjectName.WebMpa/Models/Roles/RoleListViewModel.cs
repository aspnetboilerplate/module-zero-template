using System.Collections.Generic;
using AbpCompanyName.AbpProjectName.Roles.Dto;

namespace AbpCompanyName.AbpProjectName.WebMpa.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}