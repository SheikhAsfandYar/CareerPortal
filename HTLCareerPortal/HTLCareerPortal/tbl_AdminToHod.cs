//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HTLCareerPortal
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_AdminToHod
    {
        public int ATHid { get; set; }
        public Nullable<int> DepId { get; set; }
        public Nullable<int> JobId { get; set; }
        public Nullable<int> AppId { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual JobSetup JobSetup { get; set; }
        public virtual tbl_Department tbl_Department { get; set; }
        public virtual tbl_SignUp tbl_SignUp { get; set; }
    }
}
