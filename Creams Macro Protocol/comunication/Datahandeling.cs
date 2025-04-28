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

            //Console.WriteLine($"pot:{command.commanddata[0]}, Volume:{command.commanddata[1]}");
            Task.Run(() =>
            {
                //if (command.commanddata[0] == "11")
                {
                    string programName = Confighandeler.PotToProgram[command.commanddata[0]];

                    for (int i = 0; i < AudioHandeler.AudioProcesses.Count; i++)
                    {
                        if (programName == AudioHandeler.AudioProcesses[i].ExecutableName)
                        {
                            float volume = (Int32.Parse(command.commanddata[1]));
                            AudioHelper.SetApplicationVolume(AudioHandeler.AudioProcesses[i], volume);
                            return;







                        }
                    }


                }
            });
        }


        public static void DataHandeler(object Sender, SerialDataReceivedEventArgs Eventarg)
        {

            SerialPort sp = (SerialPort)Sender;
            string indata = sp.ReadExisting();


            if (!Handshooke) { Thread.Sleep(300); } //Console.WriteLine(indata); }

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
