using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //Kategori ile ilgili dış dünyaya servis edilecek bilgileri içeren metot imzalarını barındırmaktadır.
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId);
    }
}
