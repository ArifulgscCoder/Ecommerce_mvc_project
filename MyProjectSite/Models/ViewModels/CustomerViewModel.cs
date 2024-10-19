using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProjectSite.Models
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }
        [Display(Name = "First Name")]
        [Required, RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains only Alphabets")]
        public string First_Name { get; set; }
        [Display(Name = "Last Name")]
        [Required, RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains only Alphabets")]
        public string Last_Name { get; set; }
        [Required, Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Gender { get; set; }
        [
            Required,
            Display(Name = "Birth Date"),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
            DataType(DataType.Date)
        ]
        public Nullable<System.DateTime> DateofBirth { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
       
        [Required, DataType(DataType.EmailAddress, ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }
        [Required, DataType(DataType.PhoneNumber, ErrorMessage = "Mobile number contains only Numbers")]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Display(Name = "Picture")]
        public string PicturePath { get; set; }
        public HttpPostedFileBase Picture { get; set; }         
    }
}