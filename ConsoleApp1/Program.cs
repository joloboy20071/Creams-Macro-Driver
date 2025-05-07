using Creams_Macro_Protocol;

using CreamsConsole_utils;

using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace CreamsMacroRuntime
{
    public static class runtime
    {

        public static void mainRuntime()
        {
            

            consoleAlloc.AllocConsole();
            //ProcessUpdateThread.Start();
            audio.AudioInit();
            for (int i = 0; i < audio.ProccesObjects.Count; i++)
            {
                Debug.WriteLine($"{audio.ProccesObjects[i].Name}");
            }

                ComHandshake.GetCompatibleDevice();

                Task.Run(() => { Thread.Sleep(10000); Debug.WriteLine(audio.counterI); Thread.Sleep(100000); Debug.WriteLine(audio.counterI); });
                //Console.WriteLine(serialObject.PortName);
                //serialObject.Close();
                Console.ReadLine();

            }
        }
    }




public class program {
    [STAThread]
    public static void Main() {
    
        CreamsMacroRuntime.runtime.mainRuntime();
    
    
    }


}