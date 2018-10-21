
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public static class InteropUtil
{
    private static void UnmanagedToManagedStrArray
    (
        IntPtr pUnmanagedStringArray,
        int stringCount,
        out string[] managedStringArray
    )
    {
        IntPtr[] pIntPtrArray = new IntPtr[stringCount];
        managedStringArray = new string[stringCount];

        Marshal.Copy(pUnmanagedStringArray, pIntPtrArray, 0, stringCount);

        for (int i = 0; i < stringCount; i++)
        {
            managedStringArray[i] = Marshal.PtrToStringAnsi(pIntPtrArray[i]);
            Marshal.FreeCoTaskMem(pIntPtrArray[i]);
        }

        Marshal.FreeCoTaskMem(pUnmanagedStringArray);
    }

    public static IEnumerable<string> ConvertStrArray(IntPtr pUnmanagedStringArray, int stringCount)
    {
        string[] managedStringArray = null;
        UnmanagedToManagedStrArray(pUnmanagedStringArray, stringCount, out managedStringArray);
        return managedStringArray;
    }
}