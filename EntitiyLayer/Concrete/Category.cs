using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
      public  class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string CategoryName { get; set; }
        [StringLength(500)]
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }

        //her Bir Kategorinin Birden fazla başlığı olacak.(herbir kategori dedik kategoriye ıcollection verdik)

        public ICollection<Heading> Headings { get; set; }//Bir Kategorinin Birden fazla başlığı olacak.
    }
}
