using Creams_Macro_Protocol;
using System.IO.Ports;


namespace CreamsMacroRuntime
{
    public static class runtime
    {

        public static void mainRuntime()
        {
            ComHandshake.GetCompatibleDevice();
            //Console.WriteLine(serialObject.PortName);
            //serialObject.Close();
            //Console.ReadLine();

        }
    }
}



public class program {

    public static void Main() {
    
        CreamsMacroRuntime.runtime.mainRuntime();
    
    
    }


}