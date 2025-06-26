from micropython import const  # type: ignore

# Custommizable Constants #
MINTICKSDIFF = const(40)
READTICKS = const(100)

version = "2.0.0.0"


###########################


# should not be changed #

TICKS_PERIOD = const(1<<29)
TICKS_MAX = const(TICKS_PERIOD-1)
TICKS_HALFPERIOD = const(TICKS_PERIOD//2)


##########################
