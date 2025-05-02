using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Creams_Macro_Protocol;
public partial class audio
{
    public static class AudioHandeler
    {
        [Obsolete]
        public static List<AudioProcessInfo> AudioProcesses
        {
            get
            {
                return _audioProcesses;
            }
        }

        [Obsolete]
        private static List<AudioProcessInfo> _audioProcesses = new List<AudioProcessInfo>();
        [Obsolete]
        public struct AudioProcessInfo
        {
            public string ExecutableName;
            public int sessionId;
            public int pid;
            public ISimpleAudioVolume volume;
        }





        public static void SearchforAudio(string[] programArray)
        {

            List<Process> AudioProcesses = audio.GetAudioProcesses(audio.GetsessionEnum());
            List<AudioProcessInfo> Temp = new List<AudioProcessInfo>();


            for (int i = 0; i < AudioProcesses.Count; i++)
            {
                string AudioProcess = AudioProcesses[i].ProcessName.ToLower();
                if (programArray.Contains(AudioProcess))
                {
                    AudioProcessInfo processInfo = new AudioProcessInfo();
                    processInfo.ExecutableName = AudioProcess;
                    processInfo.pid = AudioProcesses[i].Id;
                    processInfo.volume = audio.GetVolume(processInfo.pid);
                    //processInfo.sessionId = AudioProcesses[i].SessionId;
                    processInfo.sessionId = -1;

                    Temp.Add(processInfo);

                }
            }

            //lock (AudioProcesses)
            {
                _audioProcesses.Clear();
                for (int i = 0; i < Temp.Count; i++)
                {
                    _audioProcesses.Add(Temp[i]);
                }
            }
            return;

























        }
    }
}