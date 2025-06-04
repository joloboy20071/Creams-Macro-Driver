using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creams_Macro_Protocol;
public class settingObj:Object 
{
    public  string[] VolumeAdjustedPrograms  {get; set; } ={ "chrome", "spotify", "discord" };
    public int UpdateIntervalMS { get; set; } =  1000;
    public bool debug
    {
        get; set;
    } = false;

    public bool isTomEenMannenliefhebber { get; set; } = true;

    public string COMPORT { get; set; } = null; // tells the program that is should search for a compatibale port






}
