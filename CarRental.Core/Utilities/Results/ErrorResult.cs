using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // İşlemin başarılı olmadığı durumlarda dönmesi planlanan tip.
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message) // Base classa (Result) successi false gönderir.
        {
        }
        public ErrorResult() : base(false)
        {
        }
    }
}
