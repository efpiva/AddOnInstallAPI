using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AddOnInstallAPI
{
    class Program
    {
        [DllImport("C:\\Program Files\\SAP\\SAP Business One\\AddOnInstallAPI_x64.dll")]
        public static extern int EndInstallEx();

        [DllImport("C:\\Program Files\\SAP\\SAP Business One\\AddOnInstallAPI_x64.dll")]
        public static extern int SetAddOnFolder(string srcPath);
        
        [DllImport("C:\\Program Files\\SAP\\SAP Business One\\AddOnInstallAPI_x64.dll")]
        public static extern int RestartNeeded();
        
        
        static void Main(string[] args)
        {
            if (args.Length == 0 || (args.Length == 1 && args[0] == "-s"))
            {
                Console.WriteLine("Syntax error.");
                Console.WriteLine("Call AddOnInstallAPI.exe -i to notify install");
                Console.WriteLine("Call AddOnInstallAPI.exe -s Folder to change addon folder");
                Console.WriteLine("Call AddOnInstallAPI.exe -r to set restart needed");

                Environment.Exit(2);
            }

            if (args[0] == "-i")
            {
                EndInstallEx();
                Environment.Exit(0);
            }

            if (args[0] == "-s")
            {
                SetAddOnFolder(args[1]);
                Environment.Exit(0);
            }

            if (args[0] == "-r")
            {
                RestartNeeded();
                Environment.Exit(0);
            }

            Console.WriteLine("No valid arguments provided");
            Environment.Exit(1);
        }
    }
}
