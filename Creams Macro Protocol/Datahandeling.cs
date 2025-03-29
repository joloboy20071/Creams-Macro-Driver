using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Creams_Macro_Protocol
{
    public static class Datahandeling
    {
        private static void ComamndStorter(CommandType command) {
            switch (command.commandvalue) {
                case "1X1": 
                    volumeCommandHandeler(command); break;
            
            }
        
        }

        
        
        
        
        private static void volumeCommandHandeler(CommandType command) {
            // #TODO write volume Code
            Console.WriteLine($"pot:{command.commanddata[0]}, Volume:{command.commanddata[1]}");


        }

















        public static void SetupDataHandeler(SerialPort port) {

            port.DataReceived += new SerialDataReceivedEventHandler(DataHandeler);
        }

        private static void DataHandeler(object Sender, SerialDataReceivedEventArgs Eventarg) {
            SerialPort sp = (SerialPort)Sender;
            string indata = sp.ReadExisting();

            CommandType posibleCommand = new CommandType(indata);
            if (posibleCommand.ValidCommand) { ComamndStorter(posibleCommand); }

            


        }


        public static bool DataTest(string indata) {
            CommandType command = new CommandType(indata);
            if (command.ValidCommand) { ComamndStorter(command); }
            return command.ValidCommand;
        
        
        }















    }
}
