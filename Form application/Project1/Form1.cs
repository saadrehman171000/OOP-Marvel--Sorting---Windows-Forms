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
    abstract class Character
    {
        private string name;
        private string gender;
        private int health;
        private int attackPower;

        public Character()
        {
            this.name = "";
            this.gender = "";
            this.health = 0;
            this.attackPower = 0;
        }

        public Character(string name, string gender, int health, int attackPower)
        {
            this.name = name;
            this.gender = gender;
            this.health = health;
            this.attackPower = attackPower;
        }

        public abstract void specialAbility();
        public abstract void takeDamage(int damage);
        public abstract void attack(Character target);
        public abstract void ToString();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int Health
        {
            get { return health; }
            set
            {
                health = value;
            }
        }

        public int AttackPower
        {
            get { return attackPower; }
            set
            {
                attackPower = value;
            }
        }
    }

    class Warrior : Character
    {
        private string weaponType;
        private int rageLevel;

        public Warrior()
        {
            this.weaponType = "";
            this.rageLevel = 0;
        }
        public Warrior(string name, string gender, int health, int attackPower, string weaponType, int rageLevel)
            : base(name, gender, health, attackPower)
        {
            this.weaponType = weaponType;
            this.rageLevel = rageLevel;
        }

        public override void attack(Character target)
        {
            if (target.AttackPower >= 0)
            {
                target.Health -= this.AttackPower;
                if (target.Health < 0)
                    target.Health = 0;
                Console.WriteLine($"Hit Attack of {this.Name}: {target.AttackPower}\nRemaining power of opponent({target.Name}):  {target.Health} \n\n");
                if (target.AttackPower <= 0)
                {
                    target.AttackPower = 0;
                    Console.WriteLine("Target died\n");
                }
            }
            else
            {
                Console.WriteLine("Target died\n");
            }
        }
        public override void takeDamage(int damage)
        {
            if (Health > 0)
            {
                Health -= damage;
                Console.WriteLine($"Hit Damge: {Health}\nRemaining health: {this.Health}");
            }
            else
            {
                Console.WriteLine("You died");
            }
        }
        public override void specialAbility()
        {
            Console.WriteLine("Speciality: Warrior\n\n");
        }
        public override void ToString()
        {
            Console.WriteLine($"Player name: {Name}\nPlayer gender: {Gender}\nPlayer health: {Health}\nPlayer attack power: {AttackPower}\nWeapon type: {WeaponType}\nRage level: {RageLevel}\n\nSpeciality: Warrior\n\n");
        }
        public string WeaponType
        {
            get { return weaponType; }
            set { weaponType = value; }
        }

        public int RageLevel
        {
            get { return rageLevel; }
            set { rageLevel = value; }
        }
    }

    class Archer : Character
    {
        private int quiverSize;
        private int arrowsRemaining;

        public Archer()
        {
            this.quiverSize = 0;
            this.arrowsRemaining = 0;
        }
        public Archer(string name, string gender, int health, int attackPower, int quiverSize, int arrowsRemaining)
            : base(name, gender, health, attackPower)
        {
            this.quiverSize = quiverSize;
            this.arrowsRemaining = arrowsRemaining;
        }
        public override void attack(Character target)
        {
            if (arrowsRemaining < 1)
            {
                Console.WriteLine("No arrows left\n");
                return;
            }
            if (target.AttackPower >= 0)
            {
                target.Health -= this.AttackPower;
                arrowsRemaining -= 1;
                if (target.Health < 0)
                    target.Health = 0;
                Console.WriteLine($"Hit Attack of {this.Name}: {target.AttackPower}\nRemaining power of opponent({target.Name}): {target.Health}\nRemaining arrows: {this.arrowsRemaining}\n\n");
                if (target.AttackPower <= 0)
                {
                    target.AttackPower = 0;
                    Console.WriteLine("Target died\n");
                }
            }
            else
            {
                Console.WriteLine("Target died\n");
            }
        }
        public override void takeDamage(int damage)
        {
            if (Health > 0)
            {
                Health -= damage;
                Console.WriteLine($"Hit Damge: {Health}\nRemaining health: {this.Health}");
            }
            else
            {
                Console.WriteLine("You died");
            }
        }
        public override void specialAbility()
        {
            Console.WriteLine("Speciality: Archer\n\n");
        }
        public override void ToString()
        {
            Console.WriteLine($"Player name: {Name}\nPlayer gender: {Gender}\nPlayer health: {Health}\nPlayer attack power: {AttackPower}\nQuiver size: {QuiverSize}\nArrow remaining: {ArrowsRemaining}\n\nSpeciality: Archer\n\n");
        }
        public int QuiverSize
        {
            get { return quiverSize; }
        }

        public int ArrowsRemaining
        {
            get { return arrowsRemaining; }
            set { arrowsRemaining = value; }
        }
    }

    class ArcherCommander : Archer
    {
        private int totalUnderPlatoon;

        public ArcherCommander()
        {
            this.totalUnderPlatoon = 0;
        }
        public ArcherCommander(string name, string gender, int health, int attackPower, int quiverSize, int arrowsRemaining, int totalUnderPlatoon)
            : base(name, gender, health, attackPower, quiverSize, arrowsRemaining)
        {
            this.totalUnderPlatoon = totalUnderPlatoon;
        }
        public override void attack(Character target)
        {
            if (ArrowsRemaining < 1)
            {
                Console.WriteLine("No arrows left\n");
                return;
            }
            if (target.AttackPower >= 0)
            {
                target.Health -= this.AttackPower;
                ArrowsRemaining -= 1;
                if (target.Health < 0)
                    target.Health = 0;
                Console.WriteLine($"Hit Attack of {this.Name}: {target.AttackPower}\nRemaining power of opponent({target.Name}): {target.Health}\nRemaining arrows: {this.ArrowsRemaining}\n\n");
                if (target.AttackPower <= 0)
                {
                    target.AttackPower = 0;
                    Console.WriteLine("Target died\n");
                }
            }
            else
            {
                Console.WriteLine("Target died\n");
            }
        }
        public override void takeDamage(int damage)
        {
            if (Health > 0)
            {
                Health -= damage;
                Console.WriteLine($"Hit Damge: {Health}\nRemaining health: {this.Health}");
            }
            else
            {
                Console.WriteLine("You died");
            }
        }
        public override void specialAbility()
        {
            Console.WriteLine("Speciality: ArcherCommander\n\n");
        }
        public override void ToString()
        {
            Console.WriteLine($"Player name: {Name}\nPlayer gender: {Gender}\nPlayer health: {Health}\nPlayer attack power: {AttackPower}\nQuiver size: {QuiverSize}\nArrow remaining: {ArrowsRemaining}\nTotal under platoon: {TotalUnderPlatoon}\n\nSpeciality: ArcherCommander\n\n");
        }
        public int TotalUnderPlatoon
        {
            get { return totalUnderPlatoon; }
        }
    }

    class GameArena
    {
        public Character charachter1, charachter2;
        public void playGame()
        {
            charachter1 = new Archer("Jon", "Male", 80, 60, 150, 150);
            charachter2 = new Warrior("Michel", "Male", 100, 90, "Sword", 70);
            charachter1.ToString();
            charachter2.ToString();
            charachter1.attack(charachter2);
            charachter2.attack(charachter1);
        }

    }
    public partial class Form1 : Form
    {
    GameArena ga = new GameArena();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Character" || comboBox4.Text == "Character")
            {
                MessageBox.Show("Please select both characters.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else if (!int.TryParse(textBox3.Text, out _))
            {
                MessageBox.Show("Please enter valid inputs of character 1.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox3.Clear();
                textBox3.Focus();
                return;
            }
            else if(!int.TryParse(textBox4.Text, out _))
            {
                MessageBox.Show("Please enter valid inputs of character 1.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox4.Clear();
                textBox4.Focus();
                return;
            }
            else if (textBox6.Text != "" && !int.TryParse(textBox6.Text, out _))
            {
                MessageBox.Show("Please enter valid inputs of character 1.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox6.Clear();
                textBox6.Focus();
                return;
            }
            if (!int.TryParse(textBox11.Text, out _))
            {
                MessageBox.Show("Please enter valid inputs of character 2.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox11.Clear();
                textBox11.Focus();
            }
            else if (!int.TryParse(textBox10.Text, out _))
            {

                MessageBox.Show("Please enter valid inputs of character 2.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBox10.Clear();
                textBox10.Focus();
            }
            
            else {
                int a = int.Parse(textBox3.Text);
                int b = int.Parse(textBox4.Text);

                int c = int.Parse(textBox11.Text);

                int d = int.Parse(textBox10.Text);

                game g = new game(comboBox1.Text, comboBox4.Text, a, b, c, d);
                g.Show();
            }
            
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox5.Visible = true;
            textBox6.Visible = true;
                comboBox1.Enabled = false;
            if (comboBox1.SelectedIndex == 0)
            {

                textBox5.Text = "Weapon Type";
                textBox6.Text = "Rage Level";
            }
            else if (comboBox1.SelectedIndex == 1)
            {

                textBox5.Text = "Quiver size";
                textBox6.Text = "Arrows left";
            }else if(comboBox1.SelectedIndex == 2)
            {

                textBox5.Text = "Quiver size";
                textBox6.Text = "Arrows left";
                textBox7.Visible = true;
                textBox7.Text = "Total Under Platoon";
            }
        }
        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox9.Visible = true;
            textBox8.Visible = true;
            comboBox4.Enabled = false;
            if (comboBox4.SelectedIndex == 0)
            {

                textBox9.Text = "Weapon Type";
                textBox8.Text = "Rage Level";
            }
            else if (comboBox4.SelectedIndex == 1)
            {

                textBox9.Text = "Quiver size";
                textBox8.Text = "Arrows left";
            }
            else if (comboBox4.SelectedIndex == 2)
            {

                textBox9.Text = "Quiver size";
                textBox8.Text = "Arrows left";
                textBox2.Visible = true;
                textBox7.Text = "Total Under Platoon";
            }
        }
    }
}
