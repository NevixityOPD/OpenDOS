using System;
using System.Collections.Generic;

namespace OpenDOSLib.LibTaskManager
{
    public interface Task
    {
        string processName { get; }
        string processID { get; }

        TaskStatus currentTaskStatus { get; }

        TaskManager.delegateEvent taskToExecute();
    }
}