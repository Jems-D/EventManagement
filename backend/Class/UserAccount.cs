using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Class
{
    [Table("UserAccount")]
    public class UserAccount
    {
        [Column("User_ID", TypeName = "int")]
        [Key]
        public int UserId { get; set; }

        [Column("User_Role", TypeName = "varchar(10)")]
        public string UserRole { get; set; } = string.Empty;

        [Column("User_Created_At", TypeName = "datetime")]
        public DateTime UserCreatedAt { get; set; } = DateTime.Now;

        [Column("User_Updated_At", TypeName = "datetime")]
        public DateTime UserUpdatedAt { get; set; } = DateTime.Now;

        [Column("Password_Hash", TypeName = "varchar(250)")]
        public string Password { get; set; } = string.Empty;

        [Column("Last_Login", TypeName = "datetime")]
        public DateTime LastLogin { get; set; } = DateTime.Now;
    }
}
