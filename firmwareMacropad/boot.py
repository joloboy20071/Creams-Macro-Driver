import digitalio,board,storage, supervisor
from usb_hid import set_interface_name
import microcontroller


#set_names(in_jack_name="MacropadDataIn",out_jack_name="MAcropadDataOut")


supervisor.runtime.autoreload = True
supervisor.set_usb_identification(manufacturer="CreamsProductions",product="Creams-productions_MacropadV2",pid=6969,vid=9999)
set_interface_name("Creams-productions_MacropadV2")

import usb_cdc
usb_cdc.enable(console=True, data=True)
led = digitalio.DigitalInOut(board.LED)
pwmMode = digitalio.DigitalInOut(board.GP23)

led.direction = digitalio.Direction.OUTPUT
pwmMode.direction = digitalio.Direction.OUTPUT

pwmMode.value = True

button1 = digitalio.DigitalInOut(board.GP18)
button1.direction = digitalio.Direction.INPUT
button1.pull = digitalio.Pull.UP
def checkForDrive(button:digitalio.DigitalInOut):
   
      if button.value == True:
         button.deinit()
         storage.disable_usb_drive()
         led.value = True
         return 
      else:
          button.deinit()
          storage.enable_usb_drive()
      
   ## storage.disable_usb_drive() commented out while testing

      led.value = False
      print("disabling drive")





checkForDrive(button1)

# if not button1.value:
#    led.value = True
#    storage.enable_usb_drive()
   
# else :
#    led.value = True
#    #storage.disable_usb_drive()




