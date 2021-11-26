using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Linq;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;

namespace FacialRecognitionPCA_WinForms
{
    public partial class MainForms : MetroFramework.Forms.MetroForm
    {
        #region Variables
        Int32 eigenRes = 100;
        private Capture videoCapture = null;
        private Image<Bgr, Byte> currentFrame = null;
        Mat frame = new Mat();
        private bool faceDetectionEnabled = false;
        CascadeClassifier _CascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");
        Image<Bgr, Byte> faceResult = null;
        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, Byte>>();
        List<Int32> PersonsLabes = new List<Int32>();

        String logFileName = "FaceDetectionLogs.txt";
        String appExecTime;

        bool EnableSaveImage = false;
        private bool isTrained = false;
        EigenFaceRecognizer recognizer;
        List<String> PersonsNames = new List<String>();
        List<String> PersonsID = new List<String>();
        String dirEigenFaces = Directory.GetCurrentDirectory() + @"\EigenFaces";
        String faceBefore = null;
        Stopwatch execTime;

        String accountSID = "ACa3aa72fb610931bccabc54ba5d4d90da";
        String authToken = "62aed632e90f95c933ae78bce2f3897f";
        String senderNum = "+14155238886";
        String receiverNum = "+6285298000801";

        Double multiplyValue = 1;
        Int32 blurValue = 1;
        Int32 faceMatchIncrement = 1;
        Int32 logsNum = 1;
        Int32 maximumLogs = 100;

        Int32 eigenThreshold = 2000; // 0 - 8000 (Lower number harder to recognize) ~3500

        bool sendMessageEnabled = false;
        bool samePersonDetectionEnabled = false;

        #endregion

        public MainForms()
        {
            InitializeComponent();

            DateTime _dateTime = DateTime.Now;

            appExecTime = _dateTime.ToLongDateString();
            appExecTime.Replace(' ', '_');
            exportLogs("##### " + _dateTime.ToLongDateString() + " #####");
            startStream();

            picBoxFaceMatch1.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxFaceMatch2.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxFaceMatch3.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxFaceMatch4.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxEigenFace1.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxEigenFace2.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxEigenFace3.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxEigenFace4.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        void startStream()
        {
            //Dispose of Capture if it was created before
            if (videoCapture != null)
            {
                videoCapture.Dispose();
            }
            
            videoCapture = new Capture();
            Application.Idle += videoStream;
            trainEigenFaces();
            faceDetectionEnabled = true;
        }

        void addNewFace(Image<Bgr, Byte> _image)
        {
            EnableSaveImage = false;
            FormAddFace _formAddFace = new FormAddFace();
            _formAddFace.setImage(_image);
            if (_formAddFace.ShowDialog() == DialogResult.OK)
            {
                _formAddFace.Close();
                trainEigenFaces();
            }
        }

        private void videoStream(object sender, EventArgs e)
        {
            //Step 1: Video Capture
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                videoCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(picBoxPreview.Width, picBoxPreview.Height, Inter.Cubic);
                currentFrame._Mul(multiplyValue);
                currentFrame._SmoothGaussian(blurValue);
                currentFrame._Flip(FlipType.Horizontal);

                //Step 2: Face Detection
                if (faceDetectionEnabled)
                {
                    //Convert from Bgr to Gray Image
                    Mat grayImage = new Mat();
                    CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                    //Enhance the image to get better result

                    Rectangle[] faces = _CascadeClassifier.DetectMultiScale(grayImage, 1.1, 20, Size.Empty, Size.Empty);
                    //If faces detected
                    if (faces.Length > 0)
                    {
                        foreach (Rectangle face in faces)
                        {
                            //Step 3: Add Person 
                            Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                            resultImage.ROI = face;

                            if (EnableSaveImage)
                            {
                                //We will create a directory if does not exists!
                                if (!Directory.Exists(dirEigenFaces))
                                {
                                    Directory.CreateDirectory(dirEigenFaces);
                                }
                                resultImage.Resize(eigenRes, eigenRes, Inter.Cubic);
                                addNewFace(resultImage);
                            }

                            // Step 5: Recognize the face 
                            if (isTrained)
                            {
                                execTime = Stopwatch.StartNew(); // Start Exec Time Count

                                Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(eigenRes, eigenRes, Inter.Cubic);

                                FaceRecognizer.PredictionResult result = recognizer.Predict(grayFaceResult);
                                //Here results found known faces
                                if (result.Distance <= eigenThreshold)
                                {
                                    Int32 iResultDistance = Convert.ToInt32(result.Distance);
                                    Int32 confidenceValue = ((8000 - iResultDistance) * 100) / 8000;
                                    //CvInvoke.PutText(currentFrame, PersonsNames[result.Label], new Point(face.X - 2, face.Y - 2),FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(0, 255, 0).MCvScalar, 2);

                                    if (PersonsNames[result.Label] != faceBefore)
                                    {
                                        sqlLibrary _sqlLibrary = new sqlLibrary();
                                        _sqlLibrary.initializeDatabase();

                                        showMatchFaceToPictureBox(resultImage.Bitmap, TrainedFaces[result.Label].Bitmap);

                                        if (samePersonDetectionEnabled == false)
                                        {
                                            faceBefore = PersonsNames[result.Label];
                                        }

                                        try
                                        {
                                            if (_sqlLibrary.getEmployeePriority(PersonsID[result.Label]).Equals("1"))
                                            {
                                                Task.Factory.StartNew(() => {
                                                    sendMessage(PersonsNames[result.Label], result.Distance, confidenceValue.ToString(), "Success");
                                                });
                                            }
                                            else
                                            {
                                                writeLog(PersonsNames[result.Label], "Confidence : " + confidenceValue + "%" + ", EigenDistance : " + result.Distance, "Disabled", $"{execTime.ElapsedMilliseconds} ms");
                                            }
                                        }
                                        catch (Exception exc)
                                        {
                                            Console.WriteLine(exc);
                                        }
                                    }
                                }
                                else
                                {
                                    CvInvoke.Rectangle(currentFrame, face, new Bgr(0, 0, 255).MCvScalar, 2);
                                }
                            }
                            else
                            {
                                CvInvoke.Rectangle(currentFrame, face, new Bgr(0, 0, 255).MCvScalar, 2);
                            }
                        }
                    }
                }

                //Render the video capture into the Picture Box picCapture
                try
                {
                    picBoxPreview.Image = currentFrame.Bitmap;
                }
                catch(Exception picBoxExc)
                {
                    Console.WriteLine(picBoxExc);
                }
            }

            //Dispose the Current Frame after processing it to reduce the memory consumption.
            if (currentFrame != null)
            {
                currentFrame.Dispose();
            }
        }

