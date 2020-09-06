using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoSAAS.models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string Name_ar { get; set; }
        public string Name_en { get; set; }
        public IList<Vehicle> Vehicles { get; set; }
        
    }
}
