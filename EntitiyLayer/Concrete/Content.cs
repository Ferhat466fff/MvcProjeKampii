using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }
        [StringLength(1000)]
        public string ContentValue { get; set; }
        
        public DateTime ContentDate { get; set; }
        

        //Her Bir Başlığın Birden fazla içeriği olacak.
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        //Bir yazarın birden fzla içeriği olabilir.
        public int? WriterId { get; set; }
        public virtual Writer Writer{ get; set; }


    }
}
