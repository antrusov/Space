using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using XnaGeometry;

namespace OrbitWin
{
    static class Tool
    {
        #region [ Render ]

        //нарисовать оси
        public static void DrawAxis(XnaGeometry.RectangleF rcView, double unit, double scale, double pixelSize, bool marks)
        {
            Color l = Color.Green;
            Color b = Color.Red;
            Color s = Color.Blue;

            double b1 = pixelSize / scale *  -3;
            double b2 = pixelSize / scale * 3;
            double s1 = pixelSize / scale * -2;
            double s2 = pixelSize / scale * 2;

            //marks
            if (rcView.Top < 0 && 0 < rcView.Bottom)
            {
                if (marks)
                {
                    GL.Begin(PrimitiveType.Lines);
                    double start = rcView.Left - rcView.Left % unit;
                    double end = rcView.Right;
                    GL.Color3(s);
                    for (double x = start; x < end; x += unit / scale / 10)
                    {
                        GL.Vertex3(x, s1, 0);
                        GL.Vertex3(x, s2, 0);
                    }
                    GL.Color3(b);
                    for (double x = start; x < end; x += unit / scale)
                    {
                        GL.Vertex3(x, b1, 0);
                        GL.Vertex3(x, b2, 0);
                    }
                    GL.End();
                }
            }

            if (rcView.Top < 0 && 0 < rcView.Bottom)
            {
                if (marks)
                {
                    GL.Begin(PrimitiveType.Lines);
                    double start = rcView.Top - rcView.Top % unit;
                    double end = rcView.Bottom;
                    GL.Color3(s);
                    for (double y = start; y < end; y += unit / scale / 10)
                    {
                        GL.Vertex3(s1, y, 0);
                        GL.Vertex3(s2, y, 0);
                    }
                    GL.Color3(b);
                    for (double y = start; y < end; y += unit / scale)
                    {
                        GL.Vertex3(b1, y, 0);
                        GL.Vertex3(b2, y, 0);
                    }
                    GL.End();
                }
            }

            //lines
            if (rcView.Top < 0 && 0 < rcView.Bottom)
            {
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(l);
                GL.Vertex3(0, rcView.Top, 0);
                GL.Vertex3(0, rcView.Bottom, 0);
                GL.End();
            }

            if (rcView.Top < 0 && 0 < rcView.Bottom)
            {
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(l);
                GL.Vertex3(rcView.Left, 0, 0);
                GL.Vertex3(rcView.Right, 0, 0);
                GL.End();
            }
            
        }

        public static void DrawEllipse(List<Vector2> points, double scale)
        {
            Color l = Color.Yellow;

            GL.Color3(l);
            GL.Begin(PrimitiveType.LineLoop);
            for (int i = 0; i < points.Count; i++)
            {
                XnaGeometry.Vector2 v = points[i];
                GL.Vertex3(v.X / scale, v.Y / scale,0);
            }
            GL.End();
        }

        //...

        #endregion

    }
}
