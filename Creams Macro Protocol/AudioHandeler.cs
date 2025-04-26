using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Creams_Macro_Protocol;
public class AudioHandeler
{
    public  List<AudioProcessInfo> AudioProcesses
    {
        get { return _audioProcesses; }
    }

    private List<AudioProcessInfo> _audioProcesses = new List<AudioProcessInfo>();

    public struct AudioProcessInfo
    {
        public string ExecutableName;
        public string sessionId;
        public int pid;
        public bool Alive;


    }

    public static void SearchforAudio(string[] programArray){
        List<Process> AudioProcesses = AudioHelper.GetAudioProcesses();


        for (int i = 0; i < AudioProcesses.Count; i++) {
            Process AudioProcess = AudioProcesses[i];   






        }


    
    }



















}
