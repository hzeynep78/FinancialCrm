//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinancialCrm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_BANK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_BANK()
        {
            this.TBL_PROCESS = new HashSet<TBL_PROCESS>();
        }
    
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Title { get; set; }
        public Nullable<decimal> Balance { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PROCESS> TBL_PROCESS { get; set; }
    }
}
