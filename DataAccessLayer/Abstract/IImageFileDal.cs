using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IImageFileDal :IRepository<ImageFile>//Irepositroy(Crud)işlemleri vardı miras aldık.<Category>Irepositorydeki Tlere karşılık geliyor.
    {

    }
}
