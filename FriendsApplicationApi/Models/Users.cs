using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsApplicationApi.Models
{
    public class Users
    {
        [Key]
        [Column("User_id")]
        public Guid user_id { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Name can only be 10 Characters Long")]
        [Column("User_Name")]
        public string user_name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(10, ErrorMessage = "Surname can only be 10 Characters Long")]
        [Column("User_Surname")]
        public string user_surname { get; set; }

        [Required]
        [EmailAddress]
        [Column("User_Email")]
        public string user_email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Column("User_Password")]
        public string user_password { get; set; }

        public List<Friends> Friends { get; set; }
    }
}
