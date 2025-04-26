using Creams_Macro_Protocol;
using System.IO.Ports;
using CreamsConsole_utils;
namespace CreamsMacroRuntime
{
    public static class runtime
    {

        public static void mainRuntime()
        {
           CreamsConsole_utils.consoleAlloc.AllocConsole();

            string[] programArray =  new string[3] {"Spotify.exe","chrome.exe","discord.exe" };

            AudioHandeler.SearchforAudio();
            //ComHandshake.GetCompatibleDevice();
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