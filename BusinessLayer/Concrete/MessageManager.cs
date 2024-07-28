using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x =>x.MessageId == id);
        }

        public List<Message> GetListInbox()//ALıcı Mail
        {
            return _messageDal.List(x => x.ReciverMail == "admin@gmail.com");
        }

        public List<Message> GetListSendbox()//Gönderen Mail
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
        }

        public int GetReciverMessageCount()
        {
            return _messageDal.List(x => x.ReciverMail == "admin@gmail.com").Count;
        }

        public int GetSendboxMessageCount()//Göndeilen Mesaj Sayısı
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com").Count;
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
