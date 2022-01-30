using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
    //constans : sabit demektir.
    //uygulama içerisindeki bu örnek uygulama için northwind db ye özel sabit ifadeler tanımlamak için kullanmaktayız.
    public static class Messages
    {
        //public erişim belirtecine sahip değişkenler pascalcase yazılır.
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        internal static string MaintenanceTime = "Sistem bakımdadır.";
        internal static string ProductsListed = "Ürünler listelendi.";
    }
}
