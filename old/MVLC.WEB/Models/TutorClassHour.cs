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
    
    public partial class TutorClassHour
    {
        public int TutorID { get; set; }
        public int ClassID { get; set; }
        public System.DateTime ClassDate { get; set; }
        public Nullable<double> Hours { get; set; }
    }
}