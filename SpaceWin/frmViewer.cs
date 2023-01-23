using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Diagnostics;
using Space;
using Blue.Windows;
using XnaGeometry;

namespace SpaceWin
{
    public partial class frmViewer : Form
    {
        bool loaded = false;
        bool ldown = false;
        bool rdown = false;

        int mx = 0;
        int my = 0;
        int mdx = 0;
        int mdy = 0;

        StickyWindow stickyWindow;
        public frmViewer()
        {
            InitializeComponent();
            stickyWindow = new StickyWindow(this);
        }

        Stopwatch sw = new Stopwatch(); // available to all event handlers
        private void glOrbit_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.DarkGray); //Color.SkyBlue
            SetupViewport();
            Application.Idle += Application_Idle;
            sw.Start();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            double milliseconds = ComputeTimeSlice();
            Accumulate(milliseconds);
            Animate(milliseconds);
        }

        private void Animate(double milliseconds)
        {
            Core.Update(milliseconds);
            glOrbit.Invalidate();
        }

        double accumulator = 0;
        int idleCounter = 0;
        private void Accumulate(double milliseconds)
        {
            idleCounter++;
            accumulator += milliseconds;
            if (accumulator > 1000)
            {
                //label1.Text = idleCounter.ToString();
                accumulator -= 1000;
                idleCounter = 0; // don't forget to reset the counter!
            }
        }

        private double ComputeTimeSlice()
        {
            sw.Stop();
            double timeslice = sw.Elapsed.TotalMilliseconds;
            sw.Reset();
            sw.Start();
            return timeslice;
        }

        private void SetupViewport()
        {
            GL.Viewport(0, 0, Width, Height);

            Core.CFG.Camera.WD = Settings.camwd;
            Core.CFG.Camera.HG = Settings.camwd * Height / Width;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(Core.CFG.Camera.MatrixArray);
        }

        private void glOrbit_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            if (Core.CFG.Follow)
            {
                int cur = Core.ORBITS.Current;
                XnaGeometry.Vector3 follow = Core.ORBITS.Items[cur].Orbit.Time2Pos(Core.ORBITS.Items[cur].Time);
                Core.CFG.Camera.Target = follow;
            }
            else
                Core.CFG.Camera.Target = XnaGeometry.Vector3.Zero;
            GL.LoadMatrix(Core.CFG.Camera.MatrixArray);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            //оси
            RenderTool.Axis(0, 0, 0, .01, -.01);

            //юпитер
            //GL.Color3(Color.Red);
            //RenderTool.Sphere(0.0004779, 12, 12);

            //сетка
            double halphGrid = 0.2;
            int halphCells = 10;
            RenderTool.Grid(halphGrid, halphGrid, halphGrid, halphCells, Color.LightGray, Color.LightGray);

            //орбиты
            for (int i = 0; i < Core.ORBITS.Items.Count; i++)
            {
                Vector3 body = Core.ORBITS.Items[i].Orbit.Time2Pos(Core.ORBITS.Items[i].Time);
                if (Core.ORBITS.Items[i].Enable)
                    RenderTool.Orbit(
                        Core.ORBITS.Items[i].Points,
                        body,
                        Core.ORBITS.Current == i ? Core.CFG.ColorOrbitCurrent : Core.CFG.ColorOrbit,
                        Core.CFG.ColorDot);
            }

            //лучи
            if (Core.CFG.Rays)
            {
                GL.Color3(Color.Red);

                int cur = Core.ORBITS.Current;
                XnaGeometry.Vector3 from = Core.ORBITS.Items[cur].Orbit.Time2Pos(Core.ORBITS.Items[cur].Time);

                for (int i = 0; i < Core.ORBITS.Items.Count; i++)
                {
                    if (Core.ORBITS.Items[i].Enable)
                    {
                        XnaGeometry.Vector3 to = Core.ORBITS.Items[i].Orbit.Time2Pos(Core.ORBITS.Items[i].Time);
                        GL.Begin(PrimitiveType.Lines);
                        GL.Vertex3(from.X, from.Y, from.Z);
                        GL.Vertex3(to.X, to.Y, to.Z);
                        GL.End();
                    }
                }
            }

            glOrbit.SwapBuffers();
        }

        private void glOrbit_Resize(object sender, EventArgs e)
        {
            SetupViewport();
            glOrbit.Invalidate();
        }

        private void glOrbit_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) ldown = true;
            if (e.Button == System.Windows.Forms.MouseButtons.Right) rdown = true;
            mx = e.X;
            my = e.Y;
        }

        private void glOrbit_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) ldown = false;
            if (e.Button == System.Windows.Forms.MouseButtons.Right) rdown = false;
        }

        private void glOrbit_MouseMove(object sender, MouseEventArgs e)
        {
            if (ldown)
            {
                mdx = e.X - mx;
                mdy = e.Y - my;
                mx = e.X;
                my = e.Y;

                //rotate
                double scale = (1.0 / 15.0);
                Core.CFG.Camera.Move("rotoy", scale * mdx);
                Core.CFG.Camera.Move("rotox", scale * mdy);
            }

            if (rdown)
            {
                mdx = e.X - mx;
                mdy = e.Y - my;
                mx = e.X;
                my = e.Y;

                //rotate
                double scale = (1.0 / 50.0);
                Core.CFG.Camera.Move("dist", scale * mdy);
            }
        }

        private void frmViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageDown) Core.ORBITS.Current--;
            if (e.KeyCode == Keys.PageUp) Core.ORBITS.Current++;
        }

    }
}
