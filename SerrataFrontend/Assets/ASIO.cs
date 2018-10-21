using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ASIO : MonoBehaviour {
	
	[DllImport("symphony")]
	public static extern int initializeEngine();
	
	
	[DllImport("symphony", CallingConvention = CallingConvention.StdCall)]
	public static extern void getDrivers
	(
		out IntPtr UnmanagedStringArray,
		out int iStringsCountReceiver
	);
	
	// Use this for initialization
	void Start ()
	{
		Debug.Log("Wow did 5");

		initializeEngine();
		
		int iStringsCountReceiver = 0;
		IntPtr UnmanagedStringArray = IntPtr.Zero;

		getDrivers
		(
			out UnmanagedStringArray,
			out iStringsCountReceiver
		);

		string[] ManagedStringArray = null;

		MarshalUnmananagedStrArray2ManagedStrArray
		(
			UnmanagedStringArray,
			iStringsCountReceiver,
			out ManagedStringArray
		);

		Debug.Log("Wow did that");

		for (int i = 0; i < ManagedStringArray.Length; i++)
		{
			Debug.Log(String.Format("{0:S}", ManagedStringArray[i]));
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	static void MarshalUnmananagedStrArray2ManagedStrArray
	(
		IntPtr pUnmanagedStringArray,
		int StringCount,
		out string[] ManagedStringArray
	)
	{
		IntPtr[] pIntPtrArray = new IntPtr[StringCount];
		ManagedStringArray = new string[StringCount];

		Marshal.Copy(pUnmanagedStringArray, pIntPtrArray, 0, StringCount);

		for (int i = 0; i < StringCount; i++)
		{
			ManagedStringArray[i] = Marshal.PtrToStringAnsi(pIntPtrArray[i]);
			Marshal.FreeCoTaskMem(pIntPtrArray[i]);
		}

		Marshal.FreeCoTaskMem(pUnmanagedStringArray);
	}
}
