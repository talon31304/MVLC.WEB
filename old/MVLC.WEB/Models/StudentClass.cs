//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVLC.WEB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentClass
    {
        public int StudentID { get; set; }
        public int ClassID { get; set; }
        public System.DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> WithdrawDate { get; set; }
        public string WithdrawBy { get; set; }
        public Nullable<int> TotalHours { get; set; }
        public int StudentStudentID { get; set; }
        public bool StudentDelete { get; set; }
        public int StudentEthnicityID { get; set; }
        public bool StudentBelow_Poverty_level { get; set; }
        public bool StudentIs_Homeless { get; set; }
        public bool StudentIsRefugee { get; set; }
        public bool StudentSpecialNeeds { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
