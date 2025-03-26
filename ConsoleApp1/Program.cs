using Creams_Macro_Protocol;
using System.IO.Ports;



SerialPort serialObject = ComHandshake.GetCompatibleDevice();




serialObject.Close();