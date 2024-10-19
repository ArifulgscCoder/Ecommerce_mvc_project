using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProjectSite.Models
{
    public partial class AdminLogin
    {

        [Key]
        public int LoginID { get; set; }
        public int EmpID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> RoleType { get; set; }
       

        public virtual AdminEmp AdminEmp { get; set; }
        public virtual Role Role { get; set; }
    }
}