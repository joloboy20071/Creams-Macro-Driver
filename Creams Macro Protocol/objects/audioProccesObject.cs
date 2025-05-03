using System.Runtime.InteropServices;


namespace Creams_Macro_Protocol
{
    public partial class audio 
    {
        public static List<audioProccesObject> ProccesObjects = new List<audioProccesObject>();

         public static class audioProcessObjectFactory {
            private static audioProccesObject CreateObject(IAudioSessionControl2 sesh) {
                string name;
                int PID = sesh.GetProcessId(out PID);
                sesh.GetDisplayName(out name);

                return new audioProccesObject(name, PID, sesh);



            
            }


            public static List<audioProccesObject> GetAudioObjects(List<IAudioSessionControl2> sessionlist)
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

            private string name;
            private int pid;
            private ISimpleAudioVolume volumeobj;

            private IAudioSessionControl2 ctl;

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
                if (volumeobj == null) { try { getVolume(); return; } catch { this.release(); } } 
                //  ^ Note should init new session enum and try and create new object 
                //  | unless there is a chance unmanaged objects dont get freed up in memory until next pc boot


                if (volumeobj != null)
                {
                    guid = Guid.Empty;
                    
                    volumeobj.SetMasterVolume(level / 100, ref guid);
                    return;
                }
                


            }











            public bool isalive() { throw new NotImplementedException(); }  //#TODO Create a function that cheks  

            public void release()
            {
                Marshal.ReleaseComObject(volumeobj);
                Marshal.ReleaseComObject(ctl);
                ProccesObjects.Remove(this);

            }









        }
    }
}