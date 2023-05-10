using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vk_Internship.Database.Models
{
    public class User
    {
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string Login { get; set; }

        [ConcurrencyCheck]
        public string Password { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Created_Date { get; set; }

        [Required]
        public User_group Group { get; set; }

        [Required]
        public User_state State { get; set; }
    }
}
