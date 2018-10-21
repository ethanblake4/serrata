// The main engine with all of the exported methods
#include "asioplayback.h";

#include <windows.h>

extern "C" {

	__declspec(dllexport) int InitializeEngine() {
		return initAsioPlayback();
	}

	__declspec(dllexport) void __stdcall GetDrivers(
		/*[out]*/ char*** drivers_out,
		/*[out]*/ int* count_out)
	{

		AsioDriverList* asio_drivers = AsioGetDrivers();
		ASIODRVSTRUCT * drv = asio_drivers->lpdrvlist;

		*count_out = asio_drivers->numdrv;
		size_t stSizeOfArray = sizeof(char*) * asio_drivers->numdrv;

		*drivers_out = (char**)::CoTaskMemAlloc(stSizeOfArray);
		memset(*drivers_out, 0, stSizeOfArray);

		for (int i = 0; i < asio_drivers->numdrv; i++)
		{
			(*drivers_out)[i] = (char*)::CoTaskMemAlloc(strlen(drv->drvname) + 1);
			strcpy((*drivers_out)[i], drv->drvname);
			drv = drv->next;
		}


		return;
	}

	
}
