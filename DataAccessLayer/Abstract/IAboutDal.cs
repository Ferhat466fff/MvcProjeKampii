using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAboutDal:IRepository<About>//Irepositroy(Crud)işlemleri vardı miras aldık.<About>Irepositorydeki T lere karşılık geliyor.
    {
    }
}
