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
    using System.Web;

    public partial class tbl_flavour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_flavour()
        {
            this.tbl_recipe = new HashSet<tbl_recipe>();
        }
    
        public int fl_id { get; set; }
        [Required]
        [Display(Name = "Flavour Name")]
        public string fl_name { get; set; }
        [Required]
        [Display(Name = "Flavour Image")]
        public string fl_image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_recipe> tbl_recipe { get; set; }
    }
}
