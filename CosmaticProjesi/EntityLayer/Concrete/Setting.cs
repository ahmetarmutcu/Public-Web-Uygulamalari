using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Setting
    {
        [Key]
        public int ID { get; set; }
        //Sistem Ayarları
        [StringLength(100)]
        public string IconPath { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(250)]
        public string Keyword { get; set; }
        [StringLength(50)]
        public string Title { get; set; }

        //Sosyal Medya
        [StringLength(250)]
        public string InstgramUrl { get; set; }
        [StringLength(250)]
        public string FacebookUrl { get; set; }
        [StringLength(250)]
        public string TwitterUrl { get; set; }
        [StringLength(250)]
        public string GoogleUrl { get; set; }
        [StringLength(250)]
        public string YoutubeUrl { get; set; }

        //Site iletişim 
        [StringLength(15)]
        public string FixedPhone { get; set; }
        [StringLength(15)]
        public string TelephonePhone { get; set; }
        [StringLength(100)]
        public string WorkingHouse { get; set; }
        [StringLength(25)]
        public string Province { get; set; }
        [StringLength(50)]
        public string District { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        [StringLength(500)]
        public string GoogleMaps { get; set; }


        //Site Hakkında
        [StringLength(250)]
        public string AboutHeading { get; set; }

        public string AboutContent { get; set; }


    }
}
