using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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

        public static Dictionary<string, List<audioProccesObject>> useableObjectList = new Dictionary<string, List<audioProccesObject>>();


        public static int Count
        {
            get
            {
                return AllCtlProcesses.Count();
            }
        }




        public struct pidCtl2
        {
            public int pid;
            public IAudioSessionControl2 clt;
            public Process process;

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


                sessionEnumerator.GetSession(i, out shesh);
                controlList.Add(shesh);

            }

            if (sessionEnumerator != null) { Marshal.ReleaseComObject(sessionEnumerator); sessionEnumerator = null; }







            return controlList;



        }


        public static List<pidCtl2> audioFilter(List<IAudioSessionControl2> audiolist, string[] processNames)
        {
            List<pidCtl2> tempList = new List<pidCtl2>();



            for (int i = 0; i < audiolist.Count; i++)
            {
                Process compare;
                int PID;
                audiolist[i].GetProcessId(out PID);
                compare = Process.GetProcessById(PID);


                if (processNames.Contains(compare.ProcessName.ToLower()))
                {
                    pidCtl2 temp = new pidCtl2();
                    temp.pid = PID;
                    temp.clt = audiolist[i];
                    temp.process = compare;

                    tempList.Add(temp);
                }


            }
            return tempList;
        }









        public static void AudioInit()
        {

            if (useableObjectList.Count > 0)
            {
                for (int i = 0; i < useableObjectList.Count; i++) { for (int j = 0; j < useableObjectList[Confighandeler.intToPot[i]].Count(); j++) { useableObjectList[Confighandeler.intToPot[i]][j].release(); } }
            }


                AllCtlProcesses = Getproces();

                var temp = audioFilter(AllCtlProcesses, Confighandeler.programArray);
                ProccesObjects.Clear();
                audioProcessObjectFactory.GetAudioObjects(temp);

                useableObjectList.Clear();



                for (int i = 0; i < Confighandeler.programArray.Length; i++)
                {
                    List<audioProccesObject> templist = new List<audioProccesObject>();
                    for (int j = 0; j < ProccesObjects.Count; j++)
                    {
                        if (Confighandeler.programArray[i] == ProccesObjects[j].Name.ToLower())
                        {
                            templist.Add(ProccesObjects[j]);

                        }


                    }
                    useableObjectList.Add(Confighandeler.intToPot[i], templist);



                }






            
        }
    }
}
