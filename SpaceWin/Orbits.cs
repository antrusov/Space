using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Space;
using XnaGeometry;

namespace SpaceWin
{
    class Orbits
    {
        public class OrbitEx
        {
            public Orbit Orbit;
            public double Time;
            public bool Enable;
            public int Steps { get; private set; }
            public List<Vector3> Points = new List<Vector3>();

            public OrbitEx(Orbit orbit, int steps)
            {
                steps = steps <= 10 ? 10 : steps;

                this.Orbit = orbit;
                this.Time = 0;
                this.Enable = true;
                this.Steps = steps;
                BuildPoints(steps);
            }

            //fill orbit points
            public void BuildPoints(int steps)
            {
                Points = new List<Vector3>();
                double dta = Orbit.Ellipse.Total / steps;
                for (int i = 0; i < steps; i++)
                {
                    Vector3 pt = Orbit.Time2Pos(dta * i);
                    Points.Add(pt);
                }
            }
        }

        double Time = 0;
        double TimeDelta = 0;

        //Name
        string name = "undefined";
        public string Name { get { return name; } }

        //Mass
        double mass;
        public double Mass { get { return mass; } }

        //Current
        int current = 0;
        public int Current
        {
            get
            {
                if (current < 0)
                    current = Items.Count + current % Items.Count;
                return current % Items.Count;
            }
            set { current = value; }
        }

        //orbits
        public List<OrbitEx> Items = new List<OrbitEx>();

        //dists
        public List<List<double>> Dists;

