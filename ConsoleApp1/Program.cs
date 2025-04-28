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


            AudioHandeler.SearchforAudio(Confighandeler.programArray);
            ComHandshake.GetCompatibleDevice();
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