// The main engine with all of the exported methods
#include "asioplayback.h";

#include <windows.h>

extern "C" {

	__declspec(dllexport) int initializeEngine() {
		return initAsioPlayback();
	}

	__declspec(dllexport) int getAudioDevices() {
		return 0;
	}

	__declspec(dllexport) void __stdcall getDrivers(
		/*[out]*/ char*** drivers_out,
		/*[out]*/ int* count_out)
	{

		AsioDriverList* asio_drivers = get_drivers();
		ASIODRVSTRUCT * drv = asio_drivers->lpdrvlist;

		*count_out = asio_drivers->numdrv;
		size_t stSizeOfArray = sizeof(char*) * asio_drivers->numdrv;

		*drivers_out = static_cast<char**>(::CoTaskMemAlloc(stSizeOfArray));
		memset(*drivers_out, 0, stSizeOfArray);

		for (int i = 0; i < asio_drivers->numdrv; i++)
		{
			(*drivers_out)[i] = static_cast<char*>(::CoTaskMemAlloc(strlen(drv->drvname) + 1));
			strcpy((*drivers_out)[i], drv->drvname);
			drv++;
		}


		return;
	}

	
}
