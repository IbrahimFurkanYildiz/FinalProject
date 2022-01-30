using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    //Core katmanı evrensel katmandır. Tüm .Net projelerinde ortak kullanım için yazılmaktadır.
    //Core katmanı diğer katmanları referans almaz!! Alırsa ilgili katmana bağımlılık söz konusu demektedir.
    //IEntity implement eden bir class veri tabanı tablosudur. 
    public interface IEntity
    {
    }
}
