using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using Auxiliary.Graphics;
using Auxiliary.VectorMath;

// для работы с библиотекой OpenGL 
using Tao.OpenGl;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BrainApp
{
    class Point3D
    {
        public short val;
        public int x, y, z;
        public double dist;
        public Point3D(int _x, int _y, int _z, short _val = 0, double _dist=0)
        {
            x = _x; y = _y; z = _z; val = _val; dist = _dist;
        }
        public Point3D() { }
        public override string ToString()
        {
            return x.ToString() + " " + y.ToString() + " " + z.ToString();
        }
        public Point3D(String s)
        {
            String[] s1 = s.Split(' ');
            x = Int32.Parse(s1[0]);
            y = Int32.Parse(s1[1]);
            z = Int32.Parse(s1[2]);
        }
    };

    class AngleRange
    {
        public double xy_start, xy_end;
        public double xz_start, xz_end;
        public AngleRange()
        {
            xy_start = 0; xy_end = 0;
            xz_start = 0; xz_end = 0;
        }
        public AngleRange(double xy_s, double xy_e, double xz_s, double xz_e)
        {
            xy_start = xy_s; xy_end = xy_e;
            xz_start = xz_s; xz_end = xz_e;
        }
    };

    class SectModel
    {
        public ArrayList v = new ArrayList();

        public float[] vv;
        public int rayNum_xy, rayNum_xz;
        public void setRayNum(int rayNum_xy, int rayNum_xz)
        {
            this.rayNum_xy = rayNum_xy;
            this.rayNum_xz = rayNum_xz;
        }

        public AngleRange sect = new AngleRange();
        public double startX, startY, startZ;
        public void setCenter(double x, double y, double z)
        {
            startX = x;
            startY = y;
            startZ = z;
        }
        public SectModel()
        {
            sect.xy_start = 0;
            sect.xy_end = 2 * Math.PI;
            sect.xz_start = 0;
            sect.xz_end = Math.PI;
        }
        public void setAngleRange(double xy_s, double xy_e, double xz_s, double xz_e)
        {
            sect.xy_start = xy_s;
            sect.xy_end = xy_e;
            sect.xz_start = xz_s;
            sect.xz_end = xz_e;
        }
        public void setDefaultAngleRange()
        {
            sect.xy_start = -Math.PI;
            sect.xy_end = Math.PI;
            sect.xz_start = 0;
            sect.xz_end = Math.PI;
        }
    };

    class Model
    {
        public ArrayList parts = new ArrayList();

        public int thresholdUp = 500;
        public int thresholdDown = -100;

        private short[] space;
        private int[] size;
        private double[] spacing;

        public int rayType = 0;
        public double gradient = 200;

        private long[] hist = new long[4096];
        public short histMin = -2048;

        public long[] getHist()
        {
            //short min = (short)histList[0];
            //short max = (short)histList[0];
            //for (int i = 0; i < histList.Count; i++)
            //{
            //    if ((short)histList[i] < min) min = (short)histList[i];
            //    if ((short)histList[i] > max) max = (short)histList[i];
            //}

            //hist = new short[max - min + 1];
            //for (int i = 0; i < max - min + 1; i++)
            //{
            //    hist[i] = 0;
            //}
            //for (int i = 0; i < histList.Count; i++)
            //{
            //    hist[(short)histList[i] - min]++;
            //}

            return hist;
        }

        public Point3D rayHandler(ref ArrayList ray, double throldUp, double throldDown, double gr)
        {
            if (rayType == 0)
            {
                for (int i = 0; i < ray.Count; i++)
                {
                    if (((Point3D)ray[i]).val < throldDown || ((Point3D)ray[i]).val > throldUp)
                    {
                        return i == 0 ? ((Point3D)ray[0]) : ((Point3D)ray[i - 1]);
                    }
                    hist[((Point3D)ray[i]).val + 2048]++;
                }
            }
            else
            {
                for (int i = 1; i < ray.Count - 1; i++)
                {
                    double g = Math.Abs(2 * ((Point3D)ray[i + 1]).val - 2 * ((Point3D)ray[i - 1]).val);
                    if (g > gr)
                    {
                        return i == 0 ? ((Point3D)ray[0]) : ((Point3D)ray[i - 1]);
                    }
                }
            }
            return ((Point3D)ray[ray.Count - 1]);
        }

        public ArrayList fillRay(double angle1, double angle2, double X, double Y, double Z)
        {
            double x1 = Math.Cos(angle1) * Math.Sin(angle2);
            double y1 = Math.Sin(angle1) * Math.Sin(angle2);
            double z1 = Math.Cos(angle2) * spacing[0] / spacing[2];
            double max = Math.Max(Math.Abs(x1), Math.Max(Math.Abs(y1), Math.Abs(z1)));
            x1 /= max; y1 /= max; z1 /= max;

            ArrayList ray = new ArrayList();
            double x = X, y = Y, z = Z;
            while ((x < size[0] && x > 0) && (y < size[1] && y > 0) && (z < size[2] && z > 0))
            {
                Point3D p = new Point3D((int)x, (int)y, (int)z, space[(int)(z) * size[0] * size[1] + (int)(y) * size[0] + (int)(x)]);
                ray.Add(p);
                x += x1; y += y1; z += z1;
            }

            return ray;
        }

        public void checkRay(ref ArrayList v, double X, double Y, double Z, ref AngleRange sect, double angle1, ref short[] space, ref int[] size, ref double[] spacing,
            int param1 = 1, double param2 = 1.1)
        {
            int rayNum = v.Count - 1;
            double param3 = (thresholdUp - thresholdDown) * 0.01;

            double angle2_step = (sect.xz_end - sect.xz_start) / rayNum;

            for (int i = param1; i < rayNum - param1; i++)
            {
                double distPrev = Math.Sqrt((((Point3D)v[i - param1]).x - X) * (((Point3D)v[i - param1]).x - X) + (((Point3D)v[i - param1]).y - Y) * (((Point3D)v[i - param1]).y - Y)
                                          + (((Point3D)v[i - param1]).z - Z) * (((Point3D)v[i - param1]).z - Z));
                double distNext = Math.Sqrt((((Point3D)v[i + param1]).x - X) * (((Point3D)v[i + param1]).x - X) + (((Point3D)v[i + param1]).y - Y) * (((Point3D)v[i + param1]).y - Y)
                                          + (((Point3D)v[i + param1]).z - Z) * (((Point3D)v[i + param1]).z - Z));
                double dist = Math.Sqrt((((Point3D)v[i]).x - X) * (((Point3D)v[i]).x - X) + (((Point3D)v[i]).y - Y) * (((Point3D)v[i]).y - Y) + (((Point3D)v[i]).z - Z) * (((Point3D)v[i]).z - Z));
                double tmpMax = Math.Max(distPrev, distNext);
                double tmpMin = Math.Min(distPrev, distNext);
                double tmpMid = (tmpMax + tmpMin) / 2;
                if (!(dist < tmpMax && dist > tmpMin) && dist > tmpMid * param2)
                {
                    //if (dist > distPrev*param2) {
                    double angle2 = sect.xz_start + i * angle2_step;
                    ArrayList ray = fillRay(angle1, angle2, X, Y, Z);

                    Point3D p = null;
                    for (int j = 1; !(dist < tmpMax && dist > tmpMin) && dist > tmpMid * param2; j++)
                    {
                        //for (int j = 1; dist > distPrev*param2; j++) {

                        p = rayHandler(ref ray, thresholdUp - j * param3, thresholdDown, gradient - j * gradient * 0.01);
                        dist = Math.Sqrt((p.x - X) * (p.x - X) + (p.y - Y) * (p.y - Y) + (p.z - Z) * (p.z - Z));
                    }
                    p.dist = dist;
                    v[i] = p;

                }
            }
        }

        public void rayTracing(ref short[] _space, ref int[] _size, ref double[] _spacing,
            double startX, double startY, double startZ, int rayNum_xy = 200, int rayNum_xz = 100)
        {
            space = _space;
            size = _size;
            spacing = _spacing;
            SectModel output = new SectModel();
            output.setCenter(startX, startY, startZ);

            output.setRayNum(rayNum_xy, rayNum_xz);

            double angleStep1 = (output.sect.xy_end - output.sect.xy_start) / (rayNum_xy - 1);
            double angleStep2 = (output.sect.xz_end - output.sect.xz_start) / (rayNum_xz - 1);

            output.v = new ArrayList(rayNum_xy);
            ArrayList[] outv = new ArrayList[rayNum_xy];
            Parallel.For(0, rayNum_xy, i =>
            {
                double angle1 = output.sect.xy_start + i * angleStep1;
                double angle2 = output.sect.xz_start;
                ArrayList v = new ArrayList();
                for (int j = 0; j <= rayNum_xz; j++)
                {
                    angle2 = output.sect.xz_start + j * angleStep2;
                    ArrayList ray = fillRay(angle1, angle2, startX, startY, startZ);
                    Point3D p = rayHandler(ref ray, thresholdUp, thresholdDown, gradient);
                    p.dist = Math.Sqrt((p.x - startX) * (p.x - startX) + (p.y - startY) * (p.y - startY) + (p.z - startZ) * (p.z - startZ));
                    v.Add(p);
                }
                outv[i] = v;
            });
            output.v.AddRange(outv);
            parts.Add(output);
        }

        public void rayTracing2(ref short[] _space, ref int[] _size, ref double[] _spacing,
            double startX, double startY, double startZ, int rayNum_xy = 200, int rayNum_xz = 100)
        {

            SectModel output = new SectModel();
            output.setCenter(startX, startY, startZ);

            output.setRayNum(rayNum_xy, rayNum_xz);

            float angleStep1 = (float) (output.sect.xy_end - output.sect.xy_start) / (rayNum_xy - 1);
            float angleStep2 = (float) (output.sect.xz_end - output.sect.xz_start) / (rayNum_xz - 1);

            float xy_start = (float) output.sect.xy_start;
            float xz_start = (float)output.sect.xz_start;

            // Устанавливаем переменные
            renderProgram.SetUniformVector("Size", new Vector3D((float)size[0], (float)size[1], (float)size[2]));
            renderProgram.SetUniformVector("Spacing", new Vector3D((float)spacing[0], (float)spacing[1], (float)spacing[2]));
            renderProgram.SetUniformFloat("angleStep1", angleStep1);
            renderProgram.SetUniformFloat("angleStep2", angleStep2);
            renderProgram.SetUniformFloat("xy_start", xy_start);
            renderProgram.SetUniformFloat("xz_start", xz_start);
            renderProgram.SetUniformFloat("startX", (float) startX);
            renderProgram.SetUniformInteger("thresholdUp", thresholdUp);
            renderProgram.SetUniformInteger("thresholdDown", thresholdDown);
            renderProgram.SetUniformFloat("gradient", (float)gradient);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3f(-1.0f, -1f, 0.0f);
            Gl.glVertex3f(-1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(1.0f, -1.0f, 0.0f);
            Gl.glEnd();

            int chan = 4;
            output.vv = new float[chan * rayNum_xy * rayNum_xz];
            Gl.glGetTexImage(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, Gl.GL_FLOAT, output.vv);
            //parts.Add(output);
        }

        public ArrayList fillRay2(double angle1, double angle2, double X, double Y, double Z)
        {
            double x1 = Math.Cos(angle1) * Math.Sin(angle2);
            double y1 = Math.Sin(angle1) * Math.Sin(angle2);
            double z1 = Math.Cos(angle2) * spacing[0] / spacing[2];
            double max = Math.Max(Math.Abs(x1), Math.Max(Math.Abs(y1), Math.Abs(z1)));
            x1 /= max; y1 /= max; z1 /= max;

            ArrayList ray = new ArrayList();
            double x = X, y = Y, z = Z;
            while ((x < size[0] && x > 0) && (y < size[1] && y > 0) && (z < size[2] && z > 0))
            {
                Point3D p = new Point3D((int)x, (int)y, (int)z, space[(int)(z) * size[0] * size[1] + (int)(y) * size[0] + (int)(x)]);
                ray.Add(p);
                x += x1; y += y1; z += z1;
            }

            return ray;
        }

        public void verticalSmoothing(int crStep = 1, double crSpeed = 1.1)
        {
            Parallel.For(0, parts.Count, num =>
            {
                SectModel sm = (SectModel)parts[num];
                ArrayList v = sm.v;

                double angleStep1 = (sm.sect.xy_end - sm.sect.xy_start) / (v.Count - 1);
                double angleStep2 = (sm.sect.xz_end - sm.sect.xz_start) / (((ArrayList)v[0]).Count - 2);

                for (int i = 1; i < v.Count - 1; i++)
                {
                    double angle1 = sm.sect.xy_start + i * angleStep1;

                    ArrayList vv = (ArrayList)v[i];

                    checkRay(ref vv, sm.startX, sm.startY, sm.startZ, ref sm.sect, angle1, ref space, ref size, ref spacing, crStep + 2, crSpeed);
                    checkRay(ref vv, sm.startX, sm.startY, sm.startZ, ref sm.sect, angle1, ref space, ref size, ref spacing, crStep, crSpeed);
                }

            });
        }

        private class Point3DDistComparer : IComparer
        {
            public int Compare(Object a, Object b)
            {
                Point3D x = (Point3D) a;
                Point3D y = (Point3D) b;
                if (x.dist > y.dist)
                    return 1;
                if (x.dist < y.dist)
                    return -1;
                else
                    return 0;
            }
        }
    
        private double[,] gg = {{-1,-2,-1}, {-2,12,-2}, {-1,-2,-1}};
        private double grad(ref ArrayList v, int longtitude, int latitude, int rad, ref Point3D mm)
        {
            double grad = 0;
            ArrayList m = new ArrayList();
            for (int i = longtitude - rad; i <= longtitude + rad; i++)
            {
                for (int j = latitude - rad; j <= latitude + rad; j++)
                {
                    m.Add(((Point3D)((ArrayList)v[i])[j]));
                    grad += ((Point3D)((ArrayList)v[i])[j]).dist * gg[i - (longtitude - rad), j - (latitude - rad)];
                }
            }

            m.Sort((IComparer)(new Point3DDistComparer()));
            mm = ((Point3D)m[m.Count / 2]);
            return grad;
        }

        public void smoothing(double gradThreshold)
        {
            double param3 = (thresholdUp - thresholdDown) * 0.01;
            Parallel.For(0, parts.Count, num =>
            {
                SectModel sm = (SectModel)parts[num];

                ArrayList v = sm.v;

                double angleStep1 = (sm.sect.xy_end - sm.sect.xy_start) / (v.Count - 1);
                double angleStep2 = (sm.sect.xz_end - sm.sect.xz_start) / (((ArrayList)v[0]).Count - 2);

                for (int i = 1; i < v.Count - 1; i++)
                {
                    double angle1 = sm.sect.xy_start + i * angleStep1;

                    ArrayList vv = (ArrayList)v[i];
                    for (int j = 1; j < vv.Count - 1; j++)
                    {
                        Point3D mm = null;
                        double g = grad(ref v, i, j, 1, ref mm);
                        if (g > gradThreshold)
                        {
                            double angle2 = sm.sect.xz_start + j * angleStep2;
                            ArrayList ray = fillRay(angle1, angle2, sm.startX, sm.startY, sm.startZ);

                            Point3D p = null;
                            for (int k = 1; g > gradThreshold; k++)
                            {
                                p = rayHandler(ref ray, thresholdUp - k * param3, thresholdDown, gradient - k * gradient * 0.01);
                                p.dist = Math.Sqrt((p.x - sm.startX) * (p.x - sm.startX)
                                    + (p.y - sm.startY) * (p.y - sm.startY)
                                    + (p.z - sm.startZ) * (p.z - sm.startZ));
                                vv[j] = p;

                                g = grad(ref v, i, j, 1, ref mm);
                            }
                            if (g < 0)
                            {
                                (vv[j]) = mm;
                            }
                        }
                    }
                }
            });
        }

        static ShaderProgram renderProgram = null;
        public void rayTracingGPU(ref string log, ref short[] _space, ref int[] _size, ref double[] _spacing,
            double startX, double startY, double startZ, bool reloadSpace = false, int rayNum_xy = 200, int rayNum_xz = 100)
        {
             //rayNum_xy = 5;
             //rayNum_xz = 10;

            space = _space;
            size = _size;
            spacing = _spacing;

            
            //if (reloadSpace)
            //{
            //    loaded = false;
            //    if (!InitShaders(ref log))
            //    {
            //        MessageBox.Show("Ошибка! Не удалось инициализировать шейдерную программу.");
            //        //return;
            //    }
            //}

            long time;
            if (!loaded)
            {
                time = -System.DateTime.Now.Ticks;
                loaded = true;
                InitShaders(ref log);
                if (!LoadGLTextures(rayNum_xy, rayNum_xz))
                {
                    MessageBox.Show("Ошибка! Не удалось загрузить текстуры.");
                    return;
                }
                time += System.DateTime.Now.Ticks;
                System.Console.WriteLine("time 1: " + time.ToString());
            }
            else
            {
                time = -System.DateTime.Now.Ticks;
                Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, FramebufferName[0]);
                time += System.DateTime.Now.Ticks;
                System.Console.WriteLine("time 2: " + time.ToString());
            }
            
            // Записываем в переменные шейдеров значения по умолчанию			
            //if (!SetShaderData())
            //{
            //    MessageBox.Show("Ошибка! Не удалось проинициализировать переменные.");
            //    return;
            //}

            // установка порта вывода в соответствии с размерами элемента anT 
            Gl.glViewport(0, 0, rayNum_xy, rayNum_xz);

            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            // Очищаем буфер цвета и буфер глубины
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            // Устанавливаем программный объект в качестве текущего состояния OpenGL
            renderProgram.Bind();

            ////////////////////////////////////////
            SectModel output = new SectModel();
            //SectModel output = (SectModel) parts[0];
            output.setCenter(startX, startY, startZ);

            output.setRayNum(rayNum_xy, rayNum_xz);

            float angleStep1 = (float)(output.sect.xy_end - output.sect.xy_start) / (rayNum_xy - 1);
            float angleStep2 = (float)(output.sect.xz_end - output.sect.xz_start) / (rayNum_xz - 1);

            float xy_start = (float)output.sect.xy_start;
            float xz_start = (float)output.sect.xz_start;

            time = -System.DateTime.Now.Ticks;

            // Устанавливаем переменные
            renderProgram.SetUniformVector("Size", new Vector3D((float)size[0], (float)size[1], (float)size[2]));
            renderProgram.SetUniformVector("Spacing", new Vector3D((float)spacing[0], (float)spacing[1], (float)spacing[2]));
            renderProgram.SetUniformFloat("angleStep1", angleStep1);
            renderProgram.SetUniformFloat("angleStep2", angleStep2);
            renderProgram.SetUniformFloat("xy_start", xy_start);
            renderProgram.SetUniformFloat("xz_start", xz_start);
            renderProgram.SetUniformFloat("startX", (float)startX);
            renderProgram.SetUniformFloat("startY", (float)startY);
            renderProgram.SetUniformFloat("startZ", (float)startZ);
            renderProgram.SetUniformInteger("thresholdUp", thresholdUp);
            renderProgram.SetUniformInteger("thresholdDown", thresholdDown);
            renderProgram.SetUniformFloat("gradient", (float)gradient);

            time += System.DateTime.Now.Ticks;
            System.Console.WriteLine("time 3: " + time.ToString());

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3f(-1.0f, -1f, 0.0f);
            Gl.glVertex3f(-1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(1.0f, -1.0f, 0.0f);
            Gl.glEnd();

            int chan = 4;
            output.vv = new float[chan * rayNum_xy * rayNum_xz];
            Gl.glGetTexImage(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, Gl.GL_FLOAT, output.vv);
            parts.Add(output);
            ////////////////////////////////////////

            //Gl.glBegin(Gl.GL_QUADS);
            //Gl.glVertex3f(-1.0f, -1f, 0.0f);
            //Gl.glVertex3f(-1.0f, 1.0f, 0.0f);
            //Gl.glVertex3f(1.0f, 1.0f, 0.0f);
            //Gl.glVertex3f(1.0f, -1.0f, 0.0f);
            //Gl.glEnd();

            //int chan = 4;
            //var pixels = new float[chan * rayNum_xy * rayNum_xz];
            //Gl.glGetTexImage(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, Gl.GL_FLOAT, pixels);

            //for (int i = 0; i < rayNum_xy; i++)
            //{
            //    for (int j = 0; j < rayNum_xz; j++)
            //    {
            //        System.Console.Write("(" + output.vv[i * rayNum_xz * chan + j * chan + 0] + ", "
            //            + output.vv[i * rayNum_xz * chan + j * chan + 1] + ", "
            //            + output.vv[i * rayNum_xz * chan + j * chan + 2] + ", "
            //            + output.vv[i * rayNum_xz * chan + j * chan + 3] + ") ");
            //    }
            //    System.Console.WriteLine();
            //}

            finilize();
        }

        static public bool InitShaders(ref string log)
        {
            // Результат загрузки шейдеров
            bool result = true;

            // Загружаем шейдеры
            {
                // Создаем пустой программный объект
                renderProgram = new ShaderProgram();

                // Загружаем фрагментный шейдер
                if (!renderProgram.SetFragmentShaderFile(new string[] { "..\\..\\..\\Shaders\\RenderShader.fs" }))
                {
                    result = false;
                }

                // Компонуем программный объект
                if (!renderProgram.LinkProgram())
                {
                    result = false;
                }

                // Отображаем информационный журнал программного объекта
                log += "================ RENDER PROGRAM LOG ================\n\n";
                log += renderProgram.Log;
            }

            return result;
        }

        private int[] texture = new int[1];
        private static int[] FramebufferName;
        static private bool loaded = false;
        private bool LoadGLTextures(int rayNum_xy, int rayNum_xz)
        {
            //if (!loaded)
            {
                Gl.glGenTextures(1, texture);                            // Create The Texture

                Gl.glBindTexture(Gl.GL_TEXTURE_3D, texture[0]);
                float[] ftmp = Array.ConvertAll<short, float>(space, item => (float)item);
                Gl.glTexImage3D(Gl.GL_TEXTURE_3D, 0, 33325, size[0], size[1], size[2], 0, Gl.GL_RED, Gl.GL_FLOAT, ftmp);
                Gl.glTexParameteri(Gl.GL_TEXTURE_3D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
                Gl.glTexParameteri(Gl.GL_TEXTURE_3D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);

                loaded = true;
            }

            /*
             * Here we are starting to initiate rendering to texture 
             */

            FramebufferName = new int[1];
            Gl.glGenFramebuffersEXT(1, FramebufferName);
            Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, FramebufferName[0]);

            int[] renderedTexture = new int[1];
            Gl.glGenTextures(1, renderedTexture);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, renderedTexture[0]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA_FLOAT32_ATI, rayNum_xy, rayNum_xz, 0, Gl.GL_RGBA, Gl.GL_FLOAT, 0);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);

            Gl.glFramebufferTexture2DEXT(Gl.GL_FRAMEBUFFER_EXT, Gl.GL_COLOR_ATTACHMENT0_EXT, Gl.GL_TEXTURE_2D, renderedTexture[0], 0);
            int[] DrawBuffers = { Gl.GL_COLOR_ATTACHMENT0_EXT };
            Gl.glDrawBuffers(1, DrawBuffers);
            if (Gl.glCheckFramebufferStatusEXT(Gl.GL_FRAMEBUFFER_EXT) != Gl.GL_FRAMEBUFFER_COMPLETE_EXT)
            {
                return false;
            }
            Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, FramebufferName[0]);

            return true;
        }

        private void finilize()
        {
            // Возвращаемся к стандартной функциональности OpenGL			
            renderProgram.Unbind();

            Gl.glBindFramebufferEXT(Gl.GL_FRAMEBUFFER_EXT, 0);
        }

        private bool SetShaderData()
        {
            // Устанавливаем программный объект в качестве состояния OpenGL
            renderProgram.Bind();

            renderProgram.SetUniformVector("Size", new Vector3D((float)size[0], (float)size[1], (float)size[2]));
            renderProgram.SetUniformVector("Spacing", new Vector3D((float)spacing[0], (float)spacing[1], (float)spacing[2]));

            // Возвращаемся к стандартной функциональности OpenGL
            renderProgram.Unbind();

            return true;
        }
    }
}
