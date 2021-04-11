using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        // İşlemin başarılı olduğu durumlarda dönmesi planlanan tip.
        public SuccessResult(string message): base(true, message)  // Default olarak success true verilir.
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
