using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HoribaBE140
{
    public class HoribaBE140Emulator
    {
        SerialPort _sp;
        public HoribaBE140_AnalyzerStatusData AnalyzerStatus;
        public HoribaBE140_SubsystemStatusData SubsystemStatus;
        public HoribaBE140_EmissionsData EmissionsData;
        public HoribaBE140_AnalyzerRevisionLevelData AnalyzerRevisionLevelData;

        BackgroundWorker bwZeroSecuence;
        BackgroundWorker bwLeakSecuence;

        //Background workes usados para procedimientos del banco
        private Boolean _inProcess = false;

        public Boolean InProcess
        {
            get { return _inProcess = false; }
        }

        //Thread tZeroProcess = new Thread(new ThreadStart(ThreadZeroProcess));

        //private  void ThreadZeroProcess()
        //{
        //    if(_inProcess == false)
        //    {
        //        _inProcess = true;
        //        //Enciendo la bomba por 20 segundos
                

        //    }
        //}

        private string _serial = "67654";
        public string Serial
        {
            get { return _serial; }
            set { _serial = value; }
        }

        private double _pef = 0.500;
        public double PEF
        {
            get { return _pef = 0.5; }
        }

        public HoribaBE140Emulator()
        {
            _sp = new SerialPort();
            _sp.BaudRate = 9600;
            _sp.Parity = Parity.None;
            _sp.DataBits = 8;
            _sp.StopBits = StopBits.One;
            _sp.DataReceived += _sp_DataReceived;

            AnalyzerStatus = new HoribaBE140_AnalyzerStatusData();
            SubsystemStatus = new HoribaBE140_SubsystemStatusData();
            EmissionsData = new HoribaBE140_EmissionsData();
            AnalyzerRevisionLevelData = new HoribaBE140_AnalyzerRevisionLevelData();

            bwZeroSecuence = new BackgroundWorker();
            bwZeroSecuence.DoWork += BwZeroSecuence_DoWork;

            bwLeakSecuence = new BackgroundWorker();
            bwLeakSecuence.DoWork += BwLeakSecuence_DoWork;

            AnalyzerRevisionLevelData.VendorID = "HORIBA";
            AnalyzerRevisionLevelData.ModelName = "B140";
            AnalyzerRevisionLevelData.RevisionLevel = "12";
        }

        private async void BwLeakSecuence_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SubsystemStatus.LeakInProgress = true;

            while (sw.ElapsedMilliseconds < 10000)
            {
                await Task.Delay(100);
            }
            sw.Stop();
            SubsystemStatus.LeakInProgress = false;
        }

        private async void BwZeroSecuence_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SubsystemStatus.ZeroInProgress = true;

            while (sw.ElapsedMilliseconds < 10000)
            {
                await Task.Delay(100);
            }
            sw.Stop();
            SubsystemStatus.ZeroInProgress = false;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            if(ba == null)
            {
                return String.Empty;
            }
            return BitConverter.ToString(ba);
        }

        private void _sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytesReceived = _sp.BytesToRead;
            byte[] command = new byte[bytesReceived];
            byte[] response = null;

            _sp.Read(command, 0, bytesReceived);
            File.AppendAllText("data.txt,",ByteArrayToString(command));
            switch (command[2])
            {
                case 0x01: //Analyzer status
                    Thread.Sleep(200);
                    response = mapper_AnalyzerStatus();
                    break;

                case 0x02: //Analyzer revision level
                    Thread.Sleep(150);
                    response = mapper_Revision();
                    break;

                case 0x04: //Analyzer serial number
                    Thread.Sleep(200);
                    response = mapper_AnalyzerSerialNumber();
                    break;

                case 0x11: //O2 span calibration
                    response = new byte[] { 0x06, 0x11, 0x00, 0xE9 };
                    break;

                case 0x35: //O2 zero calibration
                    break;

                case 0x18: //PEF
                    if (command[3] == 0 && command[4] == 0)
                    {
                        Thread.Sleep(150);
                        response = mapper_PEF();
                    }
                    break;

                case 0x20: //Zero eCal
                    response = new byte[] { 0x06, 0x20, 0x00, 0xDA };
                    EmissionsData.HC = 0;
                    EmissionsData.CO = 0;
                    EmissionsData.CO2 = 0;
                    EmissionsData.O2 = 20.9;
                    break;

                case 0x22: //reset span values to factory
                    break;

                case 0x40: //Transmit channel data
                    Thread.Sleep(250);
                    response = mapper_TransmitChannelData();
                    break;

                case 0xD0: //Transmit channel input voltage
                    break;

                case 0x12: //Gain adjustment
                    break;

                case 0x13: //Compensate interference CO2 channel
                    break;

                case 0x14: //Compensate interference CO channel 1
                    break;

                case 0x15: //Compensate interference CO channel 2
                    break;

                case 0x32: //Lineality adjustment 1 Low gas
                    break;

                case 0x33: //Lineality adjustment 2 High gas
                    break;

                case 0x34: //Lineality adjustment 3 Medium gas
                    break;

                case 0x31: //Pressure sensor zero calibration
                    break;

                case 0xA1: //Zero sequence
                    bwZeroSecuence.RunWorkerAsync();
                    break;

                case 0xA2: //Calibrate subsystem 1
                    break;

                case 0xA3: //Calibrate subsystem 2
                    break;

                case 0xA4: //Turn on/off selenoids
                    response = new byte[] { 0x06, 0xA4, 0x00, 0x56 };
                    if ((command[4] & 4) == 4)
                    {
                        SubsystemStatus.Selenoid3On = true;
                    }
                    else
                    {
                        SubsystemStatus.Selenoid3On = false;
                    }

                    if ((command[4] & 2) == 2)
                    {
                        SubsystemStatus.Selenoid2On = true;
                    }
                    else
                    {
                        SubsystemStatus.Selenoid2On = false;
                    }

                    if ((command[4] & 1) == 1)
                    {
                        SubsystemStatus.Selenoid1On = true;
                    }
                    else
                    {
                        SubsystemStatus.Selenoid1On = false;
                    }
                    break;

                case 0xA5: //Pump on/off
                    response = new byte[] { 0x06, 0xA5, 0x00, 0x55 };
                    if ((command[4] & 64) == 64)
                    {
                        SubsystemStatus.Pump1On = true;
                    }
                    else
                    {
                        SubsystemStatus.Pump1On = false;
                    }
                    break;

                case 0xA9: //Return vendor, product and version information
                    response = mapper_vendor();
                    break;

                case 0xAA: //Subsystem status
                    Thread.Sleep(50);
                    response = mapper_SubsystemStatus();
                    break;

                case 0xAB: //reset subsystem
                    break;

                case 0xAC: //Vacuum leak check
                    bwLeakSecuence.RunWorkerAsync();
                    break;

                case 0xAD: //Transmit channel data 1 set
                    break;

                case 0xD1:
                    response = mapper_voltage();
                    break;
            }
            
            if(response != null)
            {
                Debug.Print("Enviado: " + ByteArrayToString(response));
                _sp.Write(response, 0, response.Length);
            }
            
        }

        private byte[] mapper_voltage()
        {
            byte[] response = new byte[] { 0x06, 0xD1, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x18, 0x76, 0x00 };
            byte cs = calculateChecksum(response);
            response[15] = cs;

            return response;
        }

        private byte[] mapper_vendor()
        {
            byte[] response = new byte[] { 0x06, 0xA9, 0x18, 0x48, 0x4F, 0x52, 0x49, 0x42, 0x41, 0x53, 0x43, 0x30, 0x38, 0x31, 0x32, 
                0x48, 0x4F, 0x52, 0x49, 0x42, 0x41, 0x42, 0x31, 0x34, 0x30, 0x31, 0x32, 0x00 };
            byte cs = calculateChecksum(response);
            response[27] = cs;

            return response;
        }

        private byte[] mapper_PEF()
        {
            byte[] response = new byte[] {0x06, 0x18, 0x02, 0x00, 0x00, 0x00 };

            byte b0 = (byte)((_pef * 1000) % 256);
            byte b1 = (byte)((_pef * 1000) / 256);

            response[3] = b1;
            response[4] = b0;

            byte cs = calculateChecksum(response);
            response[5] = cs;

            return response;
        }

        private byte[] mapper_AnalyzerSerialNumber()
        {
            byte[] response = new byte[10] {0x06, 0x04, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] serial = System.Text.Encoding.UTF8.GetBytes(this.Serial);

            response[3] = serial[0];
            response[4] = serial[1];
            response[5] = serial[2];
            response[6] = serial[3];
            response[7] = serial[4];
            response[8] = serial[5];

            byte cs = calculateChecksum(response);
            response[9] = cs;

            return response;
        }

        /// <summary>
        /// Conecta con el banco de gases
        /// </summary>
        /// <param name="portName">Nombre del puerto. Ej: COM1, COM2, etc</param>
        /// <returns>Indica si hublo conexion exitosa con el puerto</returns>
        public Boolean Connect(string portName)
        {
            try
            {
                _sp.PortName = portName;
                _sp.Open();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Desconexion del puerto serial
        /// </summary>
        public void Disconnect()
        {
            if(_sp.IsOpen == true)
            {
                _sp.Close();
            }
        }

        /// <summary>
        /// Calcula el checksum del comando
        /// </summary>
        /// <param name="command">Comando sin checksum</param>
        /// <returns>Byte que representa el checksum del comando</returns>
        private byte calculateChecksum(byte[] command)
        {
            byte sum = 0;
            foreach (var item in command)
            {
                sum += item;
            }
            sum = (byte)((byte)~sum + 1);
            return sum;
        }

        private byte[] mapper_AnalyzerStatus()
        {
            byte[] response = new byte[] {0x06, 0x01, 0x0A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            //byte SS
            byte ss = 0;
            if(AnalyzerStatus.ZeroECalInProgress == true)
            {
                ss += 128;
            }
            if (AnalyzerStatus.SpanMode == true)
            {
                ss += 64;
            }
            if (AnalyzerStatus.SpanCalibrationInProgress == true)
            {
                ss += 32;
            }
            if (AnalyzerStatus.ResetSpanInProgress == true)
            {
                ss += 16;
            }
            if (AnalyzerStatus.WarmUpInProgress == true)
            {
                ss += 8;
            }
            response[3] = ss;

            //byte ZS
            byte zs = 0;
            if (AnalyzerStatus.ZeroECalRequired == true)
            {
                zs += 32;
            }
            zs += (byte)AnalyzerStatus.ZeroECalInterval;
            response[4] = zs;

            //byte OS
            byte os = 0;
            if (AnalyzerStatus.HexaneEquivalent == false)
            {
                os += 128;
            }
            response[5] = os;

            //byte ES1
            byte es1 = 0;
            if(AnalyzerStatus.ProcessorError == true)
            {
                es1 += 128;
            }
            if (AnalyzerStatus.ROMChecksumError == true)
            {
                es1 += 64;
            }
            if (AnalyzerStatus.RAMChecksumError == true)
            {
                es1 += 32;
            }
            if (AnalyzerStatus.EEPROMChecksumError == true)
            {
                es1 += 16;
            }
            response[6] = es1;

            //byte CD1
            byte cd1 = 0;
            if(AnalyzerStatus.CO2ZerofactorOutOfRange == true)
            {
                cd1 += 8;
            }
            if (AnalyzerStatus.CO2SpanfactorOutOfRange == true)
            {
                cd1 += 4;
            }
            response[9] = cd1;

            //byte CD2
            byte cd2 = 0;
            if (AnalyzerStatus.COZerofactorOutOfRange == true)
            {
                cd2 += 8;
            }
            if (AnalyzerStatus.COSpanfactorOutOfRange == true)
            {
                cd2 += 4;
            }
            response[10] = cd2;

            //byte CD3
            byte cd3 = 0;
            if (AnalyzerStatus.HCZerofactorOutOfRange == true)
            {
                cd3 += 8;
            }
            if (AnalyzerStatus.HCSpanfactorOutOfRange == true)
            {
                cd3 += 4;
            }
            response[11] = cd3;

            //byte CD4
            byte cd4 = 0;
            if (AnalyzerStatus.PressureInputVoltageOutOfRange == true)
            {
                cd4 += 64;
            }
            if (AnalyzerStatus.TemperatureInputVoltageOutOfRange == true)
            {
                cd4 += 32;
            }
            if (AnalyzerStatus.NOxZerofactorOutOfRange == true)
            {
                cd4 += 8;
            }
            if (AnalyzerStatus.NOxSpanfactorOutOfRange == true)
            {
                cd4 += 4;
            }
            if (AnalyzerStatus.O2SpanfactorOutOfRange == true)
            {
                cd4 += 2;
            }
            response[12] = cd4;

            byte checksum = calculateChecksum(response);
            response[13] = checksum;

            return response;
        }

        private byte[] mapper_SubsystemStatus()
        {
            byte[] response = new byte[] {0x06, 0xAA, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            byte sf1 = 0;
            if(SubsystemStatus.SC08FaultCondition == true)
            {
                sf1 += 128;
            }
            if (SubsystemStatus.B140FaultCondition == true)
            {
                sf1 += 64;
            }
            if (SubsystemStatus.LowFlow == true)
            {
                sf1 += 32;
            }
            response[3] = sf1;

            byte sf2 = 0;
            if (SubsystemStatus.ZeroInProgress == true)
            {
                sf2 += 16;
            }
            if (SubsystemStatus.LeakInProgress == true)
            {
                sf2 += 8;
            }
            if (SubsystemStatus.SinglePointSpanINProgress == true)
            {
                sf2 += 4;
            }
            if (SubsystemStatus.TwoPointSpanLowInProgress == true)
            {
                sf2 += 1;
            }
            if (SubsystemStatus.TwoPointAwaitingHigh == true)
            {
                sf2 += 2;
            }
            if (SubsystemStatus.TwoPointSpanHighInProgress == true)
            {
                sf2 += 3;
            }
            response[4] = sf2;

            byte sf3 = 0;
            if (SubsystemStatus.Zerofail == true)
            {
                sf3 += 4;
            }
            if (SubsystemStatus.LeakTestFail == true)
            {
                sf3 += 2;
            }
            if (SubsystemStatus.SpanFail == true)
            {
                sf3 += 1;
            }
            response[5] = sf3;

            byte sf5 = 0;
            if (SubsystemStatus.Pump2On == true)
            {
                sf5 += 128;
            }
            if (SubsystemStatus.Pump1On == true)
            {
                sf5 += 64;
            }
            if (SubsystemStatus.Selenoid6On == true)
            {
                sf5 += 32;
            }
            if (SubsystemStatus.Selenoid5On == true)
            {
                sf5 += 16;
            }
            if (SubsystemStatus.Selenoid4On == true)
            {
                sf5 += 8;
            }
            if (SubsystemStatus.Selenoid3On == true)
            {
                sf5 += 4;
            }
            if (SubsystemStatus.Selenoid2On == true)
            {
                sf5 += 2;
            }
            if (SubsystemStatus.Selenoid1On == true)
            {
                sf5 += 1;
            }
            response[7] = sf5;

            byte sf6 = 0;
            if (SubsystemStatus.PressureActive == true)
            {
                sf6 += 128;
            }
            if (SubsystemStatus.Input7Active == true)
            {
                sf6 += 64;
            }
            if (SubsystemStatus.Input6Active == true)
            {
                sf6 += 32;
            }
            if (SubsystemStatus.Input5Active == true)
            {
                sf6 += 16;
            }
            if (SubsystemStatus.Input4Active == true)
            {
                sf6 += 8;
            }
            if (SubsystemStatus.Input3Active == true)
            {
                sf6 += 4;
            }
            if (SubsystemStatus.Input2Active == true)
            {
                sf6 += 2;
            }
            if (SubsystemStatus.Input1Active == true)
            {
                sf6 += 1;
            }
            response[8] = sf6;

            byte cs = calculateChecksum(response);
            response[9] = cs;

            return response;
        }

        private byte[] mapper_TransmitChannelData()
        {
            byte[] response = new byte[] {0x06, 0x40, 0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            byte dsm = 0;
            if(EmissionsData.HexaneEquivalent == false)
            {
                dsm += 128;
            }
            if (EmissionsData.TemperatureCheckStatus == true)
            {
                dsm += 64;
            }
            if (EmissionsData.PressureCheckStatus == true)
            {
                dsm += 32;
            }
            if (EmissionsData.O2CheckStatus == true)
            {
                dsm += 16;
            }
            if (EmissionsData.NOxCheckStatus == true)
            {
                dsm += 8;
            }
            if (EmissionsData.HCCheckStatus == true)
            {
                dsm += 4;
            }
            if (EmissionsData.COCheckStatus == true)
            {
                dsm += 2;
            }
            if (EmissionsData.CO2CheckStatus == true)
            {
                dsm += 1;
            }

            response[3] = dsm;

            byte b0 = (byte)((EmissionsData.CO2 * 100) % 256);
            byte b1 = (byte)((EmissionsData.CO2 * 100) / 256);
            response[4] = b1;
            response[5] = b0;

            b0 = (byte)((EmissionsData.CO * 100) % 256);
            b1 = (byte)((EmissionsData.CO * 100) / 256);
            response[6] = b1;
            response[7] = b0;

            b0 = (byte)(EmissionsData.HC % 256);
            b1 = (byte)(EmissionsData.HC / 256);
            response[8] = b1;
            response[9] = b0;

            b0 = (byte)(EmissionsData.NOx % 256);
            b1 = (byte)(EmissionsData.NOx / 256);
            response[10] = b1;
            response[11] = b0;

            b0 = (byte)((EmissionsData.O2 * 100) % 256);
            b1 = (byte)((EmissionsData.O2 * 100) / 256);
            response[12] = b1;
            response[13] = b0;

            b0 = (byte)(EmissionsData.Pressure % 256);
            b1 = (byte)(EmissionsData.Pressure / 256);
            response[14] = b1;
            response[15] = b0;

            b0 = (byte)((EmissionsData.Temperature * 100) % 256);
            b1 = (byte)((EmissionsData.Temperature * 100) / 256);
            response[16] = b1;
            response[17] = b0;

            byte cs = calculateChecksum(response);
            response[18] = cs;

            return response;

        }

        private byte[] mapper_Revision()
        {
            byte[] response = new byte[] {0x06, 0x02, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            byte[] vendorId = Encoding.ASCII.GetBytes(AnalyzerRevisionLevelData.VendorID);
            byte[] modelName = Encoding.ASCII.GetBytes(AnalyzerRevisionLevelData.ModelName);
            byte[] revisionLevel = Encoding.ASCII.GetBytes(AnalyzerRevisionLevelData.RevisionLevel);

            response[3] = vendorId[0];
            response[4] = vendorId[1];
            response[5] = vendorId[2];
            response[6] = vendorId[3];
            response[7] = vendorId[4];
            response[8] = vendorId[5];

            response[9] = modelName[0];
            response[10] = modelName[1];
            response[11] = modelName[2];
            response[12] = modelName[3];

            response[13] = revisionLevel[0];
            response[14] = revisionLevel[1];

            byte cs = calculateChecksum(response);
            response[15] = cs;

            return response;
        }
    }
}
