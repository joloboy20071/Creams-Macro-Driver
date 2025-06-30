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
        public static SerialPort sender;
        public static bool Handshooke
        {
            get
            {
                return handshooke;
            }
        }
        public static string? HandshookeComport
        {
            get
            {
                return handshookecomport;
            }
        }


        //================================================//

        private static List<string> ports()
        {

            List<Win32DeviceMgmt.DeviceInfo> allports = Win32DeviceMgmt.GetAllCOMPorts();

            List<string> PosableCompatibleports = new List<string>();

            for (int i = 0; allports.Count > i; i++)
            {
                string busName = allports[i].bus_description;

                if (busName.Contains(Defaults.busdiscriptionFilter))
                {
                    PosableCompatibleports.Add(allports[i].name);

                }
            }



            if (Confighandeler.settings.COMPORT == null)

            {
                for (int i = 0; i < PosableCompatibleports.Count; i++) { Logger.Debug(PosableCompatibleports[i]); }
                
                return PosableCompatibleports;
            }

            if (Confighandeler.settings.COMPORT != null) {
                Logger.Debug($"comport is not null but has value off {Confighandeler.settings.COMPORT}");
                PosableCompatibleports.Clear();
                PosableCompatibleports.Add(Confighandeler.settings.COMPORT);
               
            
             }
            return PosableCompatibleports;


        }

        public static void GetCompatibleDevice()
        {
            audio.VolumeLookupInnit();
            List<string> PosibleComports = ports();


            foreach(string comport in PosibleComports) { Logger.Debug(comport); }
            if (!(PosibleComports.Count > 0)) { Logger.Debug("posible ports not bigger than 0?"); }

            if (PosibleComports.Count > 0)
            {
                for (int i = 0; i < PosibleComports.Count; i++)
                {
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
                        //SerialObj.DsrHolding = true;

                        SerialObj.DataReceived += new SerialDataReceivedEventHandler(Datahandeling.DataHandeler);




                        if (!SerialObj.IsOpen) { SerialObj.Open(); } //checking if serialport is already open and if not opening it
                        sender = SerialObj;
                        SerialObj.Write(Defaults.HandshakeRequest);
                        Logger.Debug($"handshake requested, {Defaults.HandshakeRequest} waiting");
                        Thread.Sleep(300);
                        if (Datahandeling.Handshooke)
                        {
                            Logger.Info($"Macropad Found on COM port: [{SerialObj.PortName}]");

                            Task.Factory.StartNew(()=> { ProcessUpdateThread.StartUpdate(); });
                        }

                        Logger.Debug($"handshooke:{Datahandeling.Handshooke}");


                    }
                    catch
                    {
                        Logger.Error("ran into an isue");// 
                    }

                }


                




                //return null;

            }





            if (PosibleComports.Count == 0)
            {
                Logger.Warn("no macropad detected closing program");
                throw new Exception("no macropad");
            }








        }
    }
}
