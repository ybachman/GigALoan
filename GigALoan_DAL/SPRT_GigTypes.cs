//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GigALoan_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class SPRT_GigTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPRT_GigTypes()
        {
            this.CHLD_StudentReferences = new HashSet<CHLD_StudentReferences>();
            this.CORE_GigAlerts = new HashSet<CORE_GigAlerts>();
            this.CORE_Students = new HashSet<CORE_Students>();
        }
    
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public int CategoryID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHLD_StudentReferences> CHLD_StudentReferences { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CORE_GigAlerts> CORE_GigAlerts { get; set; }
        public virtual SPRT_GigCategories SPRT_GigCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CORE_Students> CORE_Students { get; set; }
    }
}
