import microcontroller
import supervisor

if supervisor.runtime.safe_mode_reason == supervisor.SafeModeReason.BROWNOUT:
    microcontroller.on_next_reset(run_mode=microcontroller.RunMode.NORMAL)
    microcontroller.reset()    





