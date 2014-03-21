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
            if (args.Length != 2)
            {
                Console.WriteLine("Syntax error.");
                Console.WriteLine(String.Format("Call {0} -i to notify install", args[0]));
                Console.WriteLine(String.Format("Call {0} -s Folder to change addon folder", args[1]));
                Console.WriteLine(String.Format("Call {0} -r to set restart needed", args[1]));

                Environment.Exit(2);
            }

            if (args[1] == "-i")
            {
                EndInstallEx();
                Environment.Exit(0);
            }

            if (args[1] == "-s")
            {
                SetAddOnFolder(args[2]);
                Environment.Exit(0);
            }

            if (args[1] == "-r")
            {
                RestartNeeded();
                Environment.Exit(0);
            }

            Console.WriteLine("No valid arguments provided");
            Environment.Exit(1);
        }
    }
}
