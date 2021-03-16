//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IceCreamProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_feedback
    {
        public int f_id { get; set; }
        [Required]
        [Display(Name = "Feed Back")]
        
        public string f_text { get; set; }
        [Required]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        public string f_email { get; set; }
        [Required]
        [Display(Name = "User Name")]
        //[DataType(DataType.EmailAddress)]
        public string f_name { get; set; }
        [Required]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public string f_contact { get; set; }
        
        [Display(Name = "User Id")]
        [DataType(DataType.EmailAddress)]
        public Nullable<int> UserFeed_id { get; set; }
        
        [Display(Name = "Admin Reply")]
        
        public string Admin_Reply { get; set; }
    
        public virtual TBL_USER TBL_USER { get; set; }
    }
}
