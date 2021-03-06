//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVLC.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class SectionContent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SectionContent()
        {
            this.SectionContents1 = new HashSet<SectionContent>();
            this.SectionContents11 = new HashSet<SectionContent>();
        }
    
        public int ContentID { get; set; }
        public int SectionLayoutID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string BodyHTML { get; set; }
        public Nullable<int> NextContentID { get; set; }
        public Nullable<int> PreviousContentID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SectionContent> SectionContents1 { get; set; }
        public virtual SectionContent SectionContent1 { get; set; }
        public virtual SectionLayout SectionLayout { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SectionContent> SectionContents11 { get; set; }
        public virtual SectionContent SectionContent2 { get; set; }
    }
}
