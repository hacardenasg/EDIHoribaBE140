using HoribaBE140;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HoribaBE140AD.EmulatorApp
{
    public partial class Form1 : Form
    {
        HoribaBE140Emulator emu;
        BackgroundWorker bwUpdateMeasures;

        public double HCStep { get; set; } = 100;
        public double COStep { get; set; } = 0.5;
        public double CO2Step { get; set; } = 0.5;
        public double O2Step { get; set; } = 2;


        public bool Connected { get; set; } = false;

        public Form1()
        {
            InitializeComponent();
            emu = new HoribaBE140Emulator();

            bwUpdateMeasures = new BackgroundWorker();
            bwUpdateMeasures.WorkerSupportsCancellation = true;
            bwUpdateMeasures.DoWork += BwMeasures_DoWork;

            fillDeviceData();
        }

        private async void BwMeasures_DoWork(object sender, DoWorkEventArgs e)
        {
            bool processFinish = false;
            while (processFinish == false)
            {
                processFinish = true;
                double HCValue = trbHC.Value;
                if (emu.EmissionsData.HC < HCValue)
                {
                    if ((emu.EmissionsData.HC + HCStep) > HCValue)
                    {
                        emu.EmissionsData.HC = HCValue;
                    }
                    else
                    {
                        emu.EmissionsData.HC += HCStep;
                        processFinish = false;
                    }
                }
                else
                {
                    if ((emu.EmissionsData.HC - HCStep) < HCValue)
                    {
                        emu.EmissionsData.HC = HCValue;
                    }
                    else
                    {
                        emu.EmissionsData.HC -= HCStep;
                        processFinish = false;
                    }
                }

                double COValue = ((float)trbCO.Value / 100);
                if (emu.EmissionsData.CO < COValue)
                {
                    if ((emu.EmissionsData.CO + COStep) > COValue)
                    {
                        emu.EmissionsData.CO = COValue;
                    }
                    else
                    {
                        emu.EmissionsData.CO += COStep;
                        processFinish = false;
                    }
                }
                else
                {
                    if ((emu.EmissionsData.CO - COStep) < COValue)
                    {
                        emu.EmissionsData.CO = COValue;
                    }
                    else
                    {
                        emu.EmissionsData.CO -= COStep;
                        processFinish = false;
                    }
                }

                double CO2Value = ((float)trbCO2.Value / 100);
                if (emu.EmissionsData.CO2 < CO2Value)
                {
                    if ((emu.EmissionsData.CO2 + CO2Step) > CO2Value)
                    {
                        emu.EmissionsData.CO2 = CO2Value;
                    }
                    else
                    {
                        emu.EmissionsData.CO2 += CO2Step;
                        processFinish = false;
                    }
                }
                else
                {
                    if ((emu.EmissionsData.CO2 - CO2Step) < CO2Value)
                    {
                        emu.EmissionsData.CO2 = CO2Value;
                    }
                    else
                    {
                        emu.EmissionsData.CO2 -= CO2Step;
                        processFinish = false;
                    }
                }

                double O2Value = ((float)trbO2.Value / 100);
                if (emu.EmissionsData.O2 < O2Value)
                {
                    if ((emu.EmissionsData.O2 + O2Step) > O2Value)
                    {
                        emu.EmissionsData.O2 = O2Value;
                    }
                    else
                    {
                        emu.EmissionsData.O2 += O2Step;
                        processFinish = false;
                    }
                }
                else
                {
                    if ((emu.EmissionsData.O2 - O2Step) < O2Value)
                    {
                        emu.EmissionsData.O2 = O2Value;
                    }
                    else
                    {
                        emu.EmissionsData.O2 -= O2Step;
                        processFinish = false;
                    }
                }

                emu.SubsystemStatus.LowFlow = chbLowFlow.Checked;
                emu.SubsystemStatus.ZeroInProgress = chbZeroProgress.Checked;
                emu.AnalyzerStatus.WarmUpInProgress = chbWarming.Checked;
                emu.SubsystemStatus.LeakInProgress = chbLeakInProgress.Checked;
                await Task.Delay(250);
            }

            btnUpdate.Enabled = true;
            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //frmPermisos frmAuth = new frmPermisos();
            //DialogResult result = frmAuth.ShowDialog();

            //if (result == DialogResult.OK)
            //{
            cmbPorts.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            Form1.CheckForIllegalCrossThreadCalls = false;
            //}
            //else
            //{
            //    Application.Exit();
            //}

        }



        private void fillDeviceData()
        {
            //Cargamos los valores del banco
            trbHC.Value = (int)emu.EmissionsData.HC;
            lblHC.Text = emu.EmissionsData.HC.ToString();

            trbCO.Value = (int)(emu.EmissionsData.CO * 100);
            lblCO.Text = (emu.EmissionsData.CO).ToString("0.0");

            trbCO2.Value = (int)(emu.EmissionsData.CO2 * 100);
            lblCO2.Text = (emu.EmissionsData.CO2).ToString("0.00");

            trbO2.Value = (int)(emu.EmissionsData.O2 * 100);
            lblO2.Text = (emu.EmissionsData.O2).ToString();

            chbLowFlow.Checked = emu.SubsystemStatus.LowFlow;
        }


        private void btnSaveDeviceData_Click(object sender, EventArgs e)
        {
            emu.Serial = txbSerial.Text;

            MessageBox.Show("Datos del banco grabados exitosamente");
        }

        private void chbLowFlow_CheckedChanged(object sender, EventArgs e)
        {
            emu.SubsystemStatus.LowFlow = chbLowFlow.Checked;
        }

        private void ptbConnect_Click(object sender, EventArgs e)
        {
            if (Connected == false)
            {
                if (txbSerial.Text.Length != 6)
                {
                    MessageBox.Show("Serial incorrecto. Suministre uno con 6 caracteres");
                }
                else
                {
                    emu.Serial = txbSerial.Text;
                }

                if (emu.Connect(cmbPorts.Text) == false)
                {
                    MessageBox.Show("Problemas conectando el emulador");
                }
                else
                {
                    Connected = true;
                    ptbConnect.Image = Properties.Resources.plugout;
                }
            }
            else
            {
                ptbConnect.Image = Properties.Resources.plugin;
                emu.Disconnect();
                Connected = false;
            }
        }

        private void trbHC_Scroll(object sender, EventArgs e)
        {
            lblHC.Text = trbHC.Value.ToString();


        }

        private void trbCO_Scroll(object sender, EventArgs e)
        {
            var number = ((float)trbCO.Value / 100);
            lblCO.Text = number.ToString("0.0");

        }

        private void trbCO2_Scroll(object sender, EventArgs e)
        {
            var number = ((float)trbCO2.Value / 100);
            lblCO2.Text = number.ToString("0.00");
        }

        private void trbO2_Scroll(object sender, EventArgs e)
        {
            var number = ((float)trbO2.Value / 100);
            lblO2.Text = number.ToString("0.0");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            bwUpdateMeasures.RunWorkerAsync();
        }

        private void btnUpdateMeasurements_Click(object sender, EventArgs e)
        {
            fillDeviceData();
        }

        private void chbZeroProgress_CheckedChanged(object sender, EventArgs e)
        {
            emu.SubsystemStatus.ZeroInProgress = chbZeroProgress.Checked;
        }

        private void chbWarming_CheckedChanged(object sender, EventArgs e)
        {
            emu.AnalyzerStatus.WarmUpInProgress = chbWarming.Checked;
        }

        private void chbLeakInProgress_CheckedChanged(object sender, EventArgs e)
        {
            emu.SubsystemStatus.LeakInProgress = chbLeakInProgress.Checked;
        }
    }
}
