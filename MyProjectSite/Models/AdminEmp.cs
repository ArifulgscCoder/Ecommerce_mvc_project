using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProjectSite.Models
{
    public partial class AdminEmp
    {
        public AdminEmp()
        {
            this.AdminLogin = new HashSet<AdminLogin>();
        }
        [Key]
        public int EmpID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [
            Display(Name = "Birth Date"),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)
        ]
        public Nullable<System.DateTime> DateofBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string PicturePath { get; set; }
        public virtual ICollection<AdminLogin> AdminLogins { get; set; }
        public HashSet<AdminLogin> AdminLogin { get; }
    }
}