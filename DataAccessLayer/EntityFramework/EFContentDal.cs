using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntitiyLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFContentDal : GenericRepository<Content>, IContentDal
    {
    }
}
