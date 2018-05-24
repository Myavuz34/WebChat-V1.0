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
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(200)]
        [DisplayName("İsim")]
        public string Name { get; set; }
        [StringLength(200)]
        [DisplayName("Soy isim")]
        public string Surname { get; set; }
        [StringLength(50)]
        [DisplayName("Meslek")]
        public string Job { get; set; }

    }
}
