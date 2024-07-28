using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {//Burada interface(service) methodu tanımla.manager kısmında içini doldur.

        List<Writer> GetList();
        void WriterAdd(Writer writer);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        Writer GetById(int id);
        int AWriter();// İsminde A harfi Geçen Yazar Sayısı. 
    }
}
