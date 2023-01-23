using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Space;
using XnaGeometry;

namespace SpaceWin
{
    public class OrbitPair
    {

        #region [ private vars]

        double time;
        double distance;

        #endregion

        #region [ public properties ]

        //base properties
        public Orbit OrbitA;
        public Orbit OrbitB;

        //time depended
        public double  Time { get { return time; } set { SetTime(value); } }
        public double  Distance { get { return distance; } }
        public Vector3 AB;
        public Vector3 PositionA;
        public Vector3 PositionB;

        #endregion

        //ctor
        public OrbitPair(Orbit A, Orbit B, double time = 0)
        {
            //fill base vars
            OrbitA = A;
            OrbitB = B;
            
            //fill time dependet vars
            SetTime(time);
        }

        void SetTime(double time)
        {
            this.time = time;

            PositionA = OrbitA.Time2Pos(time);
            PositionB = OrbitB.Time2Pos(time);
            AB = PositionB - PositionA;
            distance = AB.Length();
        }
    }
}
