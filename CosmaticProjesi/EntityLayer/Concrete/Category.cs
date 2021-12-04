using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [StringLength(200)]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