        void showMatchFaceToPictureBox(Image _faceMatch, Image _eigenFace)
        {
            switch (faceMatchIncrement % 4)
            {
                case 1:
                    this.picBoxFaceMatch1.Image = _faceMatch;
                    this.picBoxEigenFace1.Image = _eigenFace;
                    break;
                case 2:
                    this.picBoxFaceMatch2.Image = _faceMatch;
                    this.picBoxEigenFace2.Image = _eigenFace;
                    break;
                case 3:
                    this.picBoxFaceMatch3.Image = _faceMatch;
                    this.picBoxEigenFace3.Image = _eigenFace;
                    break;
                case 0:
                    this.picBoxFaceMatch4.Image = _faceMatch;
                    this.picBoxEigenFace4.Image = _eigenFace;
                    break;
                default:
                    break;
            }
            faceMatchIncrement++;
        }

        private bool trainEigenFaces()
        {
            Int32 ImagesCount = 0;
            TrainedFaces.Clear();
            PersonsLabes.Clear();
            PersonsNames.Clear();
            PersonsID.Clear();

            try
            {
                String[] files = Directory.GetFiles(dirEigenFaces, "*.bmp", SearchOption.AllDirectories);

                foreach (String file in files)
                {
                    Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(eigenRes, eigenRes, Inter.Cubic);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabes.Add(ImagesCount);
                    String name = file.Split('\\').Last().Split('_')[0];
                    String id = file.Split('\\').Last().Split('_')[1];
                    PersonsNames.Add(name);
                    PersonsID.Add(id.Split('.')[0]);
                    ImagesCount++;
                    Debug.WriteLine(ImagesCount + ". " + name);
                }

                if (TrainedFaces.Count() > 0)
                {
                    recognizer = new EigenFaceRecognizer(ImagesCount, eigenThreshold);
                    recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());
                    isTrained = true;

                    return true;
                }
                else
                {
                    isTrained = false;

                    return false;
                }
            }
            catch (Exception exc)
            {
                isTrained = false;
                MessageBox.Show("Face Training Failed", exc.Message);

                return false;
            }
        }

        private void toolStripMenuItemAddFace_Click(object sender, EventArgs e)
        {
            EnableSaveImage = true;
        }

