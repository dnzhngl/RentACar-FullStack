using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Sen bir Result'sın. Result'ın constrcutorlarını implement etmelisin.
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message) //Base class olan Result classına success ve message'ı yolla. Burada ise datayı  gir
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success) // message parametresi gelmezse
        {
            Data = data;
        }
        public T Data {get;}
}
}
