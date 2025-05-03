using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creams_Macro_Protocol.comunication
{
    internal class SerialCom
    {
        public static SerialPort serialportobject = new SerialPort();

        public void StartReadLoop() {

            
            //TODO:
            //create a function that speeds up reading by using a buffer instead of using the dataRecivedEvent






            //if (serialportobject.BytesToRead > 0) { serialportobject }
            


        }







        public void Handshake() {
            
        
        }













    }
}
