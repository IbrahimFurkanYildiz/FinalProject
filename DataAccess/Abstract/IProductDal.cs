using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //interface'in kendisi public erişime sahip değildir. Operasyonları public erişime sahiptir. 
    public interface IProductDal:IEntityRepository<Product>
    {
        
    }
}

//Core katmanından alınan referans ile diğer projelerede ilerleyen zamanlarda aynı kodları yazmamış olduk.
//Code Refactoring : Kod iyileştirilmesi 