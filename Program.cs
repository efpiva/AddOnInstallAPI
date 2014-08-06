/*
 *  Dover Framework - OpenSource Development framework for SAP Business One
 *  Copyright (C) 2014  Eduardo Piva
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *  
 *  Contact me at <efpiva@gmail.com>
 * 
 */
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
