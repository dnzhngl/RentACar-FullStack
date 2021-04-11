using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Temel voidler için başlangıç
    public interface IResult
    {
       // sadece get kullanılması : Sadece okunabilir
        bool Success { get; }  // Yapılan işlem başarılı mı başarısız mı?
                              
        string Message { get; } // Yapılan işlem sonucu döndürülmek istenen mesaj
    }
}
