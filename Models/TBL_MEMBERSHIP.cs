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
    
    public partial class TBL_MEMBERSHIP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MEMBERSHIP()
        {
            this.TBL_USER = new HashSet<TBL_USER>();
        }
    
        public int MEM_ID { get; set; }
        public string MEM_TYPE { get; set; }
        public Nullable<int> MEM_PAYMENT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER> TBL_USER { get; set; }
    }
}