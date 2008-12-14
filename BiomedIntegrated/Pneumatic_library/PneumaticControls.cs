using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SerialBoard;

namespace PneumaticControls {

    public enum ValveStates { ON, OFF };

    #region Valve

    public class Valve {
        private ValveStates _state = ValveStates.OFF;
        private int _port;

        public Valve( int Port ) {
            _port = Port;
        }

        public ValveStates State {
            get {
                //TODO: read the value from the board
                return _state;
            }
            set {
                if ( value == ValveStates.ON ) {
                    SerialBoardDriver.SetPort(_port, 100);
                }
                else {
                    SerialBoardDriver.SetPort(_port, 0);
                }

                //clock
                SerialBoardDriver.SetPort(24, 0);
                System.Threading.Thread.Sleep(1);
                SerialBoardDriver.SetPort(24, 100);

                _state = value;
            }
        }

        public int Port {
            get {
                return _port;
            }
            set {
                //TODO: To warn + turn valve off beforehand
                _port = value;
            }
        }
    }
    #endregion Valve



    #region Pressure Controller

    public class PressureController {
        private int _port, _pressureRange, _percentageValue;

        public PressureController( int Port ) {
            _port = Port;
        }

        public int Percentage {
            get {
                //TODO: read the actual value
                return _percentageValue;
            }
            set {
                if ( value >= 0 && value <= 100 ) {
                    try {

                        SerialBoardDriver.SetPort(_port, value);
                        _percentageValue = value;

                    }
                    catch ( Exception e ) {
                        //this can be more elaborate
                        throw ( e );
                    }
                }
                else throw new ArgumentException("1-100% range expected");
            }
        }
    }
    #endregion Pressure Controller
}
