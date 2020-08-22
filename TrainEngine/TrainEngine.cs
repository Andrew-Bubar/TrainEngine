using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace TrainEngine.TrainEngine {

    class Canvas : Form
    {
        public Canvas() { this.DoubleBuffered = true; }
    }
    public abstract class TrainEngine {

        private vector ScreenSize = new vector(512, 512);
        private string Title;
        private Canvas Window = null;
        private Thread gameLoopThread = null;

        private static List<Shape2D> AllShapes = new List<Shape2D>();
        private static List<Sprite2D> AllSprites = new List<Sprite2D>();

        public Color backgroundColor = Color.Purple;

        public vector CameraPosition = vector.zero();
        public float CameraAngle = 0f;

        public TrainEngine(vector ScreenSize, string Title) {

            Log.Info( "Train Engine started" );

            this.ScreenSize = ScreenSize; this.Title = Title; 
            
            Window = new Canvas();
            Window.Size = new Size((int)this.ScreenSize.x, (int)this.ScreenSize.y);
            Window.Text = this.Title;
            Window.Paint += Renderer;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUp;

            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.Start();

            Application.Run(Window);
        }

        private void Window_KeyUp ( object sender, KeyEventArgs e ) { GetKeyUp( e ); }
        private void Window_KeyDown ( object sender, KeyEventArgs e ) { GetKeyDown( e ); }

        public static void GetShapes2D(Shape2D shape) { AllShapes.Add(shape); }
        public static void UngetShapes2D(Shape2D shape) { AllShapes.Remove(shape); }
        public static void GetSprites2D ( Sprite2D sprite ) { AllSprites.Add( sprite ); }
        public static void UngetSprites2D ( Sprite2D sprite ) { AllSprites.Remove( sprite ); }

        void GameLoop() {

            Load();

            while (gameLoopThread.IsAlive) {

                try {
                    Draw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    Update();
                    Thread.Sleep(1);
                }
                catch {
                    Log.Error( "Cant find the window. . . " );
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e) {

            Graphics g = e.Graphics;

            g.Clear(backgroundColor);

            g.TranslateTransform( CameraPosition.x, CameraPosition.y );
            g.RotateTransform( CameraAngle );

            foreach (Shape2D s in AllShapes) { g.FillRectangle(new SolidBrush(Color.Red), s.Position.x, s.Position.y, s.Scale.x, s.Scale.y); }
            foreach(Sprite2D s in AllSprites) { g.DrawImage( s.Sprite, s.Position.x, s.Position.y, s.Scale.x, s.Scale.y ); }
        }

        public abstract void Load();
        public abstract void Update();
        public abstract void Draw();
        public abstract void GetKeyDown (KeyEventArgs Input);
        public abstract void GetKeyUp ( KeyEventArgs Input );
    }
}
