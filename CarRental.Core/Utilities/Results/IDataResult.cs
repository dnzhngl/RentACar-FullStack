using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Geriye bir data döndüren metotlar için
    //<T> : Hangi tipi döndüreceğini bana söyle
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
