from const import TICKS_PERIOD,TICKS_MAX,TICKS_HALFPERIOD,MINTICKSDIFF # type: ignore
from analogio import AnalogIn
from supervisor import ticks_ms

from time import sleep

##############################################################################
# Ticks class is a implementation From CircuitPython Supervisor Example 
##############################################################################
class Ticks(object):
    
    @staticmethod
    def ticks_add(ticks, delta):
        return (ticks + delta) % TICKS_PERIOD
    
    @staticmethod
    def ticks_diff(ticks1, ticks2):
  
        diff = (ticks1 - ticks2) & TICKS_MAX
        diff = ((diff + TICKS_HALFPERIOD) & TICKS_MAX) - TICKS_HALFPERIOD
        return diff
    
    @staticmethod
    def ticks_less(ticks1, ticks2):
   
        return Ticks.ticks_diff(ticks1, ticks2) < 0

##############################################################################


##############################################################################
# Adc Pin class                                                             
##############################################################################

ALLADCOBJECTLIST = []




class adcPin:
    def __init__(self, pin,name):
        self.name = name
        self.pin = AnalogIn(pin)
        self.Lastval =-1
        self.__lasttick__ = ticks_ms()

        ALLADCOBJECTLIST.append(self)
        return 

    def __getvalue__(self):
        value = ((self.pin.value) / 63400)*100
        return value
    
    def getRaw(self):
        return self.pin.value
    
    def __proccesedVAl__(self):
        new__val = int(self.__getvalue__())
        if new__val>100:
            new__val=100

        if new__val== 1:
            other  = int(self.__getvalue__()) 
            if   other != 1:
                self.Lastval = other
                return other

        if new__val != self.Lastval:
            self.Lastval = new__val

            return self.Lastval
        


        print("None")
        return
        
    def valueCheck(self):
        if self.__lasttick__ != -1:
            New_Tick = ticks_ms()
            if Ticks.ticks_diff(New_Tick,self.__lasttick__) >= MINTICKSDIFF:
                self.__lasttick__ = New_Tick
               
                return (self.__proccesedVAl__(), True)
        return (MINTICKSDIFF - Ticks.ticks_diff(New_Tick,self.__lasttick__),False)
    
    def adcCommand(self):
        value = self.valueCheck()
        if value[1] == False:
            print((value[0]/1000))
            sleep((value[0]/1000)) 
            value = self.valueCheck()

            if value[0]==None:
                return (None,False)
                
            if value[0] == 1:
                other  = int(self.__getvalue__()) 
                if   other != 1:
                     return(f"1000011X1____{self.name}____{other}FFFFFF",True)


            return(f"1000011X1____{self.name}____{value[0]}FFFFFF",True)
         
        if value[1] == True:
            #if value[0] == None:return
            return (f"1000011X1____{self.name}____{value[0]}FFFFFF",True)    
        
##############################################################################
