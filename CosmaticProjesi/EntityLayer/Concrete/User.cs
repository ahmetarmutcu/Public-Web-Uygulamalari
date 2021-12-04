using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(10)]
        public string Password { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
    }
}
