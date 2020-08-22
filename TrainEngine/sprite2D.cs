﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Remoting.Messaging;

namespace TrainEngine.TrainEngine
{
    public class Sprite2D
    {
        public vector Position = null;
        public vector Scale = null;
        public string Directory = "";
        public string Tag = "";
        public Bitmap Sprite = null;

        public Sprite2D ( vector Position, vector Scale, string Directory, string Tag) { 

            this.Scale = Scale; this.Position = Position; this.Directory = Directory; this.Tag = Tag;

            Image tmp = Image.FromFile($"Assets/Sprites/{Directory}.png");
            Bitmap sprite = new Bitmap(tmp,(int) this.Scale.x, (int) this.Scale.y);
            Sprite = sprite;

            Log.Info( $"[SPRITE2D] ({Tag})  -  Has been Made " ); TrainEngine.GetSprites2D( this ); 
        }

        public bool IsColliding(Sprite2D a, Sprite2D b )
        {
            if(a.Position.x <= b.Position.x &&
                a.Scale.x >= b.Scale.x &&
                a.Position.y <= b.Position.y &&
                a.Scale.y >= b.Scale.y ) { return true; }

            return false;
        } 

        public void DestroySelf () { TrainEngine.UngetSprites2D( this ); Log.Info( $"[SPRITE2D] ({Tag})  -  Has been removed " ); }
    }
}
