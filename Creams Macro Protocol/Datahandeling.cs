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
        private static void CommandValidation(string InData) {
        
        
        
        }



















        public static void SetupDataHandeler(SerialPort port) {
            
            port.DataReceived += new SerialDataReceivedEventHandler(DataHandeler);    
            
        
        }

        private static void DataHandeler(object Sender, SerialDataReceivedEventArgs Eventarg) {
            SerialPort sp = (SerialPort)Sender;
            string indata = sp.ReadExisting();




        }



















    }
}
