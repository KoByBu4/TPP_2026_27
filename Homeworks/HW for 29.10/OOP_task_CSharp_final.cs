class Character
{
    private string name;
    private int hp;
    private int power;
    private static int count = 0;

    Character(string name, int hp, int power)
    {
        this.name = name;
        this.hp = hp;
        this.power = power;
        count++;
    }

    public void Attack(Character target)
    {
        Console.WriteLine(name + "атакует" + target.name);
        target.hp -= power;
    }

    public GetStatus()
    {
        Console.WriteLine(name + ": " + hp);
    }

    public static int HowMany()
    {
        return count;
    }

    public static bool IsValidStats(int hp, int power)
    {
        return hp > 0 && power > 0;
    }
}

class Player : Character
{
    public Player(string name, int hp, int power) : base(name, hp, power)
    {

    }
}

class Enemy : Character
{
    public Enemy(string name, int hp, int power) : base(name, hp, power)
    {
    }
}