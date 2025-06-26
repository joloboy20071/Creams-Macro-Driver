class Command:
    def __init__(self):
        self.commandstart = "100001"
        self.commandEnd = "FFFFFF"
        self.commandFail = "2A2A2A2A"
        self.commandSucces = "4F4B"
        self.sepperator = "____"


class Handshake(Command):
    def __init__(self):
        super().__init__()
        self.initRe = "0X0R"
        self.aliveRE = "0X1R"


    def Handshakeinit(self, data:list):
        if len(data) == 1 and data[0] == "73616E6479":
            return (f"{self.commandstart}{self.initRe}{self.sepperator}{self.commandSucces}{self.commandEnd}",True)
        return (f"{self.commandstart}{self.initRe}{self.sepperator}{self.commandFail}{self.commandEnd}",True)

    def connectionAlive(self,data:list):
        if len(data) == 0:
            return (f"{self.commandstart}{self.aliveRE}{self.sepperator}{self.commandSucces}{self.commandEnd}",True)
        

class commandHandeling:
    def __init__(self):
        self.commandstart = "100001"
        self.commandEnd = "FFFFFF"


        self.Handshake = Handshake()



        self.commandList = {
        "0X0":self.Handshake.Handshakeinit,
        "0X1":self.Handshake.connectionAlive
        }

    def checkIfValidCommand(self,command):
        try:
            command= str(command)
            command = command.replace(" ", "")
            startIndex = command.index(self.commandstart)+len(self.commandstart)
            endindex = command.index(self.commandEnd)

            data = command[startIndex:endindex].split("____")
            comandfunc =self.commandList[data[0]]           
            data.pop(0)
            return (comandfunc, data)

        except ValueError:
            return ("Unkown command", False)
        
    def runCommand(self, value):
        args = self.checkIfValidCommand(value)

        if args[1]==False:
            return args
        return args[0](args[1])
       
