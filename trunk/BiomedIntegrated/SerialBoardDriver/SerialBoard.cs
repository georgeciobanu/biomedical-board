using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParallelPortDriver;


namespace SerialBoard {


    public class SerialBoardDriver {


        #region AD5380 Board Functions
        //special flags???

        //TODO: Add other modes
        private bool _buffered = false;

        public static int ReadData( int portaddress, int A, int RW, int port, int reg, double data ) { return 0; }

        public static void SetPort( int port, double percentage ) {
            WriteData(0x378, 0, 0, port, 3, percentage);
        }

        public static int WriteData(int portaddress, int A, int RW, int port, int reg, double percentage)
        {	
            int clock = 0, outvalue = 0;
            long value = 0;
            int port2 = portnumconv(port);
            int data2 = voltageconv(percentage);

            ParallelPort.Output(portaddress, 2); //sets SYNC to HIGH, clears previous data

            System.Threading.Thread.Sleep(1);

            ParallelPort.Output(portaddress, 0); //sets SYNC to LOW (falling edge starts input sequence)

            value += A;

            value = value << 1;
            value += RW;

            value = value << 6;
            value += port2;

            value = value << 2;
            value += reg;

            value = value << 14;
            value += data2;

            for (int i = 0; i < 24; i++)
            {

                outvalue = (int)(value & (1 << (24 - i)));
                outvalue = outvalue >> (24 - i);
                outvalue = outvalue << 2;

                clock = 1;
                outvalue += clock;	//xor them to write the clock in the string bit
                ParallelPort.Output(portaddress, outvalue);	//put the value on the port


                System.Threading.Thread.Sleep(1);

                outvalue -= clock;
                ParallelPort.Output(portaddress, outvalue);	//falling edge of the clock    
            }

            ParallelPort.Output(portaddress, 2); //sets SYNC to HIGH, clears previous data

            return 0;
        }

        private static int portnumconv(int port)
        {
            return port * 2 + 1;
        }

        private static int voltageconv(double V)
        {
            return (int)   (  (V * 32766.0 / 100) - 16383  );            
        }

        public static void reset(int index)
        {
            WriteData(0x378, 0, 0, index, 3, 0);
        }

        #endregion AD5380 Board Functions
    }
}


        