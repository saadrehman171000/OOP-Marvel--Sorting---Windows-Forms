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

class Warrior : Character {
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
            if(target.AttackPower <= 0)
            {
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
        if(arrowsRemaining < 1)
        {
            Console.WriteLine("No arrows left\n");
            return;
        }
        if (target.AttackPower >= 0)
        {
            target.Health -= this.AttackPower;
            arrowsRemaining -=1;
            if (target.Health < 0)
                target.Health = 0;
            Console.WriteLine($"Hit Attack of {this.Name}: {target.AttackPower}\nRemaining power of opponent({target.Name}): {target.Health}\nRemaining arrows: {this.arrowsRemaining}\n\n");
            if (target.AttackPower <= 0)
            {
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
    private Character charachter1, charachter2;
    public void playGame() {
        charachter1 = new Archer("Jon", "Male", 80, 60, 150, 150);
        charachter2 = new Warrior("Michel", "Male", 100, 90, "Sword", 70);
        charachter1.ToString();
        charachter2.ToString();
        charachter1.attack(charachter2);
        charachter2.attack(charachter1);
    }

}

class Program
{

    static void Main()
    {
        GameArena ga = new GameArena();
        ga.playGame();
    }
}