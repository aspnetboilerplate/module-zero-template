using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Api.Models
{
    public class ProfileInfo
    {
        public long TenantId { get; set; }
        public string TenantName { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }

        public List<string> LoginProvider { get; set; }
    }
}
