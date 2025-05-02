using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Creams_Macro_Protocol
{
    public static class ProcessUpdateThread {
        static int updateineter = Confighandeler.UpdateIntervalms;
        public static bool running  = true;


        private static void updatethread() {
            try
            {
                while (running)
                {

                    Audio.UpdateSession();

                    Thread.Sleep(100);

                    AudioHandeler.SearchforAudio(Confighandeler.programArray);

                    Thread.Sleep(updateineter);








                }
            }
            finally { Audio.Release(); running = false; }
            
            

        
        }


        public static void Stop() {
            running = false;
            Debug.WriteLine("update thread stopping");
        }

        public static void Start() {
            
            running =true;
            Task.Factory.StartNew(() => {updatethread();});
            Debug.WriteLine("Update thread running");
            return;

        }



    }
    

}
