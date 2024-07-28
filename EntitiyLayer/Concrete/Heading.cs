using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
     public class Heading
    {
        [Key]
        public int HeadingId { get; set; }
        [StringLength(100)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }
        public bool HeadingStatus { get; set; }

        //her Bir Kategorinin Birden fazla başlığı olacak.(herbir kategori dedik kategoriye ıcollection verdik)
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        //her bir başlığın birden fazla içeriği olacak.
        public ICollection<Content> Contents { get; set; }


        //Bir Yazarın Birden Fazla başlığı olabilir.
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }


       


    }
}
