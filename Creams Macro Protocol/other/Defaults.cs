using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creams_Macro_Protocol
{
    public static class Defaults
    {
        private static string ComPortBusDiscriptionFilterName = "CDC2";
        public static string busdiscriptionFilter { get { return ComPortBusDiscriptionFilterName; } }

        private static string gooddataresponse = "1000010X0R____4F4BFFFFFF";
        public static string GoodDataResponse { get { return gooddataresponse; } }

        private static string handshakerequest = "1000010X0____73616E6479FFFFFF\n";
        public static string HandshakeRequest { get { return handshakerequest; } }



    }
}
