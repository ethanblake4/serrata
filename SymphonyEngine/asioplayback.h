#pragma once

#include "asiodrivers.h"
#include "asiolist.h"

int initAsioPlayback();
AsioDriverList* AsioGetDrivers();
int setupDriver(char* driverName);