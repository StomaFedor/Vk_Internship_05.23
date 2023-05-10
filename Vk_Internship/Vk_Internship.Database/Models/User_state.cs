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
    public class CodeState
    {
        public static readonly string Active = "Active";
        public static readonly string Blocked = "Blocked";
    }
    public class User_state
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
