using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Creams_Macro_Protocol
{
    public partial class audio 
    {
        public static List<audioProccesObject> ProccesObjects = new List<audioProccesObject>();

        public static Dictionary<string, float> VolumeLookup = new Dictionary<string, float>();

        public static void VolumeLookupInnit()
        {
            for (int i = 0; i < 101; i++) {
                VolumeLookup.Add($"{i}", i / 100f);
               
            
            }


        }





         public static class audioProcessObjectFactory {
            private static audioProccesObject CreateObject(pidCtl2 sesh) {


                string name = sesh.process.ProcessName;
                int PID = sesh.pid;
                IAudioSessionControl2 shesh2 = sesh.clt;

                return new audioProccesObject(name, PID, shesh2);



            
            }


            public static List<audioProccesObject> GetAudioObjects(List<pidCtl2> sessionlist)
            {
               

                for (int i = 0; i < sessionlist.Count; i++) {
                    CreateObject(sessionlist[i]);

                }

                return ProccesObjects;

            }





            
        
        }











        public class audioProccesObject
        {








            public string Name
            {
                get {return name;}
            }

            public int Level
            {
                get
                {
                    return (int)Lastvolume;
                }
            }

            private string name;
            private int pid;
            private ISimpleAudioVolume volumeobj;

            private IAudioSessionControl2 ctl;


            private float Lastvolume = -1f;

            private Guid guid = Guid.Empty;

            public audioProccesObject(string name, int pid, IAudioSessionControl2 session)
            {
                this.name = name;
                this.pid = pid;
                this.ctl = session;
                volumeobj = getVolume();

                ProccesObjects.Add(this);

                return;
            }

            private ISimpleAudioVolume getVolume()
            {
                
                ISimpleAudioVolume volumeControl = null;
                if (ctl != null)
                {
                    volumeControl = ctl as ISimpleAudioVolume;
                }


                return volumeControl;

            }

            public void SetVolume(int level)
            {
                SetVolume(level / 100f);
                return;
            }

            public void SetVolume(float level)
            {
                if (level == Lastvolume) { return; }


                if (volumeobj == null) { try { getVolume(); return; } catch  { this.release(); Logger.Debug($"[{DateTime.Now}]: trying to get a volume object failed on audio obj: [name:{name}],[PID:{pid}]    ") ;  } } 
                //  ^ Note should init new session enum and try and create new object 
                //  | unless there is a chance unmanaged objects dont get freed up in memory until next pc boot


                if (volumeobj != null)
                {
                    guid = Guid.Empty;
                    
                    volumeobj.SetMasterVolume(level, ref guid);
                    Lastvolume = level;
                    return;
                }
                


            }


            public void SetVolume(string level)
            {
                SetVolume(VolumeLookup[level]);




            }








            public bool isalive() { throw new NotImplementedException(); }  //#TODO Create a function that cheks  

            public void release() /// not fully implemented because Idisposable isnt implemmented and should be in the futre
            {
                Marshal.ReleaseComObject(volumeobj);
                Marshal.ReleaseComObject(ctl);
                ProccesObjects.Remove(this);

            }









        }
    }
}