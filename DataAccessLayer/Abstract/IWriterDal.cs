using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
     public interface IWriterDal : IRepository<Writer>  //Irepositroy(Crud)işlemleri vardı miras aldık.<Writer>Irepositorydeki Tlere karşılık geliyor.
     {

     }
}
