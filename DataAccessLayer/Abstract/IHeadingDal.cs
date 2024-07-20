using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IHeadingDal : IRepository<Heading>//Irepositroy(Crud)işlemleri vardı miras aldık.<Heading>Irepositorydeki Tlere karşılık geliyor.
    {
    }
}
