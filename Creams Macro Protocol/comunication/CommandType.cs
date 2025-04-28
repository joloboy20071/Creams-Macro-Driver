
namespace Creams_Macro_Protocol
{
    struct CommandType {

        private string CommandPrefix = "100001";
        private string CommandEnd = "FFFFFF";

        private string? CommandValue;
        private string[]? CommandData;

        private bool valid = false;

        public string commandvalue { get{ if (valid) { return CommandValue; } return string.Empty;   } }
        public string[]? commanddata {get{ if (valid) { return CommandData; } return null; } }

        public bool ValidCommand { get { return valid; } }


        public CommandType(string Input) {
            Input = Input.Replace(" ", "").Replace("\n","");
            if (Input.Contains(CommandPrefix) && Input.Contains(CommandEnd)) {
                int start = Input.IndexOf(CommandPrefix);
                int end = Input.IndexOf(CommandEnd);
                if (start == -1 || end == -1) { valid = false; CommandData = null; CommandValue = null; return; }
                string data =Input.Substring(start+CommandPrefix.Length, end-CommandEnd.Length);
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
