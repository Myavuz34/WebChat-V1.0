using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChat.Entity
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required(ErrorMessage ="Kullanıcı Adınızı Giriniz.")]
        [StringLength(50)]
        [DisplayName("Kullanıcı Adınız")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Şifre Gerekli.")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int RoleID { get; set; }

        public virtual Role Role { get; set; }
    }
}
