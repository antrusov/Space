using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Space;
using XnaGeometry;

namespace SpaceWin
{
    public static class RenderTool
    {

        public static void Grid(double dx, double dy, double dz, int cells, Color c1, Color c2)
        {
            double cdx = dx/cells;
            double cdy = dy/cells;

            GL.Begin(PrimitiveType.Lines);
            GL.Color3(c1);
            for (double x = -dx; x <= dx; x += cdx)
            {
                GL.Vertex3(x, -dy, dz);
                GL.Vertex3(x, +dy, dz);

                GL.Vertex3(x, -dy, -dz);
                GL.Vertex3(x, +dy, -dz);
            }

            GL.Color3(c2);
            for (double y = -dy; y <= dy; y += cdy)
            {
                GL.Vertex3(-dx, y, dz);
                GL.Vertex3(+dx, y, dz);

                GL.Vertex3(-dx, y, -dz);
                GL.Vertex3(+dx, y, -dz);
            }
            GL.End();

        }

        public static void Axis(double x, double y, double z, double axis_pozitive, double axis_negative)
        {
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(x + axis_negative, y + 0, z + 0);
            GL.Vertex3(x + axis_pozitive, y + 0, z + 0);

            GL.Color3(Color.Green);
            GL.Vertex3(x + 0, y + axis_negative, z + 0);
            GL.Vertex3(x + 0, y + axis_pozitive, z + 0);

            GL.Color3(Color.Blue);
            GL.Vertex3(x + 0, y + 0, z + axis_negative);
            GL.Vertex3(x + 0, y + 0, z + axis_pozitive);
            GL.End();
        }

        public static void Orbit(List<Vector3> points, Vector3 body, Color linecolor, Color dotcolor)
        {
            //линии
            if (linecolor != Color.Transparent)
            {
                GL.Color3(linecolor);
                GL.Begin(PrimitiveType.LineLoop);
                for (int i = 0; i < points.Count; i++)
                {
                    XnaGeometry.Vector3 v = points[i];
                    GL.Vertex3(v.X, v.Y, v.Z);
                }
                GL.End();
            }

            //точки
            if (dotcolor != Color.Transparent)
            {
                GL.Color3(dotcolor);
                GL.PointSize(2);
                GL.Begin(PrimitiveType.Points);
                for (int i = 0; i < points.Count; i++)
                {
                    XnaGeometry.Vector3 v = points[i];
                    GL.Vertex3(v.X, v.Y, v.Z);
                }
                GL.End();
            }

            //космическое тело
            GL.Color3(Color.Green);
            GL.PointSize(3);
            GL.Begin(PrimitiveType.Points);
            XnaGeometry.Vector3 p = body;
            GL.Vertex3(p.X, p.Y, p.Z);
            GL.End();
        }

        public static void Sphere(double r, int nx, int ny)
        {
            int ix, iy;
            double x, y, z;

            for (iy = 0; iy < ny; ++iy)
            {
                GL.Begin(PrimitiveType.QuadStrip);
                for (ix = 0; ix <= nx; ++ix)
                {
                    x = r * Math.Sin(iy * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
                    y = r * Math.Sin(iy * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
                    z = r * Math.Cos(iy * Math.PI / ny);
                    GL.Normal3(x, y, z);//нормаль направлена от центра
                    GL.TexCoord2((double)ix / (double)nx, (double)iy / (double)ny);
                    GL.Vertex3(x, y, z);

                    x = r * Math.Sin((iy + 1) * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
                    y = r * Math.Sin((iy + 1) * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
                    z = r * Math.Cos((iy + 1) * Math.PI / ny);
                    GL.Normal3(x, y, z);
                    GL.TexCoord2((double)ix / (double)nx, (double)(iy + 1) / (double)ny);
                    GL.Vertex3(x, y, z);
                }
                GL.End();
            }
        }
    }
}
