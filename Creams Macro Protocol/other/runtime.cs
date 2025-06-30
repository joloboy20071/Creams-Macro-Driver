using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CreamsConsole_utils;
using System;
using Windows.Services.Maps;





namespace Creams_Macro_Protocol;

public class runtime
{


    const int SW_HIDE = 0;
    const int SW_SHOW = 5;
    private static Dictionary<bool, int> booltoShowHideMapForConsoleWindow = new Dictionary<bool, int>() { { true, SW_SHOW }, { false, SW_HIDE } };

    [DllImport("User32.dll", CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr h, string m, string c, int type);

    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


    [STAThread]
    public static void mainRuntime(bool console = true)
    {


      
        

        consoleAlloc.AllocConsole();
        var handle = GetConsoleWindow();
        ShowWindow(handle, booltoShowHideMapForConsoleWindow[console]);



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

        Logger.Info("staring audio update cycle ");

       // ProcessUpdateThread.StartUpdate();


       

    }

}
