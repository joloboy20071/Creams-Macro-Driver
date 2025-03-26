using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Creams_Macro_Protocol
{
    internal static class Datahandeling
    {
        public static void comamndStorter(CommandType command) {
            switch (command.commandvalue) {
                case "0X0": 
                    volumeCommandHandeler(command); break;
            
            }
        
        }

        
        
        
        
        private static void volumeCommandHandeler(CommandType command) {
            // #TODO write volume Code


        }

















        public static void SetupDataHandeler(SerialPort port) {

            port.DataReceived += new SerialDataReceivedEventHandler(DataHandeler);
        }

        private static void DataHandeler(object Sender, SerialDataReceivedEventArgs Eventarg) {
            SerialPort sp = (SerialPort)Sender;
            string indata = sp.ReadExisting();

            CommandType posibleCommand = new CommandType(indata);
            if (posibleCommand.ValidCommand) { comamndStorter(posibleCommand); }

            


        }



















    }
}
