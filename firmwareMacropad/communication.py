import usb_cdc, usb_hid, usb_midi
from CONST import READTICKS
import array,binascii
from commands import commandHandeling

class MidiComunication:
    def __init__(self):
        self.ports = usb_midi.ports
        self.__LastReadTicks__ = -1 
    	
   
    def ReadWithbuf(self):

        pass
        # not implement

    def WriteMidiMessage(self, message):
        print(self.ports[1].write(bytes(f'{message}','utf-8')))











class Serial:
    def __init__(self):
        self.Data = usb_cdc.data
        self.cdc = usb_cdc.console
        self.commandhandeler = commandHandeling()
    
    
    def CommandReciver():
        pass
                
            
        