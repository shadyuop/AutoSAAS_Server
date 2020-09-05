using System.ComponentModel.DataAnnotations;
namespace AutoSAAS.models
{
    public class Value
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}