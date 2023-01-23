using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using XnaGeometry;
using Blue.Windows;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OrbitWin
{
    public partial class frmMain : Form
    {
        StickyWindow stickyWindow;

        public frmMain()
        {
            InitializeComponent();
            stickyWindow = new StickyWindow(this);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            pgOrbit.SelectedObject = Core.CFG;
            SetupViewport();
        }

        private void pgOrbit_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            pgOrbit.SelectedObject = Core.CFG;
            SetupViewport();
        }

        #region [ render ]

        public double glWidth { get { return glOrbit.Width; } }
        public double glHeight { get { return glOrbit.Height; } }

        Stopwatch sw = new Stopwatch(); // available to all event handlers
        bool loaded = false;
        bool ldown = false;
        bool rdown = false;
        double accumulator = 0;
        int idleCounter = 0;

        void Application_Idle(object sender, EventArgs e)
        {
            //ComputeTimeSlice
            sw.Stop();
            double milliseconds = sw.Elapsed.TotalMilliseconds;
            sw.Reset();
            sw.Start();

            //Accumulate
            idleCounter++;
            accumulator += milliseconds;
            if (accumulator > 1000)
            {
                accumulator -= 1000;
                idleCounter = 0; // don't forget to reset the counter!
            }

            //Animate
            Core.Update(milliseconds);
            glOrbit.Invalidate();
        }

        private void SetupViewport()
        {
            GL.Viewport(0, 0, glOrbit.Width, glOrbit.Height);

            GL.MatrixMode(MatrixMode.Projection);

            XnaGeometry.RectangleF rc = Core.CFG.ViewRect;

            GL.LoadMatrix(
                XnaGeometry.Matrix.ToFloatArray(
                    Matrix.CreateOrthographicOffCenter(rc.Left, rc.Right, rc.Top, rc.Bottom, -1, 1)
                )
            );
        }

        private void glOrbit_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.DarkGray); //Color.SkyBlue
            SetupViewport();
            Application.Idle += Application_Idle;
            sw.Start();
        }

        private void glOrbit_Resize(object sender, EventArgs e)
        {
            pgOrbit.SelectedObject = Core.CFG;
            SetupViewport();
            glOrbit.Invalidate();
        }

        private void glOrbit_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Tool.DrawAxis(Core.CFG.ViewRect, Core.CFG.Unit, Core.CFG.Scale, Core.CFG.Width / glOrbit.Width, Core.CFG.ShowMarks);

            Tool.DrawEllipse(Core.CFG.Points, Core.CFG.Scale);

            glOrbit.SwapBuffers();
        }

        #region [ Mouse ]

        Vector2 old = new Vector2();
        XnaGeometry.RectangleF oldrc = new XnaGeometry.RectangleF();
        Vector2 down =  new Vector2();

        Vector2 ChangeCoordinateSystem (XnaGeometry.RectangleF from, XnaGeometry.RectangleF to, Vector2 pt)
        {
            Vector2 res = new Vector2();

            res.X = (pt.X - from.Left) * (to.Right - to.Left) / (from.Right - from.Left) + to.Left;
            res.Y = (pt.Y - from.Top) * (to.Bottom - to.Top) / (from.Bottom - from.Top) + to.Top;

            return res;
        }

        private void glOrbit_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                old = new Vector2(Core.CFG.DX, Core.CFG.DY);
                oldrc = Core.CFG.ViewRect;
                down = ChangeCoordinateSystem(
                    new XnaGeometry.RectangleF(0, 0, glOrbit.Width, -glOrbit.Height),
                    Core.CFG.ViewRect,
                    new Vector2(e.X, e.Y));
                ldown = true;
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                old = new Vector2(Core.CFG.DX, Core.CFG.DY);
                oldrc = Core.CFG.ViewRect;
                down = ChangeCoordinateSystem(
                    new XnaGeometry.RectangleF(0, 0, glOrbit.Width, -glOrbit.Height),
                    Core.CFG.ViewRect,
                    new Vector2(e.X, e.Y));
                rdown = true;
            }
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

                Vector2 cur = ChangeCoordinateSystem(
                    new XnaGeometry.RectangleF(0, 0, glOrbit.Width, -glOrbit.Height),
                    oldrc,
                    new Vector2(e.X, e.Y));

                Vector2 delta = down - cur;
                Vector2 updated = old + delta;

                Core.CFG.DX = updated.X;
                Core.CFG.DY = updated.Y;

                pgOrbit.SelectedObject = Core.CFG;
                SetupViewport();
                glOrbit.Invalidate();
            }

            if (rdown)
            {
                //...
            }
        }

        #endregion

        #endregion


    }
}
