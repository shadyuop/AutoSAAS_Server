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
        [ForeignKey("UserGroup")]
        public int? UserGroupId { get; set; }
        public UserGroup userGroup { get; set; }
    }
}