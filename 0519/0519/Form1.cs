using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSMU_DICOM_LIB;

namespace _0519
{
    public partial class Form1 : Form
    {
        private DICOM_FILEs_Manager dcmFileManager = new DICOM_FILEs_Manager();
        private CSMU_Intensity3D IntensityVolume1 = null;
        private CSMU_Intensity3D IntensityVolume2 = null;
        private int pictureBoxLoadNumber = 0;
        double SpacingBetweenSlices1 = 0;
        double SpacingBetweenSlices2 = 0;
        double realX1 = 249, realY1 = 253, realZ1 = 0, realX2 = 249, realY2 = 253, realZ2 = 0;
        int[] P1ToP2;
        int[] P2ToP1;
        bool picture1IsLarger;
        bool sameStudy = false;
        public Form1()
        {
            InitializeComponent();
            dcmFileManager.collectFilesProgress += new DICOM_FILEs_Manager.CollectFilesProgressHandler(collectFiles_Progress);
            dcmFileManager.collectFilesComplete += new DICOM_FILEs_Manager.CollectFilesCompleteHandler(collectFiles_Complete);
            dcmFileManager.loadDICOMsProgress += new DICOM_FILEs_Manager.LoadDICOMsProgressHandler(loadDICOMsProgress);
            dcmFileManager.loadDICOMsComplete += new DICOM_FILEs_Manager.LoadDICOMsCompleteHandler(loadDICOMsComplete);
        }

        private void folderBtn_Click(object sender, EventArgs e)
        {
            string rootFolder = "";
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if ((result == DialogResult.OK) || (result == DialogResult.Yes))
            {
                rootFolder = folderBrowserDialog1.SelectedPath;
                if (!rootFolder.EndsWith(@"\")) rootFolder = rootFolder + @"\";
                dcmFileManager.CollectFilesInfo(rootFolder);
            }
        }

        private void collectFiles_Progress(int n)
        {
            messageLabel.Text = "檔案數 : " + n;
        }

        private void collectFiles_Complete(int total, int newNum)
        {
            messageLabel.Text = "總檔案數 : " + total + "\n需更新檔案數 : " + newNum;
            dcmFileManager.CollectSeriesInfo();
        }

        private void loadDICOMsProgress(int num, int max)
        {
            messageLabel.Text = "(" + num + "/" + max + ")";
        }

        private void loadDICOMsComplete(int totalNum)
        {
            messageLabel.Text = "總共更新 : " + totalNum + "個檔案資訊";
            patientListBox.Items.Clear();
            studyListBox.Items.Clear();
            seriesListBox.Items.Clear();
            foreach (PatientInfos pinfo in dcmFileManager.AllPatientInfo)
            {
                patientListBox.Items.Add(pinfo.PatientID);
            }
        }

        private void patientListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectPatientID = patientListBox.Items[patientListBox.SelectedIndex].ToString();
            dcmFileManager.SelectPatientID = selectPatientID;
            studyListBox.Items.Clear();
            foreach (StudyInfos stinfo in dcmFileManager.AllStudyID)
            {
                studyListBox.Items.Add(stinfo.StudyID);
            }
            pictureBoxInputBtn1.Enabled = false;
            pictureBoxInputBtn2.Enabled = false;
        }
        private void studyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectStudyID = studyListBox.Items[studyListBox.SelectedIndex].ToString();
            dcmFileManager.SelectedStudyID = selectStudyID;
            seriesListBox.Items.Clear();
            foreach (SeriesInfos sinfo in dcmFileManager.AllSeriesInfo)
            {
                seriesListBox.Items.Add(sinfo.SeriesNumber);
            }
            pictureBoxInputBtn1.Enabled = false;
            pictureBoxInputBtn2.Enabled = false;
            sameStudy = false;
        }

        private void seriesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBoxInputBtn1.Enabled = true;
            pictureBoxInputBtn2.Enabled = true;
        }

