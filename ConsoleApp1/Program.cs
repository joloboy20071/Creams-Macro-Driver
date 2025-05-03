using Creams_Macro_Protocol;
using System.IO.Ports;
using CreamsConsole_utils;
using System.Reflection.PortableExecutable;
using System.Diagnostics;

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

                // ComHandshake.GetCompatibleDevice();

                //Console.WriteLine(serialObject.PortName);
                //serialObject.Close();
                Console.ReadLine();

            }
        }
    }
}



public class program {
    [STAThread]
    public static void Main() {
    
        CreamsMacroRuntime.runtime.mainRuntime();
    
    
    }


}