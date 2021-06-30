using System.Collections.Generic;

namespace CMS_ITEH.Models.Domain
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}