using System.ComponentModel.DataAnnotations.Schema;
using AutoSAAS.models;

namespace AutoSAAS.Dtos
{
    public class UserForDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]

        public Company Company { get; set; }
        public int? UserGroupId { get; set; }
        [ForeignKey("UserGroupId")]

        public UserGroup UserGroup { get; set; }
    }
}