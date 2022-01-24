using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        //using (NortwindContext context = new NortwindContext()) : context nesnesinin kullanımı bitince garbage collector ile nesneyi ramden atmaya yarıyor. İşlem hızı ve performans açısından önemlidir.
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of c#
            using (NortwindContext context = new NortwindContext()) //c# a özel yapıdır. Nesneler create edildikten sonra Using'e gelince garbage collector'e giderek beni bellekten çıkart komutu verir. Çünkü DBContext nesneleri ramde pahalı yer tutmaktadır.
            {
                var addedEntity = context.Entry(entity); // referansı yakala
                addedEntity.State = EntityState.Added; // o aslında eklenecek bir nesne
                context.SaveChanges(); // ilgili nesneyi şimdi ekle
            }
        }

        public void Delete(Product entity)
        {
            using (NortwindContext context = new NortwindContext())
            {
                var deletedEntity = context.Entry(entity); // referansı yakala
                deletedEntity.State = EntityState.Deleted; // o aslında silinecek bir nesne
                context.SaveChanges(); // ilgili nesneyi şimdi sil
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NortwindContext context = new NortwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NortwindContext context = new NortwindContext())
            {
                //ternary koşul operatör kullanımı 
                return filter == null 
                    ? context.Set<Product>().ToList() // filtre null ise bu taraf çalışır. 
                    : context.Set<Product>().Where(filter).ToList(); // filtre null değilse bu taraf çalışır.// veri tabanındaki bütün tabloyu listeye çevir ve geri dönüş yap. 
            }
        }

        public void Update(Product entity)
        {
            using (NortwindContext context = new NortwindContext())
            {
                var updatedEntity = context.Entry(entity); // referansı yakala
                updatedEntity.State = EntityState.Modified; // o aslında güncellenecek bir nesne
                context.SaveChanges(); // ilgili nesneyi şimdi güncelle
            }
        }
    }
}
