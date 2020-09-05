using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace AutoSAAS.models
{
    public class UserGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name_ar { get; set; }
        public string Name_en { get; set; }
        public IEnumerable<Permission> Permissions { get; set; }

    }
}