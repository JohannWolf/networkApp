using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networkApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Application to get the password from the known wifi networks

            //Variables
            string userSelection = "";
            string commandStarter = "";
            string command = "";

            //Show to user
            Console.WriteLine("Application to get the password from the known wifi networks and do some other network changes");
            Console.WriteLine("********************************************************************************************** \n");
            Console.WriteLine("Hello, Welcome to Network app, please select what you want by tipying a number:");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("1.- Get the password of a specific known network");
            Console.WriteLine("2.- Flush the DNS");
            Console.WriteLine("3.- Get your IP");
            Console.WriteLine("4.- Renew your IP");

            //Read User selection
            userSelection = Console.ReadLine();

            //Command parameters depending on user selection
            switch (userSelection)
            {
                case "1":
                    //Show the name of the known networks
                    commandStarter = "netsh";
                    command = " wlan show profile ";
                    Console.WriteLine(RunCommand(commandStarter,command));
                    Console.WriteLine("Please type the name of the Network:");
                    userSelection = Console.ReadLine();
                    command = command + userSelection + " key=clear";
                    Console.WriteLine(RunCommand(commandStarter,command));
                    break;
                case "2":
                    //Flush DNS
                    commandStarter = "ipconfig";
                    command = " /flushdns";
                    Console.WriteLine(RunCommand(commandStarter, command));
                    break;
                case"3":
                    //Show current IP
                    commandStarter = "ipconfig";
                    command = " /all";
                    Console.WriteLine(RunCommand(commandStarter, command));
                    break;
                case "4":
                    //Renew IP
                    commandStarter = "ipconfig";
                    command = " /release";
                    Console.WriteLine(RunCommand(commandStarter, command));
                    commandStarter = "ipconfig";
                    command = " /renew";
                    Console.WriteLine(RunCommand(commandStarter, command));
                    break;
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            //Function to run CMD command
            string RunCommand(string starter ,string commandArgs)
            {
                ProcessStartInfo psi = new ProcessStartInfo(starter, commandArgs);
                psi.UseShellExecute = false;
                psi.RedirectStandardOutput = true;
                var proc = Process.Start(psi);
                string commandOutput = proc.StandardOutput.ReadToEnd();
                return commandOutput;
            }
        }
    }
}