        private void pictureBoxInputBtn1_Click(object sender, EventArgs e)
        {
            CSMU_PictureBox1.Enabled = false;
            CSMU_PictureBox2.Enabled = false;
            pictureBoxInputBtn1.Enabled = false;
            pictureBoxInputBtn2.Enabled = false;
            folderBtn.Enabled = false;
            patientListBox.Enabled = false;
            studyListBox.Enabled = false;
            seriesListBox.Enabled = false;
            pictureBoxLoadNumber = 1;
            string selectedSeriesNumber = seriesListBox.Items[seriesListBox.SelectedIndex].ToString();
            dcmFileManager.SelectedSeriesNumber = selectedSeriesNumber;

            messageLabel.Text = "開始載入";
 

            IntensityVolume1 = new CSMU_Intensity3D(dcmFileManager.SelectedSeriesDICOMInfos);
            IntensityVolume1.loadDICOM_ImagesProgress += new CSMU_Intensity3D.LoadDICOM_ImagesProgressHandler(loadDICOMsImageProgress);
            IntensityVolume1.loadDICOM_ImagesComplete += new CSMU_Intensity3D.LoadDICOM_ImagesCompleteHandler(loadDicomImageComplete);
            IntensityVolume1.loadDicomImages();
            CSMU_PictureBox1.IntensityVolume = IntensityVolume1;
        }

