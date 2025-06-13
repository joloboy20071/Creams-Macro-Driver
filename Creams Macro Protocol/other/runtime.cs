using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CreamsConsole_utils;
using System;




namespace Creams_Macro_Protocol;
public class runtime
{
    [DllImport("User32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr h, string m, string c, int type);
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

        if (!Confighandeler.settings.isTomEenMannenliefhebber) {
            Logger.Error("Paradox detected: TOM = Homofiel, Abort booting, stopping program");
            MessageBox((IntPtr)0, "Paradox detected: TOM = Homofiel, Abort booting, stopping program","config file error", 0);
            throw new Exception("Paradox detected: TOM = Homofiel, Abort booting, stopping program");


        }



        Logger.Info("searching for Macropad");
        
        ComHandshake.GetCompatibleDevice();

        //Logger.Info("staring audio update cycle ");

        //ProcessUpdateThread.StartUpdate();


       

    }

}
