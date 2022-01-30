using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    /// <summary>
    /// İnterface olarak IEntity nesnesini vermememizin nedenleri;
    /// IEntity veritabanı nesnelerine karşılık geldiği için,
    /// IEntity'deki nesneleri direkt veri tabanına kayıt etme işlemini gerçekleştirdiği için,
    /// biz bu durumların yaşanmasını istemediğimizden dolayı IDto isimli interface tanımlanamsı yapıp ilgili class'lar ile ilişkilendirdik.
    /// </summary>
    public class ProductDetailDto : IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