        //ctor
        public Orbits()
        {
            //Load(@"..\Data\Jupter.xml");

            name = "Jupter";
            mass = 317.832;

            //init orbits
            Items = new List<OrbitEx>
            (
                new OrbitEx[]
                {
                    new OrbitEx( new Orbit(new Kepler(0.05018048128, 0.05018048128 * Math.Sqrt(1 - 0.2420 * 0.2420), Mass), Quaternion.CreateFromYawPitchRollGrad(238.413, 47.584, 223.444 ), "Themisto/Jupiter XVIII"),            100),
                    new OrbitEx( new Orbit(new Kepler(0.07787433154, 0.07787433154 * Math.Sqrt(1 - 0.1636 * 0.1636), Mass), Quaternion.CreateFromYawPitchRollGrad(275.215, 28.776, 235.611 ), "Leda/Jupiter XIII"),                 100),
                    new OrbitEx( new Orbit(new Kepler(0.07661096256, 0.07661096256 * Math.Sqrt(1 - 0.1623 * 0.1623), Mass), Quaternion.CreateFromYawPitchRollGrad(316.73, 30.182, 90.236   ), "Himalia/Jupiter VI"),                100),
                    new OrbitEx( new Orbit(new Kepler(0.07832219250, 0.07832219250 * Math.Sqrt(1 - 0.1124 * 0.1124), Mass), Quaternion.CreateFromYawPitchRollGrad(45.606, 25.989, 33.831   ), "Lysithea/Jupiter X"),                100),
                    new OrbitEx( new Orbit(new Kepler(0.07848262031, 0.07848262031 * Math.Sqrt(1 - 0.2174 * 0.2174), Mass), Quaternion.CreateFromYawPitchRollGrad(126.817, 30.52, 137.714  ), "Elara/Jupiter VII"),                 100),
                    new OrbitEx( new Orbit(new Kepler(0.14217245990, 0.14217245990 * Math.Sqrt(1 - 0.2156 * 0.2156), Mass), Quaternion.CreateFromYawPitchRollGrad(95.23, 148.117, 294.484  ), "Iocaste/Jupiter XXIV"),              100),
                    new OrbitEx( new Orbit(new Kepler(0.14135695190, 0.14135695190 * Math.Sqrt(1 - 0.2296 * 0.2296), Mass), Quaternion.CreateFromYawPitchRollGrad(185.546, 141.869, 305.912), "Praxidike/Jupiter XXVII"),           100),
                    new OrbitEx( new Orbit(new Kepler(0.14107620320, 0.14107620320 * Math.Sqrt(1 - 0.2259 * 0.2259), Mass), Quaternion.CreateFromYawPitchRollGrad(100.638, 148.725, 54.669 ), "Harpalyke/Jupiter XXII"),            100),
                    new OrbitEx( new Orbit(new Kepler(0.14221925130, 0.14221925130 * Math.Sqrt(1 - 0.2435 * 0.2435), Mass), Quaternion.CreateFromYawPitchRollGrad(76.129, 149.828, 33.659  ), "Ananke/Jupiter XII"),                100),
                    new OrbitEx( new Orbit(new Kepler(0.15519385020, 0.15519385020 * Math.Sqrt(1 - 0.2461 * 0.2461), Mass), Quaternion.CreateFromYawPitchRollGrad(126.56, 168.026, 152.118 ), "Isonoe/Jupiter XXVI"),               100),
                    new OrbitEx( new Orbit(new Kepler(0.15560828870, 0.15560828870 * Math.Sqrt(1 - 0.2659 * 0.2659), Mass), Quaternion.CreateFromYawPitchRollGrad(2.668, 159.212, 336.042  ), "Erinome/Jupiter XXV"),               100),
                    new OrbitEx( new Orbit(new Kepler(0.15614973260, 0.15614973260 * Math.Sqrt(1 - 0.2516 * 0.2516), Mass), Quaternion.CreateFromYawPitchRollGrad(211.713, 160.215, 326.765), "Taygete/Jupiter XX"),                100),
                    new OrbitEx( new Orbit(new Kepler(0.15493983960, 0.15493983960 * Math.Sqrt(1 - 0.2512 * 0.2512), Mass), Quaternion.CreateFromYawPitchRollGrad(227.365, 167.733, 152.657), "Chaldene/Jupiter XXI"),              100),
                    new OrbitEx( new Orbit(new Kepler(0.15644385020, 0.15644385020 * Math.Sqrt(1 - 0.2533 * 0.2533), Mass), Quaternion.CreateFromYawPitchRollGrad(0.166, 166.287, 131.608  ), "Carme/Jupiter XI"),                  100),
                    new OrbitEx( new Orbit(new Kepler(0.15791443850, 0.15791443850 * Math.Sqrt(1 - 0.4090 * 0.4090), Mass), Quaternion.CreateFromYawPitchRollGrad(174.075, 138.021, 338.919), "Pasiphae/Jupiter VIII"),             100),
                    new OrbitEx( new Orbit(new Kepler(0.15764037430, 0.15764037430 * Math.Sqrt(1 - 0.2453 * 0.2453), Mass), Quaternion.CreateFromYawPitchRollGrad(232.978, 165.215, 52.607 ), "Kalyke/Jupiter XIII"),               100),
                    new OrbitEx( new Orbit(new Kepler(0.15913101600, 0.15913101600 * Math.Sqrt(1 - 0.4210 * 0.4210), Mass), Quaternion.CreateFromYawPitchRollGrad(313.167, 150.37, 317.211 ), "Megaclite/Jupiter XIX"),             100),
                    new OrbitEx( new Orbit(new Kepler(0.16002005350, 0.16002005350 * Math.Sqrt(1 - 0.2495 * 0.2495), Mass), Quaternion.CreateFromYawPitchRollGrad(356.497, 150.19, 332.196 ), "Sinope/Jupiter IX"),                 100),
                    new OrbitEx( new Orbit(new Kepler(0.16110962560, 0.16110962560 * Math.Sqrt(1 - 0.2827 * 0.2827), Mass), Quaternion.CreateFromYawPitchRollGrad(16.381, 138.004, 302.562 ), "Callirrhoe/Jupiter XVII"),           100),
                    new OrbitEx( new Orbit(new Kepler(0.08392379678, 0.08392379678 * Math.Sqrt(1 - 0.2484 * 0.2484), Mass), Quaternion.CreateFromYawPitchRollGrad(172.672, 25.851, 312.669 ), "S2000 J 11"),                        100),
                    new OrbitEx( new Orbit(new Kepler(0.16073529410, 0.16073529410 * Math.Sqrt(1 - 0.3168 * 0.3168), Mass), Quaternion.CreateFromYawPitchRollGrad(65.418, 149.551, 290.639 ), "Autonoe/Jupiter XXVIII/S2001 J 1"),  100),
                    new OrbitEx( new Orbit(new Kepler(0.13996657750, 0.13996657750 * Math.Sqrt(1 - 0.2286 * 0.2286), Mass), Quaternion.CreateFromYawPitchRollGrad(109.494, 150.1, 266.835  ), "Thyone/Jupiter XXIX/S2001 J 2"),     100),
                    new OrbitEx( new Orbit(new Kepler(0.14125000000, 0.14125000000 * Math.Sqrt(1 - 0.2096 * 0.2096), Mass), Quaternion.CreateFromYawPitchRollGrad(277.841, 147.712, 353.025), "Hermippe/Jupiter XXX/S2001 J 3"),    100),
                    new OrbitEx( new Orbit(new Kepler(0.15750668450, 0.15750668450 * Math.Sqrt(1 - 0.2714 * 0.2714), Mass), Quaternion.CreateFromYawPitchRollGrad(253.422, 146.42, 67.747  ), "S2003 J 23"),                        100),

                    //new OrbitEx( new Orbit(new Kepler(SemiMajorAxis, SemiMajorAxis * Math.Sqrt(1 - Eccentricity * Eccentricity), RootMass), Quaternion.CreateFromYawPitchRollGrad(ArgOfPericen, Inclination, AscendingNode)), 100),
                }
            );

            //init dists
            Dists = new List<List<double>>();
            for (int i = 0; i < Items.Count; i++)
                Dists.Add(new List<double>());                
        }

