using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSAAS.models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Brand")]
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string chasetNumber { get; set; }
    }
}
