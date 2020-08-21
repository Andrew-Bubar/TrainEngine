using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEngine.TrainEngine
{
    public class vector {

        public float x { get; set; }
        public float y { get; set; }

        public vector() { x = zero().x; y = zero().y; }

        public vector(float x, float y) { this.x = x; this.y = y; }


        /// <summary>
        /// returns a vector as zero
        /// </summary>
        /// <returns></returns>
        public static vector zero() { return new vector(0, 0); }
    }
}
