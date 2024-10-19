using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProjectSite.Models
{
    public partial class Role
    {
        public  Role()
        {
            this.AdminLogins = new HashSet<AdminLogin>();
        }
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AdminLogin> AdminLogins { get; set; }
    }
}