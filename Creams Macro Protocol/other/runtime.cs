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

        Logger.Info($"use console : [{console}]");

        audio.AudioInit();
        
        Logger.Info("trying to init audio processes");
        Logger.Info("searching for Macropad");
        
        ComHandshake.GetCompatibleDevice();

        //Logger.Info("staring audio update cycle ");

        //ProcessUpdateThread.StartUpdate();


       

    }

}
