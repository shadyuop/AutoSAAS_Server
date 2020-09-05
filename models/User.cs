using System.ComponentModel.DataAnnotations;

namespace AutoSAAS.models

{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        public UserGroup UserGroup { get; set; }
        public int UserGroupId { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
