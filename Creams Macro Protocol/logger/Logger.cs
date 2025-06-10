using System;
using System.IO;

namespace Creams_Macro_Protocol
{
    internal static class Logger
    {

        readonly static string dir = @"./logs";

        readonly static string oldLogName = "log_OLD";
        readonly static string LogName = "log_Last";


       static bool first = true;

        readonly static String logPath = @$"./{dir}/{LogName}.txt";
        readonly static String OldlogPath = @$"./{dir}/{oldLogName}.txt";

        private static bool AppendToFile(string text) {

            if (File.Exists(logPath) && first) {


                if (File.Exists(OldlogPath)){  File.Delete(OldlogPath); }
                    File.Move(logPath, OldlogPath); 
                first = false;
            }



            if (!File.Exists(logPath)) { 
                if (!Directory.Exists(dir)) { 
                    Directory.CreateDirectory(dir);

                        } 
                
                File.Create(logPath).Close(); 
            
            }

            


            
            using (StreamWriter fileobj = File.AppendText(logPath))
            {
                try
                {
                    fileobj.Write(text);
                    return true;
                }
                catch { return false; }
            }
        }

        public static void Debug(string text) { AppendToFile($"[Debug]: {text}\n"); }
        
        public static void Info(string text) { AppendToFile($"[Info]: {text}\n"); }

        public static void Warn(string text) { AppendToFile($"[Warn]: {text}\n"); }

        public static void Error(string text) { AppendToFile($"[Error]: {text}\n"); }




    }
}
