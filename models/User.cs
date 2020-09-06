using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSAAS.models

{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }

        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        [ForeignKey("UserGroup")]
        public int? UserGroupId { get; set; }
        public UserGroup UserGroup { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
