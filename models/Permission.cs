using System.ComponentModel.DataAnnotations;

namespace AutoSAAS.models
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Access { get; set; }
    }
}