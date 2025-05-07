using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

using static Creams_Macro_Protocol.AudioHelper;

namespace Creams_Macro_Protocol;
public partial class audio
{

    public static int counterI = 0;












    /* public static IAudioSessionEnumerator GetsessionEnum()
     {
         try { return sessionEnumerator; }
         catch { return null; }


     }

     private static int count;

     public static int SessionCount {
         get {  return count; }
     }


     /*private static IMMDeviceEnumerator deviceEnumerator = null;
     private static IAudioSessionEnumerator sessionEnumerator = null;
     private static IAudioSessionManager2 mgr = null;
     private static IMMDevice speakers = null;


     public static bool Release()
     {
         try
         {
             if (mgr != null) { Marshal.ReleaseComObject(mgr); }
             if (deviceEnumerator != null) { Marshal.ReleaseComObject(sessionEnumerator); }
             count = -1;
             return true;
         }
         catch { return false; }
     }



     // please make an session notifaction version






     // new better version

     public static List<Process> GetAudioProcesses(IAudioSessionEnumerator sessionEnumerator)
     {

         List<Process> audioProcesses = new List<Process>();





         // search for an audio session with the required process-id
         for (int i = 0; i < count; ++i)
         {
             IAudioSessionControl2 ctl2 = null;
             try
             {
                 sessionEnumerator.GetSession(i, out ctl2);
                 ctl2.GetProcessId(out int cpid);
                 try
                 {
                     audioProcesses.Add(Process.GetProcessById(cpid));
                 }
                 catch { Debug.WriteLine($" process not runnning with id {cpid}"); }
             }
             finally
             {
                 if (ctl2 != null) Marshal.ReleaseComObject(ctl2);
             }
         }

         return audioProcesses;
     }

     public static ISimpleAudioVolume GetVolume(int pid) {



         ISimpleAudioVolume volumeControl = null;
         for (int i = 0; i < count; i++)
         {
             IAudioSessionControl2 ctl2;

             int cpid;
             ctl2.GetProcessId(out cpid);

             if (cpid == pid)
             {
                 volumeControl = ctl2 as ISimpleAudioVolume;
                 break;
             }
             Marshal.ReleaseComObject(ctl2);
         }
         return volumeControl;
     }






     */

}

























