using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //new() : new'lenebilir nesne anlamına gelmektedir.
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        //using (NortwindContext context = new NortwindContext()) : context nesnesinin kullanımı bitince garbage collector ile nesneyi ramden atmaya yarıyor. İşlem hızı ve performans açısından önemlidir.
        public void Add(TEntity entity)
        {
            //IDisposable pattern implementation of c#
            using (TContext context = new TContext()) //c# a özel yapıdır. Nesneler create edildikten sonra Using'e gelince garbage collector'e giderek beni bellekten çıkart komutu verir. Çünkü DBContext nesneleri ramde pahalı yer tutmaktadır.
            {
                var addedEntity = context.Entry(entity); // referansı yakala
                addedEntity.State = EntityState.Added; // o aslında eklenecek bir nesne
                context.SaveChanges(); // ilgili nesneyi şimdi ekle
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); // referansı yakala
                deletedEntity.State = EntityState.Deleted; // o aslında silinecek bir nesne
                context.SaveChanges(); // ilgili nesneyi şimdi sil
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //ternary koşul operatör kullanımı 
                return filter == null
                    ? context.Set<TEntity>().ToList() // filtre null ise bu taraf çalışır. 
                    : context.Set<TEntity>().Where(filter).ToList(); // filtre null değilse bu taraf çalışır.// veri tabanındaki bütün tabloyu listeye çevir ve geri dönüş yap. 
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); // referansı yakala
                updatedEntity.State = EntityState.Modified; // o aslında güncellenecek bir nesne
                context.SaveChanges(); // ilgili nesneyi şimdi güncelle
            }
        }
    }
}