        private void pictureBoxInputBtn2_Click(object sender, EventArgs e)
        {
            CSMU_PictureBox1.Enabled = false;
            CSMU_PictureBox2.Enabled = false;
            pictureBoxInputBtn1.Enabled = false;
            pictureBoxInputBtn2.Enabled = false;
            folderBtn.Enabled = false;
            patientListBox.Enabled = false;
            studyListBox.Enabled = false;
            seriesListBox.Enabled = false;
            pictureBoxLoadNumber = 2;
            string selectedSeriesNumber = seriesListBox.Items[seriesListBox.SelectedIndex].ToString();
            dcmFileManager.SelectedSeriesNumber = selectedSeriesNumber;

            messageLabel.Text = "開始載入";

            IntensityVolume2 = new CSMU_Intensity3D(dcmFileManager.SelectedSeriesDICOMInfos);
            IntensityVolume2.loadDICOM_ImagesProgress += new CSMU_Intensity3D.LoadDICOM_ImagesProgressHandler(loadDICOMsImageProgress);
            IntensityVolume2.loadDICOM_ImagesComplete += new CSMU_Intensity3D.LoadDICOM_ImagesCompleteHandler(loadDicomImageComplete);
            IntensityVolume2.loadDicomImages();
            CSMU_PictureBox2.IntensityVolume = IntensityVolume2;
        }
        private void loadDICOMsImageProgress(int nowV, int maxV)
        {
            messageLabel.Text = "Load DICOM Images(" + nowV + "/" + maxV + ")";
        }
        private void loadDicomImageComplete(int num)
        {
            CSMU_PictureBox1.Enabled = true;
            CSMU_PictureBox2.Enabled = true;
            MessageBox.Show($"{IntensityVolume2}");
            if (pictureBoxLoadNumber == 1)
            {
                messageLabel.Text = "Complete!" + IntensityVolume1.Slices +
                          "::" + IntensityVolume1.Rows +
                          "::" + IntensityVolume1.Columns;
                if (IntensityVolume1.currentDicomInfo.SpacingBetweenSlices < 0)
                {
                    SpacingBetweenSlices1 = -IntensityVolume1.currentDicomInfo.SpacingBetweenSlices;
                }
                else
                {
                    SpacingBetweenSlices1 = IntensityVolume1.currentDicomInfo.SpacingBetweenSlices;
                }
                sameStudyOrNot();
                CSMU_PictureBox1.ScrollTo(IntensityVolume1.Slices / 2);
            }
            else if(pictureBoxLoadNumber == 2)
            {
                messageLabel.Text = "Complete!" + IntensityVolume2.Slices +
                          "::" + IntensityVolume2.Rows +
                          "::" + IntensityVolume2.Columns;
                if (IntensityVolume2.currentDicomInfo.SpacingBetweenSlices < 0)
                {
                    SpacingBetweenSlices2 = -IntensityVolume2.currentDicomInfo.SpacingBetweenSlices;
                }
                else
                {
                    SpacingBetweenSlices2 = IntensityVolume2.currentDicomInfo.SpacingBetweenSlices;
                }
                sameStudyOrNot();
                CSMU_PictureBox2.ScrollTo(IntensityVolume2.Slices / 2);
            }
            pictureBoxInputBtn1.Enabled = true;
            pictureBoxInputBtn2.Enabled = true;
            folderBtn.Enabled = true;
            patientListBox.Enabled = true;
            studyListBox.Enabled = true;
            seriesListBox.Enabled = true;
            /*if (sameStudy == true)
            {
                resizePictureBox_sameStudy();
            }
            else
            {
                resizePictureBox_differentStudy();
            }*/
            resizePictureBox_differentStudy();
            
            pictureBoxLoadNumber = 0;
        }
        /*
        private void resizePictureBox_sameStudy()
        {
            double r1 = 0, r2 = 0, r = 0;
            int vw = imagePanel1.Width - 18;
            int scw = CSMU_PictureBox1.ScrollBarWidth +
                      CSMU_PictureBox2.ScrollBarWidth +
                      CSMU_PictureBox3.ScrollBarWidth +
                      pictureBoxInputBtn1.Width +
                      pictureBoxInputBtn2.Width +
                      180;
            if (picture1IsLarger == true)
            {
                realX1 = IntensityVolume1.Columns * IntensityVolume1.currentDicomInfo.PixelSpacing;
                realY1 = IntensityVolume1.Rows * IntensityVolume1.currentDicomInfo.PixelSpacing;
                realZ1 = IntensityVolume1.Slices * Math.Abs(IntensityVolume1.currentDicomInfo.SpacingBetweenSlices);

                r1 = (double)(vw - scw) / (double)(realX1 + realX1 + realX1);
                r2 = (double)(imagePanel1.Height - 50) / realY1;
                r = (r1 <= r2) ? r1 : r2;

                CSMU_PictureBox1.Width = (int)(realX1 * r + CSMU_PictureBox1.ScrollBarWidth);
                CSMU_PictureBox1.Height = (int)(realY1 * r);
                CSMU_PictureBox2.Width = (int)(realX1 * r + CSMU_PictureBox1.ScrollBarWidth);
                CSMU_PictureBox2.Height = (int)(realY1 * r);
                CSMU_PictureBox3.Width = (int)(realX1 * r + CSMU_PictureBox1.ScrollBarWidth);
                CSMU_PictureBox3.Height = (int)(realY1 * r);
                CSMU_PictureBox2.IntensityVolume = IntensityVolume1;
                CSMU_PictureBox3.IntensityVolume = IntensityVolume1;
            }
            else
            {
                realX2 = IntensityVolume2.Columns * IntensityVolume2.currentDicomInfo.PixelSpacing;
                realY2 = IntensityVolume2.Rows * IntensityVolume2.currentDicomInfo.PixelSpacing;
                realZ2 = IntensityVolume2.Slices * Math.Abs(IntensityVolume2.currentDicomInfo.SpacingBetweenSlices);

                r1 = (double)(vw - scw) / (double)(realX2 + realX2 + realX2);
                r2 = (double)(imagePanel1.Height - 50) / realY2;
                r = (r1 <= r2) ? r1 : r2;

                CSMU_PictureBox1.Width = (int)(realX2 * r + CSMU_PictureBox1.ScrollBarWidth);
                CSMU_PictureBox1.Height = (int)(realY2 * r);
                CSMU_PictureBox2.Width = CSMU_PictureBox1.Width;
                CSMU_PictureBox2.Height = CSMU_PictureBox1.Height;
                CSMU_PictureBox3.Width = CSMU_PictureBox1.Width;
                CSMU_PictureBox3.Height = CSMU_PictureBox1.Height;
                CSMU_PictureBox1.IntensityVolume = IntensityVolume2;
                CSMU_PictureBox3.IntensityVolume = IntensityVolume2;
            }

            CSMU_PictureBox1.Left = 115;
            pBoxSlicesLabel1.Left = CSMU_PictureBox1.Left + 5;

            pictureBoxInputBtn2.Left = CSMU_PictureBox1.Right + 30;
            CSMU_PictureBox2.Left = CSMU_PictureBox1.Right + 115;
            pBoxSlicesLabel2.Left = CSMU_PictureBox2.Left + 5;

            CSMU_PictureBox3.Visible = true;
            CSMU_PictureBox3.Left = CSMU_PictureBox2.Right + 130;

            CSMU_PictureBox1.Top = 0;
            CSMU_PictureBox2.Top = 0;
            CSMU_PictureBox3.Top = 0;
            pBoxSlicesLabel1.Top = 5;
            pBoxSlicesLabel2.Top = 5;
        }*/

