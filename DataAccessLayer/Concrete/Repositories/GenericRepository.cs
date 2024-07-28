using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    ////Methotların içini genericrepostiry dolduruyoruz.
    //Genericrepository-->Sayaesinde Crud işlemlerini tek tek categori,başlık.. yazmamıza gerek kalmıyor tek bir yapı kullanrak yapıyruz.
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T p)//Silmeyi entitiystate ile silmr yapmayı dendeik
        {
            var delete = c.Entry(p);
            delete.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
            //singleordefault entitiy framework kendi methodu biz yazmadık.Geriye sadece bir değer döndürecektik o yüzden.
        }

        public void Insert(T p)//Eklemeyi entitiystate ile ekleme yapmayı dendeik
        {
            var add = c.Entry(p);
            add.State = EntityState.Added;
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();//Şartlı listeleme
        }

        public void Update(T p)
        {
            var update = c.Entry(p);
            update.State = EntityState.Modified;//modified değiştri anlamında
            c.SaveChanges();
        }
    }
}
