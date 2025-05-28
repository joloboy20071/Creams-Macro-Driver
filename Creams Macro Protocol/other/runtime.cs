using CreamsConsole_utils;


namespace Creams_Macro_Protocol;
public class runtime
{
    [STAThread]
    public static void mainRuntime(bool console = true)
    {


        if (console)
        {

            consoleAlloc.AllocConsole();
        }
        audio.AudioInit();
        ComHandshake.GetCompatibleDevice();
        ProcessUpdateThread.StartUpdate();


       

    }

}
