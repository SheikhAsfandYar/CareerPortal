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
    
    public partial class tbl_JobSalaryPreference
    {
        public int JSP_ID { get; set; }
        public string PWT1 { get; set; }
        public string PWT2 { get; set; }
        public string PWT3 { get; set; }
        public Nullable<int> FOI1 { get; set; }
        public Nullable<int> FOI2 { get; set; }
        public Nullable<int> FOI3 { get; set; }
        public string CurrentSalary { get; set; }
        public string Benifits { get; set; }
        public string ExpectedGrossSalary { get; set; }
        public Nullable<int> App_Id { get; set; }
    
        public virtual tbl_FOI tbl_FOI { get; set; }
        public virtual tbl_FOI tbl_FOI1 { get; set; }
        public virtual tbl_FOI tbl_FOI2 { get; set; }
        public virtual tbl_SignUp tbl_SignUp { get; set; }
    }
}
