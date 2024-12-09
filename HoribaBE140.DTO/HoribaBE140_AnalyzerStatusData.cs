using System;
using System.Collections.Generic;
using System.Text;

namespace HoribaBE140
{
    public class HoribaBE140_AnalyzerStatusData
    {
        //SS byte
        public Boolean ZeroECalInProgress { get; set; }
        public Boolean SpanMode { get; set; }
        public Boolean SpanCalibrationInProgress { get; set; }
        public Boolean ResetSpanInProgress { get; set; }
        public Boolean WarmUpInProgress { get; set; }

        //ZS byte
        public Boolean ZeroECalRequired { get; set; }
        public int ZeroECalInterval { get; set; }

        //OS byte
        public Boolean HexaneEquivalent { get; set; }

        //ES1 byte
        public Boolean ProcessorError { get; set; }
        public Boolean ROMChecksumError { get; set; }
        public Boolean RAMChecksumError { get; set; }
        public Boolean EEPROMChecksumError { get; set; }

        //CD1 byte
        public Boolean CO2ZerofactorOutOfRange { get; set; }
        public Boolean CO2SpanfactorOutOfRange { get; set; }

        //CD2 byte
        public Boolean COZerofactorOutOfRange { get; set; }
        public Boolean COSpanfactorOutOfRange { get; set; }

        //CD3 byte
        public Boolean HCZerofactorOutOfRange { get; set; }
        public Boolean HCSpanfactorOutOfRange { get; set; }

        //CD4 byte
        public Boolean PressureInputVoltageOutOfRange { get; set; }
        public Boolean TemperatureInputVoltageOutOfRange { get; set; }
        public Boolean NOxZerofactorOutOfRange { get; set; }
        public Boolean NOxSpanfactorOutOfRange { get; set; }
        public Boolean O2SpanfactorOutOfRange { get; set; }

    }
}
