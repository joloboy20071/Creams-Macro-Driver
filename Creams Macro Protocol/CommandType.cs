
namespace Creams_Macro_Protocol
{
    struct CommandType {

        

        private string? CommandValue;
        private string[]? CommandData;

        private bool valid = false;

        public string commandvalue { get{ if (valid) { return CommandValue; } return string.Empty;   } }
        public string[]? commanddata {get{ if (valid) { return CommandData; } return null; } }

        public bool ValidCommand { get { return valid; } }


        public CommandType(string Input) {
            Input = Input.Replace(" ", "");
            if (Input.Contains("100001") && Input.Contains("FFFFFF")) {
                int start = Input.IndexOf("100001");
                int end = Input.IndexOf("FFFFFFF");
                string data =Input.Substring(start, end);
                string[] command = data.Split("____");
                CommandValue = command[0];

                var commandlist = command.ToList();
                commandlist.RemoveAt(0);
                CommandData = commandlist.ToArray();
                valid = true;
                return;

            
            }
            valid = false;
            CommandData = null;
            CommandValue = null;
            return;
        }



    }





}
