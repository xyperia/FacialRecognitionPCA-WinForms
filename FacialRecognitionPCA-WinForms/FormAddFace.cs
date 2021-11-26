using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacialRecognitionPCA_WinForms
{
    public partial class FormAddFace : MetroFramework.Forms.MetroForm
    {
        Image<Bgr, Byte> savedImage;
        String dirEigenFaces = Directory.GetCurrentDirectory() + @"\EigenFaces";

        public FormAddFace()
        {
            InitializeComponent();
            cbGender.SelectedIndex = 0;
            cbPriority.SelectedIndex = 0;
            picBoxAddFace.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void setImage(Image<Bgr, Byte> newImage)
        {
            picBoxAddFace.Image = newImage.Bitmap;
            savedImage = newImage;
        }

        void saveImage(Image<Bgr, Byte> newImage)
        {
            sqlLibrary _sqlLibrary = new sqlLibrary();
            _sqlLibrary.initializeDatabase();

            String fileName = txName.Text + "_" + txID.Text + ".bmp";
            newImage.Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic).Save(dirEigenFaces + @"\" + fileName);

            _sqlLibrary.insertNewEmployee(txID.Text, txName.Text, dtDOB.Text, cbGender.SelectedIndex.ToString(), fileName, txPhone.Text, cbPriority.SelectedIndex.ToString());
            this.DialogResult = DialogResult.OK;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveImage(savedImage);
        }

        private void cancelAdd()
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelAdd();
        }

        private void FormAddFace_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancelAdd();
        }
    }
}
