using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using OpenTK;
using graph = OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace SpaceWin
{
    class OrbitViewer : GameWindow
    {
        public OrbitViewer()
            : base(800, 600, graph.GraphicsMode.Default, "Orbit Viewer")
        {
            //...
        }

        //close -> hide
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Visible = false;

            base.OnClosing(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            // Camera
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            //Matrix4 modelview = Matrix4.RotateY(perimeter);						// Rotate
            Matrix4 modelview = Matrix4.CreateRotationY(0);							// Rotate
            modelview *= Matrix4.LookAt(20f, 20f, -20f, 0f, 0f, 0f, 0f, 1f, 0f);	// Set eye and target
            GL.LoadMatrix(ref modelview);

            GL.Begin(PrimitiveType.Triangles);

            double ax = 10, ay = 10;
            double bx = 100, by = 10;
            double cx = 100, cy = 50;

            GL.Vertex2(ax, ay);
            GL.Vertex2(bx, by);
            GL.Vertex2(cx, cy);

            GL.Vertex2(-ax, -ay);
            GL.Vertex2(-bx, -by);
            GL.Vertex2(-cx, -cy);

            GL.Vertex2(-ax, ay);
            GL.Vertex2(-by, bx);
            GL.Vertex2(-cy, cx);

            GL.Vertex2(ax, -ay);
            GL.Vertex2(by, -bx);
            GL.Vertex2(cy, -cx);

            GL.End();

            SwapBuffers();
        }

    }
}
