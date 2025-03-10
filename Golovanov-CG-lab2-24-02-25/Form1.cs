using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Golovanov_CG_lab2_24_02_25
{
    public partial class Form1 : Form
    {
        Stack<Bitmap> bitmapStack = new Stack<Bitmap>();
        Bitmap image;
        int sepiaCoeff, brightnessCoeff, rotateAngle, motionBlurrN, segmentSize;
        Segment mode;
        AxisMode axisMode;
        bool haveBackup = false, isBusy = false;
        public Form1()
        {
            InitializeComponent();
            sepiaCoeff = 30;
            brightnessCoeff = 30;
            rotateAngle = 45;
            axisComboBox.SelectedIndex = 0;
            axisMode = 0;
            segmentComboBox.SelectedIndex = 0;
            mode = 0;
            segmentSize = 3;
        }
       public void CheckBusy()
        {
            menuStrip1.Enabled = isBusy;
            isBusy = !isBusy;
        }
        private void SetBackup()
        {
            bitmapStack.Push(image);
            //backupImage = image;
            haveBackup = true;
        }
        private void CheckBackUp()
        {
            haveBackup = bitmapStack.Count != 0;
            button2.Enabled = haveBackup;
        }
        private void GetBackup()
        {
            image = bitmapStack.Pop();
            //image = backupImage;
            pictureBox1.Image = image;
            pictureBox1.Refresh();
            CheckBackUp();
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image files | *.png; *.jpg; *.bmp | All files (*.*) | *.*";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(opf.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
                фильтрыToolStripMenuItem.Enabled = true;
                серыйМирToolStripMenuItem.Enabled = true;
                cохранитьToolStripMenuItem.Enabled = true;
                морфлингиToolStripMenuItem.Enabled = true;
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SetBackup();
            Bitmap newImage = ((Filter)e.Argument).ProcessImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
            {
                image = newImage;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
                CheckBackUp();
            }
            CheckBusy();
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync (filter);
        }

        private void гауссToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void чБToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Sepia(sepiaCoeff);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Brightness(brightnessCoeff);
            backgroundWorker1.RunWorkerAsync(filter);
        }


        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Sharpness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new RotateFilter(rotateAngle);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Waves();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void размытиеВДвиженииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new MotionBlur(motionBlurrN);
            backgroundWorker1.RunWorkerAsync(filter);
        }


        private void осьXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Prewitt();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void осьXToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Sobel();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetBackup();
        }

        private void cохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(saveFileDialog.FileName);
                }
            }
            else { MessageBox.Show("Error"); }
        }

        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new GaryWorld();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        
        private void осьYToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Sobel();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void медианныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Sobel();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void линейнаяКоррекцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new LinearStretch();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sepiaNumeric_ValueChanged(object sender, EventArgs e)
        {
            sepiaCoeff = (int)sepiaNumeric.Value;
        }

        private void rotateAngleNumeric_ValueChanged(object sender, EventArgs e)
        {
            rotateAngle = (int)rotateAngleNumeric.Value;
        }

        private void brightnessNumeric_ValueChanged(object sender, EventArgs e)
        {
            brightnessCoeff = (int)brightnessNumeric.Value;
        }

        private void motionBlurrNumeric_ValueChanged(object sender, EventArgs e)
        {
            motionBlurrN = (int)motionBlurrNumeric.Value;
        }

        private void axisComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            axisMode = (AxisMode)axisComboBox.SelectedIndex;
        }

        private void segmentSizeNumeric_ValueChanged(object sender, EventArgs e)
        {
            segmentSize = (int)segmentSizeNumeric.Value;
        }

        private void segmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = (Segment)segmentComboBox.SelectedIndex;
        }

        private void собельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Sobel();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void операторПрюитаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Prewitt();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Glass();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void щаарToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Sharr();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Embossing();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void заданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new CrossFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void открытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Opening(mode, segmentSize);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void закрытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Closing(mode, segmentSize);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void далатацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Dilation(mode, segmentSize);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void эрозияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new Erosion(mode, segmentSize);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBusy();
            Filter filter = new TopHat(mode, segmentSize);
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
