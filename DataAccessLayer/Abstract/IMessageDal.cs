using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public  interface IMessageDal : IRepository<Message>//Irepositroy(Crud)işlemleri vardı miras aldık.<About>Irepositorydeki T lere karşılık geliyor.
    {

    }
}
