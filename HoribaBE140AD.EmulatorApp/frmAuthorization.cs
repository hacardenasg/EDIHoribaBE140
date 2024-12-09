using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoribaBE140AD.EmulatorApp
{
    

    public partial class frmAuthorization : Form
    {
        private FactoryActivator activator;
        public frmAuthorization()
        {
            InitializeComponent();
            activator = new FactoryActivator();
        }

        private void frmAuthorization_Load(object sender, EventArgs e)
        {
            RequestCodeLabel.Text = activator.GenerateRequestCode();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean authCode = activator.AuthorizeCode(RequestCodeLabel.Text, AuthCodeTextbox.Text);
            if (authCode == true)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }
    }
}
