using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWheel
{
    public partial class Form1 : Form
    {

        int sirkaP;
        int vyskaP;
        int velikost = 300;
        int velikost2 = 330;
        int poziceX = 135;
        int poziceY = 300;

        double rotace;
        double radiany;

        int delkaZony = 120;
        int castNaKruhu;

        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            sirkaP = panel1.Width;
            vyskaP = panel1.Height;

            rotace = 90;
            radiany = rotace * (Math.PI / 180);

            Graphics g = panel1.CreateGraphics();
            g.DrawEllipse(Pens.Black, (sirkaP/2)-(velikost/2), (vyskaP / 2) - (velikost / 2), velikost, velikost);
            g.DrawEllipse(Pens.Black, (sirkaP/2)-(velikost2/2), (vyskaP / 2) - (velikost2 / 2), velikost2, velikost2);

            nakresliCaru(g);
            nahodnaPoziceZony(g);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (poziceX >= 135 && poziceX <= 300 && poziceY <= 300 && poziceY >= 135)
            {
                poziceX= (int)(Math.Cos(radiany) * ((double)poziceX - (double)velikost2) - (double)Math.Sin(radiany) * ((double)poziceY - velikost2) + (double)velikost2);
                
            }
           

            panel1.Refresh();
        }

        private void nakresliCaru(Graphics g)
        {

            g.DrawLine(Pens.Blue, sirkaP/2, vyskaP/2, poziceX, poziceY);
        }

        private void nahodnaPoziceZony(Graphics g)
        {
            g.DrawArc(Pens.Red, 150, 150, 300, 300, castNaKruhu, delkaZony);

            g.DrawArc(Pens.Red, 135, 135, 330, 330, castNaKruhu, delkaZony);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            castNaKruhu = rnd.Next(0, 361);
        }
    }
}
