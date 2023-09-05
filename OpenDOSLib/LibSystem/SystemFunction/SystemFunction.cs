using System;
using System.Collections.Generic;

namespace OpenDOSLib.LibSystem.SystemFunction
{
    public interface SystemFunction
    {
        FunctionStatus currentFunctionStatus { get; }

        string functionName { get; }
        string functionDescription { get; }

        void InitializingSequence();
    }
}