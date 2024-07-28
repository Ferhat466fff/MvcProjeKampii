using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        [StringLength(50)]
        public string WriterName { get; set; }
        [StringLength(50)]
        public string WriterSurName { get; set; }
        [StringLength(250)]
        public string WriterImage { get; set; }
        [StringLength(250)]
        public string WriterAbout { get; set; }
     
        [StringLength(200)]
        public string WriterMail { get; set; }
        [StringLength(200)]
        public string WriterPassword { get; set; }
        [StringLength(50)]
        public string WriterTitle { get; set; }


        public bool WriterStatüs { get; set; }


        //Bir Yazarın Birden Fazla başlığı olabilir.
        public ICollection<Heading> Headings { get; set; }


        //Bir yazarın birden fzla içeriği olabilir.
        public ICollection<Content> Contents { get; set; }
    }
}
