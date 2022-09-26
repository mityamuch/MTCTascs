using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            FailProcess1();
        }
        catch{}

        Console.WriteLine("Failed to fail process!");
        Console.ReadKey();
    }

    static void FailProcess()
    {
        System.Diagnostics.Process curProc= System.Diagnostics.Process.GetCurrentProcess();
        curProc.Kill();
        curProc.WaitForExit();                   
    }

    static void FailProcess1()
    {
        Process[] runningProcesses = Process.GetProcesses();
        System.Diagnostics.Process curProc = System.Diagnostics.Process.GetCurrentProcess();
        foreach (Process process in runningProcesses)
        {
            if (process.ProcessName == curProc.ProcessName)
                process.Kill();
        }
    }
    static void FailProcess2()
    {
        System.Diagnostics.Process curProc = System.Diagnostics.Process.GetCurrentProcess();
        StringBuilder sb = new StringBuilder("/F /IM ");
        sb.Append(curProc.ProcessName);
        sb.Append(".exe* /T");
        System.Diagnostics.Process.Start("taskkill",sb.ToString());
        //к сожалению в таком варианте исполнения процесс не может завершить сам себя
    }
    
    static void FailProcess3()
    {
        FailProcess3();
    }
/*
    static void FailProcess4()
    {
        using(Destroyer d= new Destroyer())
        {
            throw new ArgumentNullException("excep1");
        }
    }
    class Destroyer:IDisposable
    { 
        void IDisposable.Dispose()
        {
            throw new NotImplementedException("excep2");
        }
    }
*/
}
