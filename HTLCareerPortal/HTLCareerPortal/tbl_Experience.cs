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
    
    public partial class tbl_Experience
    {
        public int Exp_Id { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Industry { get; set; }
        public string PhoneNo { get; set; }
        public string JobSpecialization { get; set; }
        public Nullable<int> App_Id { get; set; }
        public Nullable<int> PI_Id { get; set; }
    
        public virtual tbl_PersonalInfo tbl_PersonalInfo { get; set; }
        public virtual tbl_SignUp tbl_SignUp { get; set; }
    }
}