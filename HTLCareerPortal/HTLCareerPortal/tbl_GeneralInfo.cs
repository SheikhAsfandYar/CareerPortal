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
    
    public partial class tbl_GeneralInfo
    {
        public int Ans_Id { get; set; }
        public Nullable<bool> Ans_One_Status { get; set; }
        public string Ans_One_Text { get; set; }
        public Nullable<bool> Ans_Two_Status { get; set; }
        public string Ans_Two_Text { get; set; }
        public Nullable<bool> Ans_Three_Status { get; set; }
        public string Ans_Three_Text { get; set; }
        public Nullable<int> App_Id { get; set; }
        public string GeneralStatus { get; set; }
    
        public virtual tbl_SignUp tbl_SignUp { get; set; }
    }
}
