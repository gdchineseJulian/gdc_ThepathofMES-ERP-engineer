using System;

class Game
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Game start!\n");

        // 使用建構子給予屬性初始值
        Character hero = new Character("亞瑟", "戰士", 100, 25);
        Character monster = new Character("哥布林", "怪獸", 50, 10);

        // 亞瑟攻擊哥布林（傳入整個 monster 物件）
        hero.Attack(monster);
    }
}

class Character
{
    // 屬性 (Properties)
    public string Name { get; set; }
    public string ClassType { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public bool IsAlive { get; set; }

    // 建構子 (Constructor)：建立物件時設定初始資料
    public Character(string name, string classType, int health, int attackPower)
    {
        Name = name;
        ClassType = classType;
        Health = health;
        AttackPower = attackPower;
        IsAlive = true;
    }

    // 攻擊方法：接受另一個 Character 物件作為目標
    public void Attack(Character target)
    {
        Console.WriteLine($"{Name} 攻擊了 {target.Name}！");
        // 讓目標物件呼叫自己的 TakeDamage 方法
        target.TakeDamage(AttackPower);
    }

    // 受傷方法：處理自身的血量扣減與狀態判定
    public void TakeDamage(int damage)
    {
        Health -= damage; // 扣減「自己」的血量
        Console.WriteLine($"{Name} 受到了 {damage} 點傷害，剩餘血量：{Health}");

        if (Health <= 0)
        {
            Health = 0;
            IsAlive = false; // bool 填寫 false
            Console.WriteLine($"{Name} 倒下了！");
        }
    }
}
