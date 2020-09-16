using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoSAAS.models
{
    public class CompanyForTransmisionDto
    {
        [Key]
        public int Id { get; set; }
        public string Name_ar { get; set; }
        public string Name_en { get; set; }
        public string Hq_phone { get; set; }
        public string Hq_phone_country_code { get; set; }
        public string Hq_country { get; set; }
        public string Hq_city { get; set; }
    }
}
