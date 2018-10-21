using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public sealed class Symphony
{
    private static readonly Lazy<Symphony> lazy =
        new Lazy<Symphony>(() => new Symphony());
    
    public static Symphony Instance { get { return lazy.Value; } }
    
    [DllImport("symphony")]
    private static extern int InitializeEngine();
	
    [DllImport("symphony", CallingConvention = CallingConvention.StdCall)]
    private static extern void GetDrivers
    (
        out IntPtr driversOut,
        out int countOut
    );

    private List<string> _audioDrivers;

    public List<string> AudioDrivers
    {
        get
        {
            if (_audioDrivers != null) return _audioDrivers;
            
            int umDriverCount = 0; 
            IntPtr umDriverNames = IntPtr.Zero;
            GetDrivers(out umDriverNames, out umDriverCount);
            _audioDrivers = InteropUtil.ConvertStrArray(umDriverNames, umDriverCount).ToList();
            return _audioDrivers;
        }
    }


    private Symphony()
    {
        InitializeEngine();
    }
    
    
    
    
}