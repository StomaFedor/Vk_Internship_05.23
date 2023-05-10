using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Vk_Internship.Database.Models
{
    //можно использовать enum, но тогда в бд будут int
    public class CodeGroup
    {
        public static readonly string User = "User";
        public static readonly string Admin = "Admin";
    }
    public class User_group
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        [Required]
        public User User { get; set; }
    }
}
