using Creams_Macro_Protocol;

using CreamsConsole_utils;
using NotificationIcon.NET;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace CreamsMacroRuntime
{





    public class program
    {
        public static List<Task> programList = new List<Task> ();


        public static void Restart()
        {
            programList[0].Dispose();
            startdriver();

        }

        public static void ConsoleRestart()
        {
            programList[0].Dispose();
            startdriver(true);
        }

        private static void startdriver(bool console = false)
        {
            programList.Clear ();


            Task appFunction = Task.Factory.StartNew(() => { runtime.mainRuntime(console); });
            programList.Add(appFunction); 






        }



        public static void stop()
        {
            
            programList [0].Dispose();
            programList.Clear();


        }









        public static void Main()
        {

            //Creams_Macro_Protocol.runtime.mainRuntime(false);
            //Console.ReadLine();

            startdriver();
            NotifyIcon icon = NotifyIcon.Create(@"./creamsico.ico", new List<MenuItem>()
            {
               // new MenuItem("restart"){Click = (s,e) => {Restart(); }  },
                //new MenuItem("restart with console"){Click = (s,e) => {ConsoleRestart(); } },


                new MenuItem("Quit")
                {
                    Click = (s, e) =>
                    {
                        stop();
                        e.Icon.Dispose();
                    }
                }
            });
            icon.Show();














        }

    }
}