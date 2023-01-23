using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XnaGeometry;
using System.ComponentModel;
using System.Globalization;

namespace Space
{

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CameraLookAt : ICamera
    {

        #region [ data members ]

        double  wd;
        double  hg;
        double  zoom;
        double  near;
        double  far;
        double  offset;
        Vector3 target;
        double  rotox;
        double  rotoy;

        #endregion

        #region [ properties ]

        public Matrix Matrix
        {
            get { return BuildCamera(); }
        }

        public double[] MatrixArray
        {
            get { return XnaGeometry.Matrix.ToFloatArray(BuildCamera()); }
        }

        public double WD { get { return wd; } set { wd = value; } }
        public double HG { get { return hg; } set { hg = value; } }
        public Vector3 Target { get { return target; } set { target = value; } }

        double scale = 1;
        public double Scale { get { return scale; } set { scale = value < 0 ? 1 : value; } }

        #endregion

        #region [ public methods ]

        public CameraLookAt(double wd, double hg, double near, double far)
        {
            SetupCamera(wd, hg, near, far, 0, new Vector3(0, 0, 0), 0, 0);
        }

        public CameraLookAt(double wd, double hg, double near, double far, double offset)
        {
            SetupCamera(wd, hg, near, far, offset, new Vector3(0, 0, 0), 0, 0);
        }

        public CameraLookAt(double wd, double hg, double near, double far, double offset, Vector3 target)
        {
            SetupCamera(wd, hg, near, far, offset, target, 0, 0);
        }

        public CameraLookAt(double wd, double hg, double near, double far, double offset, Vector3 target, double rotox, double rotoy)
        {
            SetupCamera(wd, hg, near, far, offset, target, rotox, rotoy);
        }

        public void Move(string name, double arg)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            switch (name.ToLower())
            {
                case "rotoy":
                    rotoy += arg;
                    break;

                case "rotox":
                    rotox += arg;
                    break;

                case "zoom":
                    zoom += arg;
                    break;

                case "dist":
                    offset += arg;
                    break;
            }
        }

        #endregion

        #region [ private methods]

        public void SetupCamera(double wd, double hg, double near, double far, double offset, Vector3 target, double rotox, double rotoy)
        {
            this.wd     = wd;
            this.hg     = hg;
            this.near   = near;
            this.far    = far;
            this.offset = offset;
            this.target = target;
            this.rotox  = rotox;
            this.rotoy  = rotoy;

            this.zoom = 1;
        }

        public Matrix BuildCamera()
        {
            const double zoomfactor = 0.1;

            double t = (zoom > 0) ? zoomfactor * zoom : zoomfactor * (1 / -zoom);
            double wd2 = t * wd / 2;
            double hg2 = t * hg / 2;

            Matrix s = Matrix.CreateScale(Scale);
            Matrix proj = Matrix.CreatePerspectiveOffCenter(-wd2, +wd2, -hg2, +hg2, near, far);
            Matrix shift  = Matrix.CreateTranslation(0, 0, -offset);
            Matrix lookat = Matrix.CreateTranslation(-target * Scale);
            Matrix rotateoy = Matrix.CreateRotationY(zoomfactor * rotoy);
            Matrix rotateox = Matrix.CreateRotationX(zoomfactor * rotox);

            Matrix res = s * lookat * rotateox * rotateoy * shift * proj;

            return res;
        }

        #endregion
    }
}
