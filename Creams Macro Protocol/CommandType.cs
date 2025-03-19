using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creams_Macro_Protocol
{
    struct CommandType {

        

        private string? CommandValue;
        private string[]? CommandData;

        public string commandvalue { get{ return CommandValue; } }
        public string[]? commanddata {get{ return CommandData; } }

        public CommandType(string Input) {
            Input = Input.Replace(" ", "");
            if (Input.Contains("100001") && Input.Contains("FFFFFF")) {
                int start = Input.IndexOf("100001");
                int end = Input.IndexOf("FFFFFFF");
                Input.Substring(start, end);
                


            
            }
        
        }



    }





}
