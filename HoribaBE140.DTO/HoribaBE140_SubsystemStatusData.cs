using System;
using System.Collections.Generic;
using System.Text;

namespace HoribaBE140
{
    public class HoribaBE140_SubsystemStatusData
    {
        //SF1 byte
        public Boolean SC08FaultCondition { get; set; }
        public Boolean B140FaultCondition { get; set; }
        public Boolean LowFlow { get; set; }

        //SF2 byte
        public Boolean ZeroInProgress { get; set; }
        public Boolean LeakInProgress { get; set; }
        public Boolean SinglePointSpanINProgress { get; set; }
        public Boolean TwoPointSpanLowInProgress { get; set; }
        public Boolean TwoPointAwaitingHigh { get; set; }
        public Boolean TwoPointSpanHighInProgress { get; set; }

        //SF3 byte
        public Boolean Zerofail { get; set; }
        public Boolean LeakTestFail { get; set; }
        public Boolean SpanFail { get; set; }

        //SF5 byte
        public Boolean Pump2On { get; set; }
        public Boolean Pump1On { get; set; }
        public Boolean Selenoid6On { get; set; }
        public Boolean Selenoid5On { get; set; }
        public Boolean Selenoid4On { get; set; }
        public Boolean Selenoid3On { get; set; }
        public Boolean Selenoid2On { get; set; }
        public Boolean Selenoid1On { get; set; }

        //SF6 byte
        public Boolean PressureActive { get; set; }
        public Boolean Input7Active { get; set; }
        public Boolean Input6Active { get; set; }
        public Boolean Input5Active { get; set; }
        public Boolean Input4Active { get; set; }
        public Boolean Input3Active { get; set; }
        public Boolean Input2Active { get; set; }
        public Boolean Input1Active { get; set; }
    }
}
