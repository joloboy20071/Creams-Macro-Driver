using System;
using System.IO;

namespace Creams_Macro_Protocol
{
    internal static class Logger
    {
        readonly static String logPath = @".\logs\log-Last.txt";

        private static bool AppendToFile(string text) {
            
            if (!File.Exists(logPath)) { File.Create(logPath); }
            
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
