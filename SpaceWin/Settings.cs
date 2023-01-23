using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using Space;
using XnaGeometry;

namespace SpaceWin
{
    class Settings
    {
        public const double camwd = 10;

        CameraLookAt camera = new CameraLookAt(2, 2, 1, 500, 35);

        Color  colorOrbitCurrent = Color.Blue;
        Color  colorOrbit        = Color.Yellow;
        Color  colorDot          = Color.Transparent;
        int    distHistory       = 100;
        bool   play              = true;
        bool   rays              = false;
        bool   follow            = false;
        double timestep          = 10;
        double timescale         = 0.1;

        [Category("View")]
        public CameraLookAt Camera
        {
            get { return camera; }
            set { camera = value; }
        }

        [Category("Color Settings")]
        public Color ColorOrbitCurrent
        {
            get { return colorOrbitCurrent; }
            set { colorOrbitCurrent = value; }
        }

        [Category("Color Settings")]
        public Color ColorOrbit
        {
            get { return colorOrbit; }
            set { colorOrbit = value; }
        }

        [Category("Color Settings")]
        public Color ColorDot
        {
            get { return colorDot; }
            set { colorDot = value; }
        }

        public int DistHistory
        {
            get { return distHistory; }
            set { distHistory = value; }
        }

        public bool Play
        {
            get { return play; }
            set { play = value; }
        }

        public bool Rays
        {
            get { return rays; }
            set { rays = value; }
        }

        public bool Follow
        {
            get { return follow; }
            set { follow = value; }
        }

        public double TimeStep
        {
            get { return timestep; }
            set { timestep = value; }
        }

        public double TimeScale
        {
            get { return timescale; }
            set { timescale = value; }
        }
    }
}
