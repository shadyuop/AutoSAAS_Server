using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSAAS.models
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserGroupId { get; set; }
        [ForeignKey("UserGroupId")]
        
        public UserGroup userGroup { get; set; }
    }
}