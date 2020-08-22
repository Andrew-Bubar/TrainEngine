using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainEngine;
using TrainEngine.TrainEngine;

namespace TrainEngine
{
    class TestGame : TrainEngine.TrainEngine {

        public TestGame() : base(new vector(615,615), "testing game") {  }

        bool left;
        bool right;
        bool up;
        bool down;

        Sprite2D player;
        Sprite2D player2;

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
            player2 = new Sprite2D( new vector( 100, 100 ), new vector( 56, 56 ), "Enemies/png/64x64/Spike_Up", "player" );

            for (int i = 0; i < map.GetLength(1); i++ ) {

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


        public override void Update() {

            if ( up ) {
                player.Position.y -= 1f;
            }
            if ( down ) {
                player.Position.y += 1f;
            }
            if ( left ) {
                player.Position.x -= 1f;
            }
            if ( right ) {
                player.Position.x += 1f;
            }

            if (player.IsColliding(player, player2)) ;
        }

        public override void GetKeyDown ( KeyEventArgs Input ) {

            if(Input.KeyCode == Keys.W ) { up = true; }
            if ( Input.KeyCode == Keys.S ) { down = true; }
            if ( Input.KeyCode == Keys.A ) { left = true; }
            if ( Input.KeyCode == Keys.D ) { right = true; }
        }

        public override void GetKeyUp ( KeyEventArgs Input ) {

            if ( Input.KeyCode == Keys.W ) { up = false; }
            if ( Input.KeyCode == Keys.S ) { down = false; }
            if ( Input.KeyCode == Keys.A ) { left = false; }
            if ( Input.KeyCode == Keys.D ) { right = false; }
        }
    }
}