        public Orbits(string filename)
        {
            Load(filename);
        }

        //update time
        public void Update(double dt)
        {
            //move bodies
            for (int i = 0; i < Items.Count; i++)
                Items[i].Time += dt;

            TimeDelta += dt;
            while (TimeDelta > Core.CFG.TimeStep)
            {
                TimeDelta -= Core.CFG.TimeStep;
                Time += Core.CFG.TimeStep;

                //calc dists
                Vector3 from = Items[Current].Orbit.Time2Pos(Time);
                for (int i = 0; i < Items.Count; i++)
                {
                    Vector3 to = Items[i].Orbit.Time2Pos(Time);
                    double dist = (to - from).Length();
                    Dists[i].Add(dist);
                    while (Dists[i].Count > Core.CFG.DistHistory)
                        Dists[i].RemoveAt(0);
                }
            }
        }

        //load from xml file
        public void Load(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                return;

            if (Items != null) Items.Clear();
            if (Dists != null) Dists.Clear();

            //Items
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);

                XmlNode root = doc.DocumentElement;
                name = root.Attributes["Name"].Value;
                mass = double.Parse(root.Attributes["Mass"].Value);

                foreach (XmlNode child in root.SelectNodes("Child"))
                {
                    //read attrs from xml
                    string childName = child.Attributes["Name"].Value;
                    double childMass = double.Parse(child.Attributes["Mass"].Value);
                    double childA = double.Parse(child.Attributes["A"].Value);
                    double childArgOfPericen = double.Parse(child.Attributes["ArgOfPericen"].Value);
                    double childInclination = double.Parse(child.Attributes["Inclination"].Value);
                    double childAscendingNode = double.Parse(child.Attributes["AscendingNode"].Value);
                    double childMeanAnomaly = double.Parse(child.Attributes["MeanAnomaly"].Value);
                    double childB = childA; //circle by default
                    if (child.Attributes["B"] != null)
                        childB = double.Parse(child.Attributes["B"].Value);
                    else
                    {
                        double childE = double.Parse(child.Attributes["E"].Value);
                        childB = childA * Math.Sqrt(1 - childE * childE);
                    }

                    //add orbit
                    Items.Add(new OrbitEx(new Orbit(new Kepler(childA, childB, Mass + childMass), Quaternion.CreateFromYawPitchRollGrad(childArgOfPericen, childInclination, childAscendingNode), childName), 100));
                }
            }
            catch (Exception ex)
            {
                Logger.Err(ex);
            }

            //Dists
            Dists = new List<List<double>>();
            for (int i = 0; i < Items.Count; i++)
                Dists.Add(new List<double>());
        }

        //save to xml file
        public void Save(string filename)
        {
            //...
        }
    }
}
