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
    
    public partial class tbl_recipe
    {
        public int r_id { get; set; }
        public string r_name { get; set; }
        public string r_desc { get; set; }
        public Nullable<int> userid { get; set; }
        public string Admin_Reply { get; set; }
        public Nullable<int> fl_ref { get; set; }
    
        public virtual tbl_flavour tbl_flavour { get; set; }
        public virtual TBL_USER TBL_USER { get; set; }
    }
}
