using System;
using System.Collections.Generic;

namespace OpenDOSLib.LibTaskManager
{
    public class TaskManager : LibSystem.SystemFunction.SystemFunction
    {
        public string functionName => "task";
        public string functionDescription => "Task Manager";

        public LibSystem.SystemFunction.FunctionStatus currentFunctionStatus => LibSystem.SystemFunction.FunctionStatus.Development;

        public Queue<Task> taskQueue = new Queue<Task>();
        public delegate void delegateEvent();
        public event delegateEvent taskHandler;

        public void InitializingSequence()
        {
            if(currentFunctionStatus == LibSystem.SystemFunction.FunctionStatus.Ok)
            {
                OS.BootLog($"{functionName} is initialized");
            }
            else if (currentFunctionStatus == LibSystem.SystemFunction.FunctionStatus.Development)
            {
                OS.BootLog($"{functionName} is initialized. Warning {functionName} is currently under development, Things meant to change");
            }
            else if (currentFunctionStatus == LibSystem.SystemFunction.FunctionStatus.Broken)
            {
                OS.BootLog($"{functionName} is broken, Initializing sequence will not start");
            }
        }

        public void addTask(Task task)
        {
            if(task == null)
            {
                Console.WriteLine("Task is empty or null");
            }
            else
            {
                taskQueue.Enqueue(task);
            }
        }

        public void removeTask()
        {
            
        }

        public void executeTask()
        {
            Task placeHolder = taskQueue.Dequeue();
            taskHandler += placeHolder.taskToExecute();
            taskHandler.Invoke();
        }
    }
}