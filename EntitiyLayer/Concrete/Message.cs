using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Message
    {
        [Key] //Birincil anahtar
        public int MessageId { get; set; }
        [StringLength(50)]
        public string SenderMail { get; set; }//Gönderen
        [StringLength(50)]
        public string ReciverMail { get; set; }//Alıcı
        [StringLength(100)]
        public string Subject { get; set; }     
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
