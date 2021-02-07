using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                EnumerateProcesses();
                EnumerateThreadsForPid(15016);
                EnumerateModuleForProcess(15016);
                StartAndKillProcess_Excel();
            }
        }

        private static void EnumerateProcesses()
        {
            var runningProcesses =
                from proc in Process.GetProcesses(".")
                orderby proc.Id
                select proc;

            Console.WriteLine("*********************************\n");

            foreach (var p in runningProcesses)
                Console.WriteLine($"-> PID: {p.Id},\tName: {p.ProcessName}");

            Console.WriteLine("*********************************\n");

            Console.ReadLine();
        }

        private static void EnumerateThreadsForPid(int Pid)
        {
            if(Process.GetProcessById(Pid) is Process theProcess)
            {
                string info;

                Console.WriteLine("*********************************\n");
                foreach (ProcessThread pt in theProcess.Threads)
                {
                    info = $"->Thread ID: {pt.Id}, \tStartTime: {pt.StartTime.ToShortTimeString()}, \tPriority: {pt.PriorityLevel}";
                    Console.WriteLine(info);
                }

                Console.WriteLine("*********************************\n");

                Console.ReadLine();
            }
        }

        private static void EnumerateModuleForProcess(int Pid)
        {
            if(Process.GetProcessById(Pid) is Process theProc)
            {
                string info;
                Console.WriteLine("*********************************\n");
                Console.WriteLine("here are modules for : {0}", theProc.ProcessName);
                foreach(ProcessModule pm in theProc.Modules)
                {
                    info = $"-> Mod name: {pm.ModuleName}, \tMod file: {pm.FileName}, \tBase Address: {pm.BaseAddress}";
                    Console.WriteLine(info);
                }
                Console.WriteLine("*********************************\n");

                Console.ReadLine();
            }
        }

        private static void StartAndKillProcess_Excel()
        {
            // start
            Process xlProc;
            try
            {
                xlProc = Process.Start("Excel.exe", "");
            }
            catch (InvalidOperationException ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }

            // kill
            Console.WriteLine("press Enter to kill {0} process..", xlProc);

            Console.ReadLine();
            try
            {
                xlProc.Kill();
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }


            Console.ReadLine(); 
        }
    }
}
