using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        Circle k = new Circle();
        List<Circle> Snake = new List<Circle>();
        Random foodRand = new Random();
        Circle food = new Circle();
        Settings Rond = new Settings();
        public Form1()
        {
            InitializeComponent();
            
        }
        

        private void Canvas_Click(object sender, EventArgs e)
        {

        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Snake.Count; i++) { 
            e.Graphics.FillEllipse(Brushes.Black, new Rectangle(Snake[i].X * Rond.Witdh, Snake[i].Y* Rond.Height, 16, 16));
            }
            if (button1.Enabled == false)
            {
                e.Graphics.FillEllipse(Brushes.Red, new Rectangle(food.X * Rond.Witdh, food.Y * Rond.Height, 16, 16));
            }
            if (Rond.pm == false) {
                e.Graphics.Clear(Color.White);
            }
        }

      

        private void Canvas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                Settings.directions = "Down";
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                Settings.directions = "right";
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                Settings.directions = "left";
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                Settings.directions = "up";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i=Snake.Count-1;i>0;i--)
            {
                Snake[i].X = Snake[i - 1].X;
                Snake[i].Y = Snake[i - 1].Y;
            }
            if (Settings.directions == "right") { 
                Snake[0].X++; 
            }
            if (Settings.directions == "Down") {
                Snake[0].Y++;
            }
            if (Settings.directions=="up") {
                Snake[0].Y--;
            }
            if (Settings.directions == "left") {
                Snake[0].X--;
            }
            
            if (CheckBody(Snake[0].X,Snake[0].Y)==true)
            {
                 //MessageBox.Show(Snake[0].X.ToString()+"//");
                 GameOver();
                 Canvas.Invalidate();
            }           
            /*for (int h=0;h<Snake.Count;h++) {
                label3.Text += "//"+Snake[h].X.ToString();    
            }*/                    
            if ((Snake[0].X * Rond.Witdh) +(Rond.Witdh / 2)>Canvas.Width || (Snake[0].X * Rond.Witdh) + (Rond.Witdh / 2) < 0 || (Snake[0].Y * Rond.Witdh) +(Rond.Witdh / 2)>Canvas.Height || (Snake[0].Y * Rond.Witdh) + (Rond.Witdh / 2) < 0)
            {// SettingsWitdh/2 correspond au rayon du cercle 
                GameOver();
                Canvas.Invalidate();
            }
            if (VerifEat(Snake[0].X, Snake[0].Y, food.X, food.Y) == true) {
                Circle Gros = new Circle();
                Gros.X = Snake[Snake.Count - 1].X;
                Gros.Y = Snake[Snake.Count - 1].Y;
                Snake.Add(Gros);
                Appears();
            }
            Canvas.Invalidate();
        }
        public Boolean CheckBody(int x,int y) {
            for (int i=1;i<Snake.Count;i++) {
                if (Snake[i].X == x && Snake[i].Y==y) {
                    return true; 
                }
            }
            return false;
        }
        private void GameOver() {
            Rond.pm = false;
            timer1.Stop();
            MessageBox.Show("fini, score : "+(Snake.Count-1));     
        }
        public Boolean VerifEat(int x1,int y1,int x2,int y2) {
            if (x1 == x2 && y1 == y2)
            {
                return true;
            }
            else {
                return false;
            }
        }
        public void Appears() {         
            int x=foodRand.Next(0,(int)(Canvas.Width/16)-1);
            int y=foodRand.Next(0,(int)(Canvas.Height/16)-1);
            food.X = x;
            food.Y = y;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Snake.Add(k);
            Appears();
            timer1.Start();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
