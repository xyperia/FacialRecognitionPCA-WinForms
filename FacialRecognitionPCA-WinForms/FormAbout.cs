using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacialRecognitionPCA_WinForms
{
    public partial class FormAbout : MetroFramework.Forms.MetroForm
    {
        String[] softwareAbout = {
            "Operating System : Windows 10 Pro x64 Version 1909 Build 18363.959",
            "IDE : Microsoft Visual Studio Community 2019",
            ".NET Framework : Developer Pack 4.8",
            "User Interface : MetroFramework 1.4.0.0",
            "EMGU.CV Version : 3.1.0.2282",
            "MySQL Driver : 8.0.21.0",
            "Whatsapp Gateway : Twilio 5.45.0.0"
        };

        public FormAbout()
        {
            InitializeComponent();
            getAboutSoftware();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getAboutSoftware()
        {
            foreach (String _sContent in softwareAbout)
            {
                listAboutSoftware.Items.Add(_sContent);
            }
        }
    }
}
