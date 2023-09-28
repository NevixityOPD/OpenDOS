using System;
using System.Collections.Generic;

namespace OpenDOS.Exception
{
    public class Exception
    {
        public Exception(string t, string d, ExceptionLevel e)
        {
            Title = t;
            ExceptionMessage = d;
            ExceptionLevel = e;
        }

        public string Title;
        public string ExceptionMessage;
        public ExceptionLevel ExceptionLevel;
    }
}
