using System;
using System.Reflection.Metadata.Ecma335;
class Character
{
    private string name;
    private int hp;
    private int power;
    private static int count = 0;

    public string Name => name;

    public string Hp => hp;

    Character(string name, int hp, int power)
    {
        this.name = name;
        this.hp = hp;
        this.power = power;
        count++;
    }

    public virtual void Attack(Character target)
    {
        Console.WriteLine(name + "атакует" + target.name);
        target.TakeDamage(power);
    }
    
    public int TakeDamage(int damage)
    {
        return hp -= damage;
    }

    public static bool IsAlive()
    {
        return hp > 0;
    }

    public string ToString()
    {
        return $"{Name} (HP: {Hp})";
    }

    public override bool Equals(object? obj)
    {
        if(obj is Character other)
        {
            return this.name == other.name && this.hp == other.hp && this.power == other.power;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(name, hp, power);
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

    public override void Attack(Character target)
    {
        Console.WriteLine(name + "атакует" + target.name);
        target.TakeDamage(power);
    }
}

class Enemy : Character
{
    public override Enemy(string name, int hp, int power) : base(name, hp, power)
    {
    }

    public override void Attack(Character target)
    {
        Console.WriteLine(name + "атакует" + target.name);
        target.TakeDamage(power);
    }
}

class Program
{
    public void Main()
    {
        Player player = new("Игрок", 10, 3);
        Enemy enemy = new("Враг", 8, 2); 

        Console.WriteLine($"Создан персонаж: {player.Name} (HP: {player.Hp}, Урон: {player.power})");
        Console.WriteLine($"Создан персонаж: {enemy.Name} (HP: {enemy.Hp}, Урон: {enemy.power})");

        Console.WriteLine("\nБой начинается\n");
        
        while(player.IsAlive() && enemy.IsAlive())
        {
            player.Attack(enemy);
            Console.WriteLine($"{enemy.Name}: {enemy.Hp} HP\n");

            if(!enemy.IsAlive())
            {
                break;
            }

            enemy.Attack(player);
            Console.WriteLine($"{player.Name}: {player.Hp} HP\n");
        }

        if(!enemy.IsAlive())
        {
            Console.WriteLine("Враг побеждён!");
            Console.WriteLine("Игрок одержал победу!");
        }
        else
        {
            Console.WriteLine("Игрок побеждён!");
            Console.WriteLine("Враг одержал победу!");
        }
    }
}