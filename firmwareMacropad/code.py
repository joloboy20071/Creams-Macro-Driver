import usb_midi,usb_cdc,usb_hid, board
from digitalio import DigitalInOut, Direction, Pull
import time
import genericClasses,keyboardclass
import supervisor
import commands

genericClasses.adcPin(board.A2, "11")
genericClasses.adcPin(board.A1, "10")
genericClasses.adcPin(board.A0, "01")



def mainLoop():
    while 1:
        keyboardclass.mkey()
        Handshooke = False
        while usb_cdc.data.connected:
            
            if Handshooke:
                stop = defaultruntime()
                Handshooke =stop
            if not Handshooke:
                if usb_cdc.data.in_waiting>0:
                    try: 
                        data = usb_cdc.data.readline()
                        re = commands.commandHandeling().runCommand(data)
                        if re[0] == '1000010X0R____4F4BFFFFFF':
                            Handshooke = True
                            usb_cdc.data.write(re[0])

                    except Exception as ex:
                       print(ex)



def defaultruntime():
    while usb_cdc.data.connected:
        keyboardclass.mkey()
        for i in genericClasses.ALLADCOBJECTLIST:   
            command = i.adcCommand()
            if command != None:
                if command[1] != False:
                    usb_cdc.data.write(f'{command[0]}\n')
                    print(f"{command[0]}\n")
                    pass
        time.sleep(0.02)

        if usb_cdc.data.in_waiting>0:
            try: 
                command = usb_cdc.data.readline()
                commands.commandhandeling.runCommand(command)
            except: 
                pass
    return False

mainLoop()