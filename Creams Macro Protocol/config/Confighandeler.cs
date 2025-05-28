using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Creams_Macro_Protocol;

// temp dummy class for testing needs implementing
public class Confighandeler
{
    public static string[] programArray = new string[3] { "chrome", "spotify", "discord" };
    public static Dictionary<string,string> PotToProgram  = new Dictionary<string, string>() { { "01", programArray[0] }, { "10", programArray[1] }, { "11", programArray[2] } };
    public static Dictionary<int,string> intToPot = new Dictionary<int, string>() { { 0,"01"}, { 1,"10"}, { 2,"11"} };
    public static int UpdateIntervalms = 1000; 
    
    
    
}
public class SerialConfig
{



}