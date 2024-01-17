using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project1
{
    public partial class game : Form
    {
        GameArena gameArena = new GameArena();

        public game(string img1, string img2, int a, int b, int c, int d)
        {
            InitializeComponent();
            if (img1 == "Warrior")
            {
                pictureBox4.Visible = false;
            }

            if (img2 == "Warrior")
            {
                pictureBox5.Visible = false;
            }

            gameArena.charachter1 = new Warrior();
                gameArena.charachter1.Health = a;
                gameArena.charachter1.AttackPower = b;

                gameArena.charachter2 = new Warrior();
                gameArena.charachter2.Health = c;
                gameArena.charachter2.AttackPower = d;

            label3.Text = a.ToString();
            label4.Text = c.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameArena.charachter1.attack(gameArena.charachter2);
            label4.Text = gameArena.charachter2.Health.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameArena.charachter2.attack(gameArena.charachter1);
            label3.Text = gameArena.charachter1.Health.ToString();
        }
    }
}
