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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        //Aradığımız Şeye göre listeleme yapma.
        public List<Content> GetList(string p)
        {
            return _contentDal.List(x => x.ContentValue.Contains(p));//aradığımız şeyi içermeli(contains).
        }

        public List<Content> GetListByHeadingId(int id)
        {
         return _contentDal.List(x => x.HeadingId==id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterId == id);
        }

        public void UpdateContent(Content content)
        {
            throw new NotImplementedException();
        }
    }
}
