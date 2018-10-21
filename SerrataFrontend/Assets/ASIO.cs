using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ASIO : MonoBehaviour {
	
	// Use this for initialization
	void Start ()
	{
		
		Symphony.Instance.AudioDrivers.ForEach(Debug.Log);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
