using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
        public SuccessDataResult(T data) : base(data, true)
        {

        }
        public SuccessDataResult(string message) : base(default, true, message) // data olarak default gönder. parametre olarak sadece mesaj girilmesi istenir.
        {

        }
        public SuccessDataResult():base(default, true) // Hiç bir parametre verilmeden çalışır. İşlemin başarılı olduğunu gösterir o kadar.
        {

        }
    }
}
