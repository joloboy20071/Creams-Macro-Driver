using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Creams_Macro_Protocol
{
    public static class ProcessUpdateThread
    {

        public static bool IsRunning
        {
            get
            {
                return isrunning;
            }
        }




        static bool isrunning = false;



        private static int GetAmountProcessesByName(string[] NameList)
        {
            Process[] process = Process.GetProcesses().Where(p => NameList.Contains(p.ProcessName.ToLower())).ToArray();
            return process.Length;
        }

        public static void StartUpdate()
        {
            int LastProgramCount = 0;


            isrunning = true;
            //Task.Run(() =>
            {
                while (isrunning)
                {
                    int newCount = GetAmountProcessesByName(Confighandeler.programArray);
                    if (newCount != LastProgramCount)
                    {
                        LastProgramCount = newCount;
                        Debug.WriteLine(newCount);
                        audio.AudioInit();
                    }
                    Thread.Sleep(1000);

                }






                //});



            }








        }
    }
}
