using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Space;
using XnaGeometry;
using OrderedPropertyGrid;

namespace OrbitWin
{
    [TypeConverter(typeof(PropertySorter))]
    [DefaultProperty("M")]
    class Config
    {

        Kepler kepler = new Kepler(3,2.5,100500);
        int steps = 100;

        bool play = true;
        double time = 0;
        double timestep = 0.1;
        double timescale = 100;

        double scale = 1;
        double width = 10;
        double dx = 0;
        double dy = 0;

        double unit = 1;
        bool showaxis = true;
        bool showmarks = true;
        bool showvelocity = true;

        public List<Vector2> Points = new List<Vector2>();

        public void UpdatePoints(int steps)
        {
            Points = new List<Vector2>();
            double dta = kepler.Total / steps;
            for (int i = 0; i < steps; i++)
            {
                Vector2 pt = kepler.Time2Pos(dta * i);
                pt.X -= kepler.C;
                Points.Add(pt);
            }
        }

        public Config ()
        {
            UpdatePoints(steps);
        }

        #region [ Orbit ]

        [Category("Orbit"), DisplayName("A"), Description("Major axis (m)"), PropertyOrder(100)]
        public double A
        {
            get { return kepler.A; }
            set {
                if (value > 0)
                {
                    kepler = new Kepler(value, kepler.B, kepler.M0);
                    UpdatePoints(steps);
                }
            }
        }

        //B
        [Category("Orbit"), DisplayName("B"), Description("Minor axis (m)"), PropertyOrder(110)]
        public double B
        {
            get { return kepler.B; }
            set
            {
                if (value > 0)
                {
                    kepler = new Kepler(kepler.A, value, kepler.M0);
                    UpdatePoints(steps);
                }
            }
        }

        //M
        [Category("Orbit"), DisplayName("Mass"), Description("Total mass (kg)"), PropertyOrder(120)]
        public double M
        {
            get { return kepler.M0; }
            set
            {
                if (value > 0)
                {
                    kepler = new Kepler(kepler.A, kepler.B, value);
                    UpdatePoints(steps);
                }
            }
        }

        //Steps
        [Category("Orbit"), DisplayName("Steps"), Description("Points on orbit"), PropertyOrder(125)]
        public int Steps
        {
            get { return steps; }
            set
            {
                if (value > 0)
                {
                    steps = value;
                    UpdatePoints(steps);
                }
            }
        }

        //E
        [Category("Orbit"), DisplayName("e"), Description("Eccentricity"), PropertyOrder(130)]
        public double e
        {
            get { return kepler.Eccentricity; }
        }

        //P
        [Category("Orbit"), DisplayName("Focus"), Description("Focus (m)"), PropertyOrder(140)]
        public double F
        {
            get { return kepler.C; }
        }

        //T
        [Category("Orbit"), DisplayName("Period"), Description("Total time (s)"), PropertyOrder(150)]
        public double T
        {
            get { return kepler.Total; }
        }

        #endregion

        #region [ Play ]

        //Play
        [Category("Motion"), DisplayName("Play"), Description("Body motion (y/n)"), PropertyOrder(200)]
        public bool Play
        {
            get { return play; }
            set { play = value; }
        }

        //Time
        [Category("Motion"), DisplayName("Time"), Description("Current time (s)"), PropertyOrder(210)]
        public double Time
        {
            get { return time; }
            set { time = value; }
        }

        //TimeStep
        [Category("Motion"), DisplayName("Time Step"), Description("Time step per iteration (s)"), PropertyOrder(220)]
        public double TimeStep
        {
            get { return timestep; }
            set { timestep = value; }
        }

        //TimeScale
        [Category("Motion"), DisplayName("Time Scale"), Description("Time scale for body motion"), PropertyOrder(230)]
        public double TimeScale
        {
            get { return timescale; }
            set { timescale = value; }
        }

        #endregion

        #region [ View ]

        //Scale
        [Category("View"), DisplayName("Scale"), Description("Scale of field of view"), PropertyOrder(300)]
        public double Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        //Width
        [Category("View"), DisplayName("Width"), Description("Field of view horizontal size (m)"), PropertyOrder(310)]
        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        //Aspect
        [Category("View"), DisplayName("Aspect"), Description("Width / Height"), PropertyOrder(315)]
        public double Aspect
        {
            get { return Core.MainWindow.glWidth / Core.MainWindow.glHeight; }
        }

        //DX
        [Category("View"), DisplayName("X offset"), Description("The offset of coordinate system by x axis (m)"), PropertyOrder(320)]
        public double DX
        {
            get { return dx; }
            set { dx = value; }
        }

        //DY
        [Category("View"), DisplayName("Y offset"), Description("The offset of coordinate system by y axis (m)"), PropertyOrder(330)]
        public double DY
        {
            get { return dy; }
            set { dy = value; }
        }

        //Unit
        [Category("View"), DisplayName("Marks unit"), Description("The unit size for marks (m)"), PropertyOrder(335)]
        public double Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        //SpaceRect
        [Category("View"), DisplayName("Space rect"), Description("Rectangle of visible space (m x m)"), PropertyOrder(336)]
        public RectangleF SpaceRect
        {
            get
            {
                return new RectangleF(
                    Core.CFG.DX - Core.CFG.Width / 2,
                    Core.CFG.DY - Core.CFG.Width / Core.CFG.Aspect / 2,
                    Core.CFG.Width,
                    Core.CFG.Width / Core.CFG.Aspect);
            }
        }

        //ViewRect
        [Category("View"), DisplayName("View rect"), Description("Rectangle of field view"), PropertyOrder(337)]
        public RectangleF ViewRect
        {
            get
            {
                return new RectangleF(
                    Core.CFG.DX - Core.CFG.Width / 2                   / Core.CFG.Scale,
                    Core.CFG.DY - Core.CFG.Width / Core.CFG.Aspect / 2 / Core.CFG.Scale,
                    Core.CFG.Width                                     / Core.CFG.Scale,
                    Core.CFG.Width / Core.CFG.Aspect                   / Core.CFG.Scale);
            }
        }

        //ShowAxis
        [Category("View"), DisplayName("Show axis"), Description("The visibility of axis (y/n)"), PropertyOrder(340)]
        public bool ShowAxis
        {
            get { return showaxis; }
            set { showaxis = value; }
        }

        //ShowMarks
        [Category("View"), DisplayName("Show marks"), Description("The visibility of marks (y/n)"), PropertyOrder(350)]
        public bool ShowMarks
        {
            get { return showmarks; }
            set { showmarks = value; }
        }

        //ShowVelocity
        [Category("View"), DisplayName("Show velocity"), Description("The visibility of velocity vector (y/n)"), PropertyOrder(360)]
        public bool ShowVelocity
        {
            get { return showvelocity; }
            set { showvelocity = value; }
        }




        #endregion

    }
}
