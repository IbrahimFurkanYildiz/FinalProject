using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //get readonly'dir. Constructor üzerinde set edilebilmektedir.
        //sadece Constructor üzerinde bir defa set etmek için sadece get özelliği verdik.
        //buradaki this ile base class'ı göstermemizdeki amaç DRY (Dont Repeat Yourself) prensibine uymaktır. Yani success özelliğini her iki yapıcı metot içerisinde de set etme işlemi için aynı kodu yazmamış olduk.
        public Result(bool success, string message):this(success) // this ilgili class'ı (bu) temsil eder. Burası için Result'ı temsil eder. () ile tek parametreli constructor'a erişim sağlamış oluyoruz.
        {
            Message = message;
        }
        //Overloading : Metot aşırı yükleme işlemi
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
