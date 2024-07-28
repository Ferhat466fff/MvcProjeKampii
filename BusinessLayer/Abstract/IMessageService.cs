using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox();//Gelen Mesajlar
        List<Message> GetListSendbox();//GönderilenMesajlar
        void MessageAdd(Message message);
        Message GetByID(int id);//Id göre alma.
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        int GetSendboxMessageCount();//Göndeilen Mesaj Sayısı
        int GetReciverMessageCount();

    }
}
