using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using System.IO;

using System.ComponentModel.DataAnnotations;

namespace Creams_Macro_Protocol;















public class Confighandeler
{
    public static settingObj settings = Getconfig();


    
    public static Dictionary<string, string> PotToProgram = new Dictionary<string, string>() { { "01", settings.VolumeAdjustedPrograms[0] }, { "10", settings.VolumeAdjustedPrograms[1] }, { "11", settings.VolumeAdjustedPrograms[2] } };
    public static Dictionary<int, string> intToPot = new Dictionary<int, string>() { { 0, "01" }, { 1, "10" }, { 2, "11" } };
   


    private static void CreateJsonFile(string path, settingObj Object)
    {
        string jsonString = JsonConvert.SerializeObject(Object);
        //Console.WriteLine(jsonString);

        Logger.Info(jsonString);


        using (FileStream fs = File.Create(path))
        {
            byte[] info = new UTF8Encoding(true).GetBytes(jsonString);
            fs.Write(info, 0, info.Length);
            fs.Close();
        }
        
    }

    private static settingObj ReadJson(string path)
    {
        string text = File.ReadAllText(path);

        var config = JsonConvert.DeserializeObject<settingObj>(text);
        
        
        return config;
    }

    public static settingObj Getconfig() // run this to get stored settings
    {
        string path = @"./Settings.json";

        if (!File.Exists(path)) {
            settingObj defaultSettings = new settingObj();
            
            CreateJsonFile(path, defaultSettings);

            return defaultSettings;

        }
        
        settingObj settings = ReadJson(path);

        
       
        Logger.Info($"config loaded: {JsonConvert.SerializeObject(settings)}");

        return settings;




    }






}
