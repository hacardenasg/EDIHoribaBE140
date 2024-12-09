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
    public partial class frmPermisos : Form
    {
        private FactoryActivator activator;
        public frmPermisos()
        {
            InitializeComponent();
            activator = new FactoryActivator();
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {
            RequestCodeLabel.Text = activator.GenerateRequestCode();
        }

        private void button1_Click_1(object sender, EventArgs e)
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
