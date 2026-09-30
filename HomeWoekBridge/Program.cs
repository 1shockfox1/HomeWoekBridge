using System;

// 1. Интерфейс способности
interface IAbility
{
    void Use(string characterName);
}

// 2. Реализации способностей
class PhysicalAttack : IAbility
{
    public void Use(string name) => Console.WriteLine($"{name} использует физическую атаку!");
}

class FireAttack : IAbility
{
    public void Use(string name) => Console.WriteLine($"{name} использует огненное заклинание!");
}

class IceAttack : IAbility
{
    public void Use(string name) => Console.WriteLine($"{name} использует ледяное заклинание!");
}

// 3. Базовый класс персонажа
abstract class Character
{
    protected IAbility ability;
    protected string name;

    protected Character(string name, IAbility ability)
    {
        this.name = name;
        this.ability = ability;
    }

    public void UseAbility() => ability.Use(name);
}

// 4. Персонажи
class Warrior : Character
{
    public Warrior(IAbility ability) : 
        base("Воин", ability) { }
}

class Mage : Character
{
    public Mage(IAbility ability) : 
        base("Маг", ability) { }
}

class Archer : Character
{
    public Archer(IAbility ability) :
        base("Лучник", ability) { }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== RPG ===\n");

        var physical = new PhysicalAttack();
        var fire = new FireAttack();
        var ice = new IceAttack();

        new Warrior(physical).UseAbility();
        new Warrior(fire).UseAbility();
        new Mage(fire).UseAbility();
        new Mage(ice).UseAbility();
        new Archer(physical).UseAbility();
        new Archer(ice).UseAbility();
    }
}