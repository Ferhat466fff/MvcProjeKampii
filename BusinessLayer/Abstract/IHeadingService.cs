using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        void HeadingAdd(Heading heading);
        Heading GetById(int id);
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
        List<Heading> GetByWriterList(int id);//Şartlı Listeleme(yazara göre)




    }
}
