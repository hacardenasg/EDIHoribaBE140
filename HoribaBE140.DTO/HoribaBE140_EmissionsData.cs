using System;
using System.Collections.Generic;
using System.Text;

namespace HoribaBE140
{
    public class HoribaBE140_EmissionsData
    {
        public Boolean HexaneEquivalent { get; set; }
        public Boolean TemperatureCheckStatus { get; set; }
        public Boolean PressureCheckStatus { get; set; }
        public Boolean O2CheckStatus { get; set; }
        public Boolean NOxCheckStatus { get; set; }
        public Boolean HCCheckStatus { get; set; }
        public Boolean COCheckStatus { get; set; }
        public Boolean CO2CheckStatus { get; set; }

        public double HC { get; set; }
        public double CO { get; set; }
        public double CO2 { get; set; }
        public double O2 { get; set; }
        public double NOx { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }

        public HoribaBE140_EmissionsData()
        {
            HC = 0;
            CO = 0;
            CO2 = 0;
            O2 = 20.9;
            Pressure = 450;
            Temperature = 24;
        }
    }
}
