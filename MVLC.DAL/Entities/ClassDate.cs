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
    
    public partial class ClassDate
    {
        public int ClassID { get; set; }
        public System.DateTime Class_Date { get; set; }
        public string DidClassMeet { get; set; }
    
        public virtual Class Class { get; set; }
    }
}