        private void resizePictureBox_differentStudy()
        {
            double r1 = 0,r2=0,r3=0,r=0;
            if (IntensityVolume1 != null)
            {
                realX1 = IntensityVolume1.Columns * IntensityVolume1.currentDicomInfo.PixelSpacing;
                realY1 = IntensityVolume1.Rows * IntensityVolume1.currentDicomInfo.PixelSpacing;
                realZ1 = IntensityVolume1.Slices * Math.Abs(IntensityVolume1.currentDicomInfo.SpacingBetweenSlices);

            }
            if(IntensityVolume2 != null)
            {
                realX2 = IntensityVolume2.Columns * IntensityVolume2.currentDicomInfo.PixelSpacing;
                realY2 = IntensityVolume2.Rows * IntensityVolume2.currentDicomInfo.PixelSpacing;
                realZ2 = IntensityVolume2.Slices * Math.Abs(IntensityVolume2.currentDicomInfo.SpacingBetweenSlices);
            }

            int vw = imagePanel1.Width - 18;
            int scw = CSMU_PictureBox1.ScrollBarWidth +
                      CSMU_PictureBox2.ScrollBarWidth +
                      pictureBoxInputBtn1.Width +
                      pictureBoxInputBtn2.Width +
                      120;

            r1 = (double)(vw - scw) / (double)(realX1 + realX2);
            r2 = (double)(imagePanel1.Height - 50) / realY1;
            r3 = (double)(imagePanel1.Height - 50) / realY2;
            if (r1 <= r2 && r1 <= r3)
            {
                r = r1;
            }else if(r2 < r1 && r2 <= r3)
            {
                r = r2;
            }
            else
            {
                r = r3;
            }
            if (IntensityVolume1 != null)
            {
                CSMU_PictureBox1.Width = (int)(realX1 * r + CSMU_PictureBox1.ScrollBarWidth);
                CSMU_PictureBox1.Height = (int)(realY1 * r);
            }
            if (IntensityVolume2 != null)
            {
                CSMU_PictureBox2.Width = (int)(realX2 * r + CSMU_PictureBox2.ScrollBarWidth);
                CSMU_PictureBox2.Height = (int)(realY2 * r);
            }
            CSMU_PictureBox1.Left = 115;
            pBoxSlicesLabel1.Left = CSMU_PictureBox1.Left + 5;

            pictureBoxInputBtn2.Left = CSMU_PictureBox1.Right + 30;
            CSMU_PictureBox2.Left = CSMU_PictureBox1.Right + 115;
            pBoxSlicesLabel2.Left = CSMU_PictureBox2.Left + 5;

            CSMU_PictureBox1.Top = 0;
            CSMU_PictureBox2.Top = 0;
            pBoxSlicesLabel1.Top = 5;
            pBoxSlicesLabel2.Top = 5;      
        }

        private void LDCTxMDCT()
        {
            
        }
        private void sameStudyOrNot()
        {
            if (IntensityVolume1 != null && IntensityVolume2 != null)
            {
                if (IntensityVolume1.currentDicomInfo.PatientID == IntensityVolume2.currentDicomInfo.PatientID && IntensityVolume1.currentDicomInfo.StudyID == IntensityVolume2.currentDicomInfo.StudyID)
                {
                    if (IntensityVolume1.currentDicomInfo.SliceLocation > IntensityVolume2.currentDicomInfo.SliceLocation)
                    {
                        ZValueInterlocking1();
                        picture1IsLarger = true;
                    }
                    else
                    {
                        ZValueInterlocking2();
                        picture1IsLarger = false;
                    }
                    
                }
            }
        }

