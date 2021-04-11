using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message) // data olarak default gönder. parametre olarak sadece mesaj girilmesi istenir.
        {

        }
        public ErrorDataResult() : base(default, false) // Hiç bir parametre verilmeden çalışır. İşlemin başarısız olduğunu gösterir o kadar.
        {

        }
    }
}
