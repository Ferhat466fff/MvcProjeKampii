using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList(string p);
        List<Content> GetListByWriter(int id); //Yazarın Id Göre içeriğini getirme
        List<Content>GetListByHeadingId(int id); //Başlığın Id göre içeriğini getirme
        void ContentAdd(Content content);
        Content GetByID(int id);//Id göre alma.
        void ContentDelete(Content content);
        void UpdateContent(Content content);
    }
}
