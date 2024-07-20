using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContentDal:IRepository<Content>//Irepositroy(Crud)işlemleri vardı miras aldık.<content>Irepositorydeki T lere karşılık geliyor.
    {
    }
}
