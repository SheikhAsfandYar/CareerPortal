using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTLCareerPortal.Areas.Applicant.Models
{
    public class Joblist
    {
        public int jobId { get; set; }
        public string JobTile { get; set; }
        public string JobType { get; set; }
        public string Education { get; set; }
        public string SkillsRequired { get; set; }
        public string CityName { get; set; }
        public string ScopeResponse { get; set; }
        public string Experience { get; set; }
        public string compensationBenifits { get; set; }
    }
}