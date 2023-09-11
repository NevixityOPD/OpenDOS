using System;

namespace OpenDOS.Shell
{
    public class ExceptionHandler
    {
        public void HandleCommand(int commandIndex, string[] args)
        {
            try
            {
                Kernel.cmdMgr.shellCommand[commandIndex].cmdExecuteable(args);
            }
            catch(Exception e)
            {
                Console.WriteLine($"{Kernel.cmdMgr.shellCommand[commandIndex].cmdName}: Error occured {e.Message}");
            }
        }
    }
}
