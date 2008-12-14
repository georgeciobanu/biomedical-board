using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ParallelPortDriver {
    public class ParallelPort {

        public ParallelPort() {
            if ( !System.IO.File.Exists("inpout32.dll") ) {
                throw new System.IO.FileNotFoundException("inpout32.dll file not found in " + System.IO.Directory.GetCurrentDirectory());
            }
        }

        [DllImport("inpout32.dll", EntryPoint = "Out32")]
        public static extern void Output( int PortAddress, int value );

        [DllImport("inpout32.dll", EntryPoint = "Inp32")]
        public static extern int Input( int PortAddress );

    }
}
