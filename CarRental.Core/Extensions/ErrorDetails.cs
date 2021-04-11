//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CarRental.Core.Extensions
{
    /// <summary>
    ///  Will be used for systemic errors.
    /// </summary>
    public class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            //return JsonConvert.SerializeObject(this);  // NewtonSoft.Json
            return JsonSerializer.Serialize<object>(this); // System.Text.Json -> To included derived class properties into the serialization, type of serialization must be specified as <object>.
        }
    }
}
