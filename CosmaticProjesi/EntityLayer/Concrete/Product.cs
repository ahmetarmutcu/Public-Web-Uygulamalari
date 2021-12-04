using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Content { get; set; }
        [StringLength(100)]
        public string Img1Path { get; set; }
        [StringLength(100)]
        public string Img2Path { get; set; }
        [StringLength(100)]
        public string Img3Path { get; set; }
        [StringLength(100)]
        public string Img4Path { get; set; }
        [StringLength(100)]
        public string Img5Path { get; set; }

        public double Price { get; set; }

        public bool CustomProduct { get; set; }

        public bool FeaturedProduct { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
