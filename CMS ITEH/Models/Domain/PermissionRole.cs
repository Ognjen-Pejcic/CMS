using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_ITEH.Models.Domain
{
    public class PermissionRole
    {
        public Permission Permission { get; set; }
        public int PermissionId { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }

    }
}
