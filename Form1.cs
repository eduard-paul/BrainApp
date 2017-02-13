using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;


// для работы с библиотекой OpenGL 
using Tao.OpenGl;
// для работы с библиотекой FreeGLUT 
using Tao.FreeGlut;
// для работы с элементом управления SimpleOpenGLControl 
using Tao.Platform.Windows;

namespace BrainApp
{
    public partial class Form1 : Form
    {
        short[] space;
        Model model;
        int[] size = new int[3];
        double[] spacing = new double[3];

        int showSliceNum = 0;
        Bitmap sliceImg;
        short minValue, maxValue;

        ArrayList rayCenters = new ArrayList();

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "0.0"; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // инициализация Glut 
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGBA | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH | Glut.GLUT_MULTISAMPLE);

            // отчитка окна 
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            // настройка параметров OpenGL для визуализации 
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glClearDepth(1.0f);

            Gl.glEnable(Gl.GL_LIGHTING); // здесь включается расчет освещения 
            Gl.glLightModelf(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_TRUE); // делаем так, чтобы освещались обе стороны полигона
            Gl.glEnable(Gl.GL_NORMALIZE); //делам нормали одинаковой величины во избежание 
        }

        void InitL()
        {
            const float coef = 0.45F;
            float[] light0_diffuse = { coef * 255.0f / 255, coef * 203.0f / 255, coef * 187.0f / 255 }; // устанавливаем диффузный цвет света 
            float[] light0_direction = { 0.2F, -1.0F, 1.0F, 0.0f }; // устанавливаем направление света
            float[] light1_direction = { 0.0F, 1.0F, 1.0F, 0.0F }; // устанавливаем направление света
            float[] light2_direction = { -1.0F, 0.0F, 1.0F, 0.0F }; // устанавливаем направление света
            float[] light3_direction = { -1.0F, 0.0F, 1.0F, 0.0F }; // устанавливаем направление света

            Gl.glEnable(Gl.GL_LIGHT0); // разрешаем использовать light0
            Gl.glEnable(Gl.GL_LIGHT1);
            Gl.glEnable(Gl.GL_LIGHT2);

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_diffuse); // устанавливаем источнику света light0 диффузный свет, который указали ранее 
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_direction); // устанавливаем направление источника света, указанное ранее 
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light1_direction);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, light2_direction);
        }

        double x = 25, y = 22, z = -25; //Положение камеры в пространстве 
        float angleX = -225, angleY = -3; // Углы поворота камеры
        private void RedrawGl()
        {
            if (model == null)
            {
                return;
            }
            Gl.glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            // очистка Экрана и буфера глубины
            Gl.glLoadIdentity();
            // Сброс просмотра

            InitL();

            const float height = 0; //Высота персонажа, тут нуль, дабы смещения не происходило.
            //Glu.gluLookAt(x, y + height, z, x - Math.Sin(angleX / 180 * Math.PI),
            //    y + height + (Math.Tan(angleY / 180 * Math.PI)), z - Math.Cos(angleX / 180 * Math.PI), 0, 1, 0);
            Glu.gluLookAt(x, y + height, z, 10.3,10.3,-10.3, 0, 1, 0);

            for (int i = 0; i < model.parts.Count; i++)
            {
                drawGl(((SectModel)model.parts[i]).v, size, spacing);
            }


            Gl.glDisable(Gl.GL_LIGHT0);
            Gl.glDisable(Gl.GL_LIGHT1);

            AnT.Refresh();
        }

        void drawGl(ArrayList model, int[] size, double[] spacing)
        {
            int sizeXY = model.Count;
            for (int j = 0; j < ((ArrayList)model[0]).Count - 1; j++)
            {
                for (int i = 0; i < model.Count - 1; i++)
                {

                    float x1 = (float)(((Point3D)((ArrayList)model[i])[j]).x * spacing[0] / 10);
                    float y1 = (float)(((Point3D)((ArrayList)model[i])[j]).y * spacing[1] / 10);
                    float z1 = (float)(((Point3D)((ArrayList)model[i])[j]).z * spacing[2] / 10);

                    float x2 = (float)(((Point3D)((ArrayList)model[(i + 1) % sizeXY])[j + 1]).x * spacing[0] / 10);
                    float y2 = (float)(((Point3D)((ArrayList)model[(i + 1) % sizeXY])[j + 1]).y * spacing[1] / 10);
                    float z2 = (float)(((Point3D)((ArrayList)model[(i + 1) % sizeXY])[j + 1]).z * spacing[2] / 10);

                    float x3 = (float)(((Point3D)((ArrayList)model[i])[j + 1]).x * spacing[0] / 10);
                    float y3 = (float)(((Point3D)((ArrayList)model[i])[j + 1]).y * spacing[1] / 10);
                    float z3 = (float)(((Point3D)((ArrayList)model[i])[j + 1]).z * spacing[2] / 10);

                    float x4 = (float)(((Point3D)((ArrayList)model[(i + 1) % sizeXY])[j]).x * spacing[0] / 10);
                    float y4 = (float)(((Point3D)((ArrayList)model[(i + 1) % sizeXY])[j]).y * spacing[1] / 10);
                    float z4 = (float)(((Point3D)((ArrayList)model[(i + 1) % sizeXY])[j]).z * spacing[2] / 10);

                    float n1x = x2 - x1;
                    float n1y = y2 - y1;
                    float n1z = z2 - z1;
                    float n2x = x3 - x1;
                    float n2y = y3 - y1;
                    float n2z = z3 - z1;
                    Gl.glNormal3f((n1y * n2z - n1z * n2y), (n1z * n2x - n1x * n2z), (n1x * n2y - n1y * n2x));

                    Gl.glBegin(Gl.GL_TRIANGLES);
                    Gl.glColor3f(255.0f / 255, 203.0f / 255, 187.0f / 255);
                    Gl.glVertex3f(x1, z1, -y1);  // Вверх
                    Gl.glColor3f(255.0f / 255, 126.0f / 255, 87.0f / 255);
                    Gl.glVertex3f(x2, z2, -y2);  // Слева снизу
                    Gl.glColor3f(255.0f / 255, 140.0f / 255, 105.0f / 255);
                    Gl.glVertex3f(x3, z3, -y3);  // Справа снизу
                    Gl.glEnd();

                    n2x = x4 - x1;
                    n2y = y4 - y1;
                    n2z = z4 - z1;
                    Gl.glNormal3f((n1y * n2z - n1z * n2y), (n1z * n2x - n1x * n2z), (n1x * n2y - n1y * n2x));

                    Gl.glBegin(Gl.GL_TRIANGLES);
                    Gl.glColor3f(255.0f / 255, 203.0f / 255, 187.0f / 255);
                    Gl.glVertex3f(x1, z1, -y1);  // Вверх
                    Gl.glColor3f(255.0f / 255, 126.0f / 255, 87.0f / 255);
                    Gl.glVertex3f(x2, z2, -y2);  // Слева снизу
                    Gl.glColor3f(255.0f / 255, 140.0f / 255, 105.0f / 255);
                    Gl.glVertex3f(x4, z4, -y4);  // Справа снизу
                    Gl.glEnd();
                }
            }
        }

        String dataFile = "data.dat";

        private void LoadData()
        {
            if (!File.Exists(dataFile))
            {
                Console.WriteLine("No such file");
                Application.Exit();
            }
            else
            {
                using (var filestream = File.Open(dataFile, FileMode.Open))
                using (var binaryStream = new BinaryReader(filestream))
                {
                    var len = filestream.Length;
                    var count = (len - (3 * sizeof(int) + 3 * sizeof(double))) / sizeof(short);
                    space = new short[count];

                    for (int i = 0; i < 3; i++)
                    {
                        size[i] = binaryStream.ReadInt32();
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        spacing[i] = binaryStream.ReadDouble();
                    }
                    for (int i = 0; i < count; i++)
                    {
                        space[i] = binaryStream.ReadInt16();
                    }
                }
                minValue = space.Min<short>();
                maxValue = space.Max<short>();

                tbMinVal.Minimum = minValue;
                tbMinVal.Maximum = maxValue;
                tbMinVal.Value = minValue;

                tbSliceNum.Value = tbSliceNum.Maximum = showSliceNum = size[2] - 1;
                tbSliceNum.Minimum = 0;

                sliceImg = new Bitmap(size[0], size[1]);
                pictureBox1.Image = sliceImg;
                redrawSlice();

                rayCenters.Add(new Point3D(size[0] / 2, size[1] / 2, size[2] / 2));
            }
        }

        private void build()
        {
            model = new Model();
            model.thresholdUp = Int32.Parse(tbTOUp.Text);
            model.thresholdDown = Int32.Parse(tbTODown.Text);

            model.rayType = rbThreshold.Checked ? 0 : 1;
            if (rbGrad.Checked)
            {
                model.gradient = Double.Parse(tbGradient.Text);
            }

            foreach (Point3D p in rayCenters)
            {
                model.rayTracing(ref space, ref size, ref spacing, p.x, p.y, p.z,
                    (int)Int32.Parse(tbRayNum1.Text), (int)Int32.Parse(tbRayNum2.Text));
            }
            if (cbCR.Checked)
            {
                model.verticalSmoothing((int)Int32.Parse(tbCRRange.Text), Double.Parse(tbCRSpeed.Text));
            }
            if (cbGrad.Checked)
            {
                model.smoothing(Double.Parse(tbGradThr.Text));
            }
            RedrawGl();
        }

        private void btnBuld_Click(object sender, EventArgs e)
        {
            build();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        double d = 20;
        int downX, downY;
        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) != 0) {
                Cursor = new Cursor(Cursor.Current.Handle);

                angleX += (downX - Cursor.Position.X) / 4.0f; //4 — чувствительность 
                angleY -= (downY - Cursor.Position.Y) / 4.0f;

                recalcPosition();

                Cursor.Position = new Point(downX , downY );

                if (angleY < -89.0) { angleY = -89.0f; }
                if (angleY > 89.0) { angleY = 89.0f; }

                if (model != null)
                {                    
                    RedrawGl();
                }
            }
        }

        private void recalcPosition()
        {
            x =  10.3 + Math.Cos((angleX)       / 180 * Math.PI) * d * Math.Sin((angleY - 90) / 180 * Math.PI);
            z = -10.3 - Math.Sin((angleX)       / 180 * Math.PI) * d * Math.Sin((angleY - 90) / 180 * Math.PI);
            y =  10.3 + Math.Cos((angleY - 100) / 180 * Math.PI) * d;
        }

        private void AnT_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor = new Cursor(Cursor.Current.Handle);
            downX = Cursor.Position.X;
            downY = Cursor.Position.Y;
        }

        void AnTMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                d--;
            else
                d++;
            recalcPosition();
            RedrawGl();
        }

        private void tbMinVal_Scroll(object sender, EventArgs e)
        {
            minValue = (short)tbMinVal.Value;
            redrawSlice();
        }

        private void redrawSlice()
        {
            if (space == null) return;
            Color col; short colValue;
            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    colValue = space[showSliceNum * size[0] * size[1] + i * size[1] + j];
                    colValue = (short)(255 * (colValue - minValue) / (maxValue - minValue));
                    colValue = colValue > 0 ? colValue : (short)0;
                    col = Color.FromArgb(colValue, colValue, colValue);
                    sliceImg.SetPixel(i, j, col);
                }
            }
            pictureBox1.Refresh();
        }

        void sliceMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                showSliceNum = showSliceNum < size[2] - 1 ? showSliceNum + 1 : showSliceNum;
            else
                showSliceNum = showSliceNum > 0 ? showSliceNum - 1 : showSliceNum;
            tbSliceNum.Value = showSliceNum;
            lblZ.Text = showSliceNum.ToString();
            lblVal.Text = space[showSliceNum * size[0] * size[1] + e.X * size[1] + e.Y].ToString();
            redrawSlice();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
        }

        private void AnT_MouseClick(object sender, MouseEventArgs e)
        {
            AnT.Focus();
        }

        private void tbSliceNum_Scroll(object sender, EventArgs e)
        {
            showSliceNum = tbSliceNum.Value;
            lblZ.Text = showSliceNum.ToString();
            redrawSlice();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (space != null)
            {
                lblX.Text = e.X.ToString();
                lblY.Text = e.Y.ToString();

                if (e.X < size[0] && e.Y < size[1])
                {
                    lblVal.Text = space[showSliceNum * size[0] * size[1] + e.X * size[1] + e.Y].ToString();
                }


            }
        }

        private void tbCRRange_MouseHover(object sender, EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;  //in milliseconds

            ToolTip tt = new ToolTip();

            if (TB.Equals(tbCRRange))
                tt.Show("Range", TB, TB.Width, 0, VisibleTime);
            if (TB.Equals(tbCRSpeed))
                tt.Show("Speed", TB, TB.Width, 0, VisibleTime);
            if (TB.Equals(tbTOUp))
                tt.Show("Upper", TB, TB.Width, 0, VisibleTime);
            if (TB.Equals(tbTODown))
                tt.Show("Down", TB, TB.Width, 0, VisibleTime);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Свой тип (*.dat) | *.dat";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dataFile = dialog.FileName;
            }
        }

        private void optioanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options = new Options(ref rayCenters);
            options.TopMost = true;
            options.ShowDialog();
        }

        private void cbGrad_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGrad.Checked)
            {
                model.smoothing(Double.Parse(tbGradThr.Text));
                RedrawGl();
            }
            else build();
        }

        private void cbCR_CheckedChanged(object sender, EventArgs e)
        {
            build();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int X = e.Y, Y = e.X, Z = showSliceNum;


            int rayNum = 500;
            double angle1 = 0;
            double angleStep1 = 2*Math.PI / rayNum;

            int thrUp = Int32.Parse(tbTOUp.Text);
            int thrDown = Int32.Parse(tbTODown.Text);
            int gr = Int32.Parse(tbGradient.Text);

            for (int i = 0; i < rayNum; i++)
            {
                angle1 = i * angleStep1;

                double x1 = Math.Cos(angle1);
                double y1 = Math.Sin(angle1);
                double max = Math.Max(Math.Abs(x1), Math.Abs(y1));
                x1 /= max; y1 /= max;

                ArrayList ray = new ArrayList();
                double x = X, y = Y, z = Z;
                while ((x < size[0] && x > 0) && (y < size[1] && y > 0) && (z < size[2] && z > 0))
                {
                    Point3D p = new Point3D((int)x, (int)y, (int)z, space[(int)(z) * size[0] * size[1] + (int)(y) * size[0] + (int)(x)]);
                    if (rbThreshold.Checked)
                    {
                        sliceImg.SetPixel((int)y, (int)x, Color.White);
                        if (p.val > thrUp || p.val < thrDown)
                        {
                            break;
                        }
                    }
                    ray.Add(p);
                    x += x1; y += y1;
                }
                if (rbGrad.Checked)
                {
                    for (int k = 1; k < ray.Count - 1; k++)
                    {
                        double g = Math.Abs(2*((Point3D)ray[k + 1]).val - 2*((Point3D)ray[k - 1]).val);
                        if (g > gr)
                        {
                            break;
                        }
                        sliceImg.SetPixel(((Point3D)ray[k]).y, ((Point3D)ray[k]).x, Color.White);
                    }
                }
            }
            pictureBox1.Refresh();
        }

        private void viewThrowThresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int z = showSliceNum;
            int down = Int32.Parse(tbTODown.Text);
            int up = Int32.Parse(tbTOUp.Text);

            unsafe
            {
                Bitmap b = sliceImg; //note this has several overloads, including a path to an image
                BitmapData bData = b.LockBits(new Rectangle(0, 0, sliceImg.Width, sliceImg.Height),
                    ImageLockMode.ReadWrite, b.PixelFormat);

                byte bitsPerPixel = (byte)Image.GetPixelFormatSize(bData.PixelFormat);
                /*This time we convert the IntPtr to a ptr*/
                byte* scan0 = (byte*)bData.Scan0.ToPointer();
                for (int i = 0; i < size[1]; i++)
                {
                    for (int j = 0; j < size[0]; j++)
                    {
                        byte* data = scan0 + j * bData.Stride + i * bitsPerPixel / 8;

                        short val = space[z * size[0] * size[1] + i * size[0] + j];
                        if (val < down)
                        {
                            data[0] = data[1] = data[2] = 0;
                        }
                        else if (val > up)
                        {
                            data[0] = data[1] = data[2] = 100;
                        }
                        else
                        {
                            data[0] = data[1] = data[2] = 255;
                        }
                    }
                }

                b.UnlockBits(bData);
            }

            pictureBox1.Refresh();
        }

        private double[,] gx = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
        private double[,] gy = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
        private double grad(int x, int y)
        {
            double gradx = 0, grady=0;
            int z = showSliceNum;

            for (int i = x-1; i < x+2; i++)
            {
                for (int j = y-1; j < y+2; j++)
                {
                    gradx += gx[i - (x - 1), j - (y-1)] * space[z * size[0] * size[1] + i * size[0] + j];
                    grady += gy[i - (x - 1), j - (y-1)] * space[z * size[0] * size[1] + i * size[0] + j];
                }
            }
            return Math.Sqrt(gradx*gradx+grady*grady);
        }
        private void showGradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int z = showSliceNum;
            int down = Int32.Parse(tbTODown.Text);
            int up = Int32.Parse(tbTOUp.Text);

            double[] grads = new double[size[1] * size[0]];
            for (int i = 1; i < size[1] - 1; i++)
                {
                    for (int j = 1; j < size[0] - 1; j++)
                    {
                        grads[i*size[0]+j] = grad(i,j);
                    }
            }
            double min = grads.Min();
            double max = grads.Max();

            unsafe
            {
                Bitmap b = sliceImg; //note this has several overloads, including a path to an image
                BitmapData bData = b.LockBits(new Rectangle(0, 0, sliceImg.Width, sliceImg.Height),
                    ImageLockMode.ReadWrite, b.PixelFormat);

                byte bitsPerPixel = (byte)Image.GetPixelFormatSize(bData.PixelFormat);
                /*This time we convert the IntPtr to a ptr*/
                byte* scan0 = (byte*)bData.Scan0.ToPointer();
                for (int i = 1; i < size[1] - 1; i++)
                {
                    for (int j = 1; j < size[0] - 1; j++)
                    {

                        byte* data = scan0 + j * bData.Stride + i * bitsPerPixel / 8;

                        data[0] = data[1] = data[2] = (byte)(255 * (grads[i * size[0] + j] - min) / (max - min));
                    }
                }

                b.UnlockBits(bData);
            }

            pictureBox1.Refresh();
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelChart.Visible = false;
            plottingToolStripMenuItem.CheckState = CheckState.Unchecked;
        }

        private void plottingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelChart.Visible = true;
            mainToolStripMenuItem.CheckState = CheckState.Unchecked;
        }

        int chartPivotX, chartPivotY;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            chartPivotX = e.Y;
            chartPivotY = e.X;
        }

        int dirX, dirY;
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dirX = e.Y; dirY = e.X;

            if (dirX == chartPivotX && dirY == chartPivotY)
            {
                return;
            }
            if (!plottingToolStripMenuItem.Checked)
            {
                return;
            }            

            chart1.ChartAreas[0].AxisY.Maximum = Int32.Parse(txtChartMax.Text);
            chart1.ChartAreas[0].AxisY.Minimum = Int32.Parse(txtChartMin.Text);
            redrawSlice();

            Rectangle r = new Rectangle(Math.Min(chartPivotX, dirX), Math.Min(chartPivotY, dirY), 
                Math.Abs(chartPivotX - dirX) + 1, Math.Abs(chartPivotY - dirY) + 1);

            double gipot = Math.Sqrt((chartPivotX - dirX) * (chartPivotX - dirX) + (chartPivotY - dirY) * (chartPivotY - dirY));

            double x1 = (dirX - chartPivotX) / gipot;
            double y1 = (dirY - chartPivotY) / gipot;
            double max = Math.Max(Math.Abs(x1), Math.Abs(y1));
            x1 /= max; y1 /= max;

            ArrayList ray = new ArrayList();
            double x = chartPivotX, y = chartPivotY, z = showSliceNum;
            while(r.Contains((int)x, (int)y))
            {
                Point3D p = new Point3D((int)x, (int)y, (int)z, space[(int)(z) * size[0] * size[1] + (int)(y) * size[0] + (int)(x)]);
                ray.Add(p);
                sliceImg.SetPixel((int)y, (int)x, Color.Green);
                x += x1; y += y1;
            }

            chart1.Series["Series1"].Points.Clear();            

            if (rbThreshold.Checked)
            {
                foreach (Point3D p in ray)
                {
                    double dist = Math.Sqrt((chartPivotX - p.x) * (chartPivotX - p.x) + (chartPivotY - p.y) * (chartPivotY - p.y));
                    chart1.Series["Series1"].Points.AddXY(dist, p.val);
                }
            }
            if (rbGrad.Checked)
            {
                Point3D p;
                for (int k = 1; k < ray.Count - 1; k++)
                {
                    p = (Point3D)ray[k];
                    double g = Math.Abs(2 * ((Point3D)ray[k + 1]).val - 2 * ((Point3D)ray[k - 1]).val);
                    double dist = Math.Sqrt((chartPivotX - p.x) * (chartPivotX - p.x) + (chartPivotY - p.y) * (chartPivotY - p.y));
                    chart1.Series["Series1"].Points.AddXY(dist, g);
                }
            }
            pictureBox1.Refresh();
        }

        private void txtChartMin_TextChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum = Int32.Parse(txtChartMax.Text);
            chart1.ChartAreas[0].AxisY.Minimum = Int32.Parse(txtChartMin.Text);
        }

        private void btnHist_Click(object sender, EventArgs e)
        {
            chart2.ChartAreas[0].AxisX.Maximum = 260;
            chart2.ChartAreas[0].AxisX.Minimum = -100;

            chart2.Visible = !chart2.Visible;
            long[] hist = model.getHist();
            chart2.BorderWidth = 1;
            chart2.BorderColor = Color.Black;
            for (int s = 0; s < hist.Length; s++)
                chart2.Series["Series1"].Points.AddXY(s + model.histMin, hist[s]);
        }
    }
}
