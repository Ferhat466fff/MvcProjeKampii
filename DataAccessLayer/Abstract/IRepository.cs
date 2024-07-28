using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>//Burası İmza kısmı imza attık Methotların içini genericrepostiry dolduruyoruz.
    {
        List<T> List();//herkesi listeleme.
        void Insert(T p);
        T Get(Expression<Func<T, bool>> filter);//Id Göre Alma
        void Delete(T p);
        void Update(T p);

        List<T> List(Expression<Func<T, bool>> filter);//Filtreleme Methodu(listeleme)
    }
}