        private void picBoxPreview_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rightClickMenu.Show(MousePosition);
            }
        }

        void sendMessage(String _EmployeeName, Double _EmployeeFaceDistance, String _ConfidenceValue, String _MessageStatus)
        {
            if (sendMessageEnabled)
            {
                String time = DateTime.Now.ToString();
                try
                {
                    TwilioClient.Init(accountSID, authToken);
                    MessageResource message = MessageResource.Create(
                    from: new Twilio.Types.PhoneNumber("whatsapp:" + senderNum),
                    to: new Twilio.Types.PhoneNumber("whatsapp:" + receiverNum),
                     body: _EmployeeName + " sudah melakukan absensi pada waktu " + time
                    );
                }
                catch (Exception exc)
                {
                    _MessageStatus = "Failed";
                    Console.WriteLine(exc);
                }
            }
            else
            {
                _MessageStatus = "Disabled";
            }
            writeLog(_EmployeeName, "Confidence : " + _ConfidenceValue + "%" + ", EigenDistance : " + _EmployeeFaceDistance, _MessageStatus, $"{execTime.ElapsedMilliseconds} ms");
            execTime.Stop(); // Stop Exec Time Count
        }

        void writeLog(String _Name, String _LogContents, String _MessageStatus, String _ExecTime)
        {
            String _sTime = DateTime.Now.ToString();
            String _sClock = DateTime.Now.ToLongTimeString();
            ListViewItem _LvItem = new ListViewItem(new[]{ logsNum.ToString(), _sTime, _Name, _LogContents, _MessageStatus, _ExecTime });
            listViewLog.Invoke((MethodInvoker)(() => listViewLog.Items.Add(_LvItem)));
            if (listViewLog.Items.Count >= maximumLogs)
            {
                listViewLog.Invoke((MethodInvoker)(() => listViewLog.Items.RemoveAt(0)));
            }
            exportLogs("[" + logsNum + "] " + _sClock + ", " + "Name : " + _Name + ", " + _LogContents + ", " + "Message Status : " + _MessageStatus + ", " + _ExecTime);
            logsNum++;
        }

        private void sldMultiply_Scroll(object sender, ScrollEventArgs e)
        {
            multiplyValue = sldMultiply.Value;
            multiplyValue = multiplyValue / 10;
        }

        private void sldBlur_Scroll(object sender, ScrollEventArgs e)
        {
            blurValue = sldBlur.Value;
            if (blurValue % 2 == 0)
            {
                blurValue++;
            }
        }

        private void checkSamePerson_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSamePerson.Checked == true)
            {
                samePersonDetectionEnabled = true;
                faceBefore = null;
            }
            else
            {
                samePersonDetectionEnabled = false;
            }
        }

        private void checkSendMessage_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSendMessage.Checked == true)
            {
                sendMessageEnabled = true;
            } 
            else
            {
                sendMessageEnabled = false;
            } 
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            sqlLibrary _sqlLibrary = new sqlLibrary();
            _sqlLibrary.initializeDatabase();
            MessageBox.Show(_sqlLibrary.testConnection(), "Database Connection Test");
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            FormAbout _formAbout = new FormAbout();
            _formAbout.Show();
        }

        void exportLogs(String logLine)
        {
            File.AppendAllText(logFileName, logLine + Environment.NewLine);
        }

        void createPresence()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)app.ActiveSheet;
                app.Visible = false;
                ws.Cells[1, 1] = "Employee Name";
                ws.Cells[1, 2] = "Time";
                Int32 sheetRow = 2;
                foreach (ListViewItem item in getListViewItems(listViewLog))
                {
                    ws.Cells[sheetRow, 1] = item.SubItems[2].Text;
                    ws.Cells[sheetRow, 2] = item.SubItems[1].Text;
                    sheetRow++;
                }
                ws.Columns.AutoFit();
                Microsoft.Office.Interop.Excel.Range tHeader = (Microsoft.Office.Interop.Excel.Range)ws.Rows[1];
                tHeader.Font.Bold = true;
                wb.SaveAs(appExecTime + ".xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                app.Quit();
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
            }
        }

        private delegate ListView.ListViewItemCollection GetItems(ListView lstview);
        private ListView.ListViewItemCollection getListViewItems(ListView lstview)
        {
            ListView.ListViewItemCollection temp = new ListView.ListViewItemCollection(new ListView());
            if (!lstview.InvokeRequired)
            {
                foreach (ListViewItem item in lstview.Items)
                    temp.Add((ListViewItem)item.Clone());
                return temp;
            }
            else
                return (ListView.ListViewItemCollection)this.Invoke(new GetItems(getListViewItems), new object[] { lstview });
        }

        private void btnExportPresence_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => {
                createPresence();
            });
        }
    }
}
