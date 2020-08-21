using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEngine.TrainEngine
{
    public class Shape2D {

        public vector Position = null;
        public vector Scale = null;
        public string Tag = "";

        public Shape2D(vector Position, vector Scale, string Tag) { this.Scale = Scale; this.Position = Position; this.Tag = Tag; Log.Info($"[SHAPE2D] ({Tag})  -  Has been Made "); TrainEngine.GetShapes2D(this);  }

        public void DestroySelf() { TrainEngine.UngetShapes2D(this); Log.Info( $"[SHAPE2D] ({Tag})  -  Has been removed " );  }
    }
}
