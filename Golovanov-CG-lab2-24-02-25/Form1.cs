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
        bool haveBackup = false;
        public Form1()
        {
            InitializeComponent();
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
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync (filter);
        }

        private void гауссToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void чБToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Sepia(30);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Brightness(30);
            backgroundWorker1.RunWorkerAsync(filter);
        }


        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Sharpness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new RotateFilter(45);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Waves();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void размытиеВДвиженииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new MotionBlur(11);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void осьYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Prewitt(AxisMode.AxisY);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void осьXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Prewitt(AxisMode.AxisX);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void осьXToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filter filter = new Sobel(AxisMode.AxisX);
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
            Filter filter = new GaryWorld();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        
        private void осьYToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filter filter = new Sobel(AxisMode.AxisY);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void медианныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new Sobel(AxisMode.AxisY);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void линейнаяКоррекцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter filter = new LinearStretch();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