        private void ZValueInterlocking1()
        {
            P1ToP2 = new int[IntensityVolume1.Slices];
            P2ToP1 = new int[IntensityVolume2.Slices];
            int j = 0;
            for (int i = 0; i < IntensityVolume1.Slices; i++)
            {
                if (IntensityVolume1.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices1 == IntensityVolume2.currentDicomInfo.SliceLocation - j * SpacingBetweenSlices2 && j < IntensityVolume2.Slices - 1)
                {
                    P1ToP2[i] = j;
                    j++;
                }else if(IntensityVolume1.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices1 > IntensityVolume2.currentDicomInfo.SliceLocation - j * SpacingBetweenSlices2 && j==0)
                {
                    P1ToP2[i] = j;
                }
                else
                {
                    while(IntensityVolume1.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices1 < IntensityVolume2.currentDicomInfo.SliceLocation - j * SpacingBetweenSlices2 && j < IntensityVolume2.Slices - 1)
                    {
                        j++;
                    }
                    if (j > 0)
                    {
                        if (Math.Abs((IntensityVolume2.currentDicomInfo.SliceLocation - j * SpacingBetweenSlices2) - (IntensityVolume1.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices1)) > Math.Abs((IntensityVolume2.currentDicomInfo.SliceLocation - (j-1) * SpacingBetweenSlices2) - (IntensityVolume1.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices1)))
                        {
                            P1ToP2[i] = j-1;
                            j--;
                        }
                        else
                        {
                            P1ToP2[i] = j;
                        }
                    }
                    else
                    {
                        if (Math.Abs((IntensityVolume2.currentDicomInfo.SliceLocation - j * SpacingBetweenSlices2) - (IntensityVolume1.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices1)) > Math.Abs((IntensityVolume2.currentDicomInfo.SliceLocation - (j + 1) * SpacingBetweenSlices2) - (IntensityVolume1.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices1)))
                        {
                            P1ToP2[i] = j + 1;
                        }
                        else
                        {
                            P1ToP2[i] = j;
                        }
                    }
                }
            }

            int k = 0;
            for (int i = 0; i < IntensityVolume1.Slices; i++)
            {
                if (P1ToP2[i] != 0)
                {
                    P2ToP1[0] = i - 1;
                    k = i;
                    break;
                }
            }
            
            for (int i = 0; i < IntensityVolume2.Slices; i++)
            {
                if (IntensityVolume2.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices2 == IntensityVolume1.currentDicomInfo.SliceLocation - k * SpacingBetweenSlices1 && k < IntensityVolume1.Slices - 1)
                {
                    P2ToP1[i] = k;
                    k++;
                }
                else
                {
                    while(IntensityVolume2.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices2 < IntensityVolume1.currentDicomInfo.SliceLocation - k * SpacingBetweenSlices1 && k < IntensityVolume1.Slices - 1)
                    {
                        k++;
                    }
                    if (k > 0)
                    {
                        if (Math.Abs((IntensityVolume1.currentDicomInfo.SliceLocation - k * SpacingBetweenSlices1) - (IntensityVolume2.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices2)) > Math.Abs((IntensityVolume1.currentDicomInfo.SliceLocation - (k - 1) * SpacingBetweenSlices1) - (IntensityVolume2.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices2)))
                        {
                            P2ToP1[i] = k - 1;
                            k--;
                        }
                        else
                        {
                            P2ToP1[i] = k;
                        }
                    }
                    else
                    {
                        if (Math.Abs((IntensityVolume1.currentDicomInfo.SliceLocation - k * SpacingBetweenSlices1) - (IntensityVolume2.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices2)) > Math.Abs((IntensityVolume1.currentDicomInfo.SliceLocation - (k + 1) * SpacingBetweenSlices1) - (IntensityVolume2.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices2)))
                        {
                            P2ToP1[i] = k + 1;
                        }
                        else
                        {
                            P2ToP1[i] = k;
                        }
                    }
                }
            }
            sameStudy = true;
        }

