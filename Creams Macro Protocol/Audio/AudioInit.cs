using System.Runtime.InteropServices;

namespace Creams_Macro_Protocol
{
    public partial class audio
    {
        public static List<IAudioSessionControl2> AllUsefullCTL = new List<IAudioSessionControl2>();
        internal static List<IAudioSessionControl2> AllCtlProcesses = null;



        
        private static IMMDeviceEnumerator deviceEnumerator = null;
        private static IAudioSessionEnumerator sessionEnumerator = null;
        private static IAudioSessionManager2 mgr = null;
        private static IMMDevice speakers = null;

        public static int Count
        {
            get { return AllCtlProcesses.Count(); }
        }


















        private static List<IAudioSessionControl2> Getproces()
        {

            int count;



            if (mgr == null)
            {
                deviceEnumerator = (IMMDeviceEnumerator)(new MMDeviceEnumerator());
                deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia, out speakers);


                Guid IID_IAudioSessionManager2 = typeof(IAudioSessionManager2).GUID;
                object o;
                speakers.Activate(ref IID_IAudioSessionManager2, 0, IntPtr.Zero, out o);
                mgr = (IAudioSessionManager2)o;


            }

            mgr.GetSessionEnumerator(out sessionEnumerator);
            sessionEnumerator.GetCount(out count);


            List<IAudioSessionControl2> controlList = new List<IAudioSessionControl2>();

            for (int i = 0; i < count; i++)
            {

                IAudioSessionControl2 shesh;

                shesh.
                sessionEnumerator.GetSession(i, out shesh);
                controlList.Add(shesh);

            }

            if (sessionEnumerator != null) { Marshal.ReleaseComObject(sessionEnumerator); sessionEnumerator = null; }







            return controlList;



        }


        public static List<IAudioSessionControl2> audioFilter(List<IAudioSessionControl2> audiolist,string[] processNames)
        {
            List<IAudioSessionControl2> tempList = new List<IAudioSessionControl2>();
            string compare;


            for (int i = 0; i < audiolist.Count; i++) {


                
               ISimpleAudioVolume d = audiolist[i] as ISimpleAudioVolume;
                
                if (processNames.Contains(compare))
                {
                    tempList.Add(audiolist[i]);
                }

                        
            }
            return tempList;
        }


        []






        public static void AudioInit()
        {
            AllCtlProcesses = Getproces();

            var temp = audioFilter(AllCtlProcesses, Confighandeler.programArray);

            audioProcessObjectFactory.GetAudioObjects(temp);
                      
        }
    }
}
