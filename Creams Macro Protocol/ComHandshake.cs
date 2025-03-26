using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.IO.Ports;


namespace Creams_Macro_Protocol
{
   
    public static class ComHandshake
    {
        private static bool handshooke = false;
        private static string? handshookecomport = null;

        public static bool Handshooke { get { return handshooke; } }
        public static string? HandshookeComport { get {return handshookecomport; } }


        //================================================//

        private static List<string> ports() {

            List<Win32DeviceMgmt.DeviceInfo> allports= Win32DeviceMgmt.GetAllCOMPorts();

            List<string> PosableCompatibleports = new List<string>();

            for (int i = 0; allports.Count > i; i++)
            {
                string busName = allports[i].bus_description;

                if (busName.Contains(Defaults.busdiscriptionFilter)) {
                    PosableCompatibleports.Add(allports[i].name);
                
                }
            }

            return PosableCompatibleports;

        }

        public static SerialPort? GetCompatibleDevice() {

            List<string> PosibleComports = ports();



            if (PosibleComports.Count > 0)
            {
              for (int i =0; i< PosibleComports.Count; i++)  {
                    try
                    {
                        SerialPort SerialObj = new SerialPort(PosibleComports[i]);
                       
                        //serial Connection setup

                        SerialObj.BaudRate = 115200;
                        SerialObj.Parity = Parity.None;
                        SerialObj.StopBits = StopBits.One;
                        SerialObj.DataBits = 8;
                        SerialObj.Handshake = Handshake.None;
                        SerialObj.ReadTimeout = 2000;
                        SerialObj.DtrEnable = true;

                        // end 




                        if (!SerialObj.IsOpen) { SerialObj.Open(); } //checking if serialport is already open and if not opening it

                        SerialObj.Write(Defaults.HandshakeRequest);

                        Thread.Sleep(300);

                        if (SerialObj.BytesToRead > 0)
                        {
                            var incommingData = SerialObj.ReadExisting();

                            if (incommingData.Contains(Defaults.GoodDataResponse))
                            {

                                return SerialObj;
                            }

                            else
                            {
                                SerialObj.Close();
                                return null;

                            }

                        }

                    }
                    catch { // #TODO Create Logging message on error Containing catch error
                            };
                }

            }
            return null;

        }















    }
}
