using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainEngine;
using TrainEngine.TrainEngine;

namespace TrainEngine
{
    class TestGame : TrainEngine.TrainEngine {

        public TestGame() : base(new vector(615,615), "testing game") {  }

        Sprite2D player;

        string[,] map = {
            
            { ".", ".", ".", ".", ".", ".", ".", ".", "." , ".", "." },
            { ".", ".", ".", ".", ".", ".", ".", ".", "." , ".", "." },
            { ".", ".", ".", ".", ".", ".", ".", ".", "." , ".", "." },
            { ".", ".", ".", ".", ".", "g", "g", "g", "g" , ".", "." },
            { ".", ".", ".", ".", "g", ".", ".", ".", "." , ".", "." },
            { ".", ".", "g", "g", "g", ".", ".", ".", "." , ".", "." },
        };

        public override void Load()
        {
            backgroundColor = Color.Blue;

            player = new Sprite2D( new vector( 10, 10 ), new vector( 56, 56 ), "Enemies/png/64x64/Spike_Up", "player");

            for(int i = 0; i < map.GetLength(1); i++ ) {

                for (int j = 0; j < map.GetLength(0); j++ ) {

                    if (map[j, i] == "g") { 

                        new Sprite2D( new vector( i * 50, j * 50 ), new vector( 50, 50 ), "Tiles/png/128x128/Grass", "ground"); 
                    }
                }
            }
        }

        public override void Draw ()
        {
            
        }


        public override void Update()
        {
        }
    }
}
