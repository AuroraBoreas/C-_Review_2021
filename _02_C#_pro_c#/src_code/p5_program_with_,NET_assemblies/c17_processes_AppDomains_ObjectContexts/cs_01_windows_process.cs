using System;

namespace WindowsProcess
{
    class Program
    {
        static int Main(string[] args)
        {
            // thread, P680
            {
                /*
                
                + definition
                    >> a path of execution within a process;
                    >> the first thread created by a process's entry point is termd "primary thread";

                + note
                    >> using too many threads in a single process can actually "degrade" performance;
                    >> why? CPU has to switch btwn the active threads in the proccess(which takes time);
                
                */ 

            }

            // interact with Process, P682
            {
                /*
                
                + Tool: using System.Diagnostics namespace
                    - Process           // access proceses, start and stop processs;
                    - ProcessModule     // represents any module(*.exe, *.dll) including COM-based, .NET-basd, or C-binaries;
                    - ProcessModuleCollection
                    - ProcessStartInfo  // specifies a set of values used when starting a process via the Process.Start() method
                    - ProcessThread     // is used to diagnose a process's thread
                    - ProcessThreadCollection

                + System.Diagnostics.Process, selected props
                    - ExitTime
                    - Handle
                    - Id
                    - MachineName
                    - MainWindowTitle
                    - Modules
                    - ProcessName
                    - Responding
                    - StartTime
                    - Threads
                
                + System.Diagnostics.Process, selected methods
                    - CloseMainWindow()
                    - GetCurrentProcess()
                    - GetProcesses()
                    - Kill()
                    - Start()
                
                */ 
                // List processes
                EnumerateRunningProcesses();

            }

            // Threads
            {
                /*
                
                + System.Diagnostics.ProcessThread, selected members
                    - CurrentPriority
                    - Id
                    - IdealProcessor
                    - PriorityLevel
                    - ProcessorAffinity
                    - StartAddress
                    - StartTime
                    - ThreadState
                    - TotalProcessorTime
                    - WaitReason

                + note
                    >> ProcessThread is NOT the entity used to create, suspend, or kill under the .NET platform;
                    >> rather is a vehicle used to obtain diagnosti info for the active windows threads wthin a running process;
                
                */ 

                // List threads for a Process, pID from above; chrome: 15016
                EnumerateThreadsForPid(15016);

            }

            // System.Diagnostics.ProcessModule
            {
                EnumerateModuleForProcess();
            }

            // Start and Kill a Process
            {
                StartAndKillProcess_excel();
            }
            
            return 0;
        }

        private static void EnumerateRunningProcesses()
        {
            var runningProcesses = 
            from proc in Process.GetProcess(".")
            orderby proc.Id
            select proc;

            System.Console.WriteLine("**********************\n");
            foreach(var p in runningProcesses)
            {
                System.Console.WriteLine($"-> PID: {p.Id}, \tName: {p.ProcessName}");
            }
            System.Console.WriteLine("**********************\n");
            Console.ReadLine();
            
        }
        
        private static void EnumerateThreadsForPid(int Pid)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(Pid);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return;
            }

            string info;

            System.Console.WriteLine("**********************\n");
            foreach(ProcessThread pt in theProc)
            {
                info = $"->Thread ID: {pt.Id}, \tStartTime: {pt.StartTime.ToShortTimeString()}, \tPriority: {pt.PriorityLevel}";
                System.Console.WriteLine(info);
            }
            System.Console.WriteLine("**********************\n");
            Console.ReadLine();
            
        }

        private static void EnumerateModuleForProcess(int Pid)
        {
            if(Process.GetProcessByID(Pid) is Process theProc)
            {
                string info;

                System.Console.WriteLine("**********************\n");
                System.Console.WriteLine("here are loaded modules for: {}", theProc.ProcessName);
                foreach(ProcessModule pm in theProc.Modules)
                {
                    info = $"-> Mod name: {pm.ModuleName}";
                    System.Console.WriteLine(info);
                }
                System.Console.WriteLine("**********************\n");
                Console.ReadLine();
            }
        }

        private static void StartAndKillProcess_excel()
        {
            Process chromeProc = null;
            try
            {
                chromeProc = Process.Start("Excel.exe", "www.bing.com");
            }
            catch(InvalidOperationException ex)
            {
                System.Console.WriteLine(ex.Message);
                return;
            }

            System.Console.WriteLine("-> Hit enter to kill {0}...", chromeProc.ProcessName);
            Console.ReadLine();
            
            // kill
            try
            {
                chromeProc.Kill();
            }
            catch (InvalidOperationException ex)
            {
                System.Console.WriteLine(ex.Message);
            }

        }
    }
}