using System.Diagnostics;
using System.IO.Ports;



namespace Creams_Macro_Protocol
{
    public static class Datahandeling
    {

        public static bool Handshooke = false;


        private static void ComamndStorter(CommandType command)
        {
            switch (command.commandvalue)
            {
                case "0X0R":
                    HandshakeHandeler(command); break; return;

                case "1X1":
                    volumeCommandHandeler(command); break;

            }
            return;
        }



        private static void HandshakeHandeler(CommandType command)
        {
            if (command.commanddata[0].Contains("4F4B")) { Handshooke = true; }
        }

        private static void volumeCommandHandeler(CommandType command)
        {
            if (audio.counterI == 0) { Logger.Debug("first time volume handeler"); }

            if (audio.counterI == 50) { Logger.Debug("audio counter hit 50"); }
            // Debug.WriteLine($"pot:{command.commanddata[0]}, Volume:{command.commanddata[1]}");
            audio.counterI += 1;
            Task.Run(() =>
            {
                //if (command.commanddata[0] == "11")
                {
                    try
                    {
                        List<audio.audioProccesObject> list = audio.useableObjectList[command.commanddata[0]];
                        if (list.Count == 0) { return; }

                        for (int i = 0; i < list.Count; i++)
                        {
                            list[i].SetVolume(audio.VolumeLookup[command.commanddata[1]]);
                            Debug.WriteLine(list[i].Name);
                           
                        }
                        return;
                    }
                    catch{ Logger.Error("volume task returning bc error"); return; }

                    







                        }
                    


                
            });
        }


        public static void DataHandeler(object Sender, SerialDataReceivedEventArgs Eventarg)
        {

            SerialPort sp = ComHandshake.sender;
            string indata = sp.ReadExisting();


            if (!Handshooke) { Logger.Debug("sleepy sleepy time"); Thread.Sleep(300); } //Console.WriteLine(indata); }

            // Console.WriteLine(indata);
            CommandType posibleCommand = new CommandType(indata);






            if (posibleCommand.ValidCommand) { ComamndStorter(posibleCommand); }
            sp.DiscardInBuffer();
            return;

            //else { Console.WriteLine("hand not shooke"); }




        }


        public static bool DataTest(string indata)
        {
            CommandType command = new CommandType(indata);
            if (command.ValidCommand) { ComamndStorter(command); }
            return command.ValidCommand;


        }















    }
}
