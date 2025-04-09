using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



namespace Creams_Macro_Protocol
{
    public static class Datahandeling
    {

        public static bool Handshooke = false;


        private static void ComamndStorter(CommandType command) {
            switch (command.commandvalue) {
                case "0X0R":
                    HandshakeHandeler(command); break;  return;

                case "1X1": 
                    volumeCommandHandeler(command); break;
            
            }
        
        }



        private static void HandshakeHandeler(CommandType command)
        {
            if (command.commanddata[0].Contains("4F4B")) { Handshooke = true; }
        }
        
        private static void volumeCommandHandeler(CommandType command) {
            // #TODO write volume Code
            Console.WriteLine($"pot:{command.commanddata[0]}, Volume:{command.commanddata[1]}");


        }


        public static void DataHandeler(object Sender, SerialDataReceivedEventArgs Eventarg) {

            SerialPort sp = (SerialPort)Sender;
            string indata = sp.ReadExisting();


            if (!Handshooke) { Thread.Sleep(300); }

            Console.WriteLine(indata);
            CommandType posibleCommand = new CommandType(indata);






            if (posibleCommand.ValidCommand) { ComamndStorter(posibleCommand); }

            

            //else { Console.WriteLine("hand not shooke"); }

            


        }


        public static bool DataTest(string indata) {
            CommandType command = new CommandType(indata);
            if (command.ValidCommand) { ComamndStorter(command); }
            return command.ValidCommand;
        
        
        }















    }
}