        private void ZValueInterlocking2()
        {
            P2ToP1 = new int[IntensityVolume2.Slices];
            P1ToP2 = new int[IntensityVolume1.Slices];
            int j = 0;
            for (int i = 0; i < IntensityVolume2.Slices; i++)
            {
                if (IntensityVolume2.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices2 == IntensityVolume1.currentDicomInfo.SliceLocation - j * SpacingBetweenSlices1 && j < IntensityVolume1.Slices - 1)
                {
                    P2ToP1[i] = j;
                    j++;
                }
                else if (IntensityVolume2.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices2 > IntensityVolume1.currentDicomInfo.SliceLocation - j * SpacingBetweenSlices1 && j == 0)
                {
                    P2ToP1[i] = j;
                }
                else
                {
                    while (IntensityVolume2.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices2 < IntensityVolume1.currentDicomInfo.SliceLocation - j * SpacingBetweenSlices1 && j < IntensityVolume1.Slices - 1)
                    {
                        j++;
                    }
                    if (j > 0)
                    {
                        if (Math.Abs((IntensityVolume1.currentDicomInfo.SliceLocation - j * SpacingBetweenSlices1) - (IntensityVolume2.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices2)) > Math.Abs((IntensityVolume1.currentDicomInfo.SliceLocation - (j - 1) * SpacingBetweenSlices1) - (IntensityVolume2.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices2)))
                        {
                            P2ToP1[i] = j - 1;
                            j--;
                        }
                        else
                        {
                            P2ToP1[i] = j;
                        }
                    }
                    else
                    {
                        if (Math.Abs((IntensityVolume1.currentDicomInfo.SliceLocation - j * SpacingBetweenSlices1) - (IntensityVolume2.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices2)) > Math.Abs((IntensityVolume1.currentDicomInfo.SliceLocation - (j + 1) * SpacingBetweenSlices1) - (IntensityVolume2.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices2)))
                        {
                            P2ToP1[i] = j + 1;
                        }
                        else
                        {
                            P2ToP1[i] = j;
                        }
                    }
                }
            }

            int k = 0;
            for (int i = 0; i < IntensityVolume2.Slices; i++)
            {
                if (P2ToP1[i] != 0)
                {
                    P1ToP2[0] = i - 1;
                    k = i;
                    break;
                }
            }

            for (int i = 0; i < IntensityVolume1.Slices; i++)
            {
                if (IntensityVolume1.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices1 == IntensityVolume2.currentDicomInfo.SliceLocation - k * SpacingBetweenSlices2 && k < IntensityVolume2.Slices - 1)
                {
                    P1ToP2[i] = k;
                    k++;
                }
                else
                {
                    while (IntensityVolume1.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices1 < IntensityVolume2.currentDicomInfo.SliceLocation - k * SpacingBetweenSlices2 && k < IntensityVolume2.Slices - 1)
                    {
                        k++;
                    }
                    if (k > 0)
                    {
                        if (Math.Abs((IntensityVolume2.currentDicomInfo.SliceLocation - k * SpacingBetweenSlices2) - (IntensityVolume1.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices1)) > Math.Abs((IntensityVolume2.currentDicomInfo.SliceLocation - (k - 1) * SpacingBetweenSlices2) - (IntensityVolume1.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices1)))
                        {
                            P1ToP2[i] = k - 1;
                            k--;
                        }
                        else
                        {
                            P1ToP2[i] = k;
                        }
                    }
                    else
                    {
                        if (Math.Abs((IntensityVolume2.currentDicomInfo.SliceLocation - k * SpacingBetweenSlices2) - (IntensityVolume1.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices1)) > Math.Abs((IntensityVolume2.currentDicomInfo.SliceLocation - (k + 1) * SpacingBetweenSlices2) - (IntensityVolume1.currentDicomInfo.SliceLocation - i * SpacingBetweenSlices1)))
                        {
                            P1ToP2[i] = k + 1;
                        }
                        else
                        {
                            P1ToP2[i] = k;
                        }
                    }
                }
            }
            sameStudy = true;
        }
        private void CSMU_PictureBox1_onScrollBarValueChanged(int value, int max)
        {
            double location1 = (IntensityVolume1.currentDicomInfo.SliceLocation - value * SpacingBetweenSlices1) * 10 - 0.5;
            int Location1 = (int)location1;
            location1 = (double)Location1 / 10;
            
            pBoxSlicesLabel1.Text = $"{value + 1}/{IntensityVolume1.Slices}\nLocation : {location1}";
            if (sameStudy == true && SpacingBetweenSlices2 != 0)
            {
                double location2 = (IntensityVolume2.currentDicomInfo.SliceLocation - P1ToP2[value] * SpacingBetweenSlices2) * 10 - 0.5;
                int Location2 = (int)location2;
                location2 = (double)Location2 /10;

                pBoxSlicesLabel2.Text = $"{P1ToP2[value] + 1}/{IntensityVolume2.Slices}\nLocation : {location2}";
                CSMU_PictureBox2.ScrollTo(P1ToP2[value]);
            }
        }
        private void CSMU_PictureBox2_onScrollBarValueChanged(int value, int max)
        {
            double location2 = (IntensityVolume2.currentDicomInfo.SliceLocation - value * SpacingBetweenSlices2) * 10 - 0.5;
            int Location2 = (int)location2;
            location2 = (double)Location2 / 10;

            pBoxSlicesLabel2.Text = $"{value + 1}/{IntensityVolume2.Slices}\nLocation : {location2}";
            if (sameStudy == true && SpacingBetweenSlices1 != 0)
            {
                double location1 = (IntensityVolume1.currentDicomInfo.SliceLocation - P2ToP1[value] * SpacingBetweenSlices1) * 10 - 0.5;
                int Location1 = (int)location1;
                location1 = (double)Location1 / 10;

                pBoxSlicesLabel1.Text = $"{P2ToP1[value] + 1}/{IntensityVolume1.Slices}\nLocation : {location1}";
                CSMU_PictureBox1.ScrollTo(P2ToP1[value]);
            }
        }
    }
}
