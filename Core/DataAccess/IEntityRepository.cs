using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // Generic constraint - Alınan parametre belirtilmesi 
    // Generic Repository nesnesi tanımlaması
    // T:class referans tip olabilir demektir. IEntity olabilir yada IEntityden implemente olan bir nesne olabilir.
    // new() : new'lenebilir olmalıdır. Bunun nedeni IEntity interface tipi gönderilmesini engellemektir.
    public interface IEntityRepository<T> where T:class,IEntity,new() 
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); // Expression delegete kullanım örneği. Filtre zorunlu değildir.
        T Get(Expression<Func<T, bool>> filter); // Filtre zorunlu girilmelidir.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
