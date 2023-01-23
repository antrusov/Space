using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XnaGeometry;

namespace Space
{
    public class Orbit
    {
        public Kepler        Ellipse;     //эллипс орбиты
        public Quaternion    Orientation; //ориентация орбиты
        public string        Name;        //название орбиты 

        public Orbit(Kepler ellipse, Quaternion orientation, string name = "")
        {
            this.Ellipse     = ellipse;
            this.Orientation = orientation;
            this.Name        = name;
        }

        public Vector3 Time2Pos(double t)
        {
            Vector2 p = Ellipse.Time2Pos(t);
            return Orientation.Rotate(new Vector3(p.X - Ellipse.C, p.Y, 0));
        }        
    }
}
