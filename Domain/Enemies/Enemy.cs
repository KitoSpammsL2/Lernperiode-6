namespace Solo_Leveling.Domain.Enemies;

public class Enemy
{
    public string Name { get; }
    public int HP { get; set; }
    public int MinDamage { get; }
    public int MaxDamage { get; }
    public int GoldReward { get; }

    public Enemy(string name, int hp, int minDamage, int maxDamage, int goldReward)
    {
        Name = name;
        HP = hp;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        GoldReward = goldReward;

        

    }

    public void ShowInfo()
    {
        Console.WriteLine($"{Name,-15} HP:{HP,-3}  DMG:{MinDamage}-{MaxDamage}  Gold:{GoldReward}");
    }


    // ---------- F-Rang ----------
    public static Enemy CreateGoblin() => new Enemy("Goblin", 22, 2, 4, 4);
    public static Enemy CreateWolf() => new Enemy("Wolf", 26, 2, 5, 6);
    public static Enemy CreateGoblinChief() => new Enemy("Goblin-Chef (Boss)", 45, 4, 7, 12);

    // ---------- E-Rang ----------
    public static Enemy CreateStoneGolem() => new Enemy("Stein-Golem", 35, 3, 6, 9);
    public static Enemy CreateGoblinAssassin() => new Enemy("Goblin-Assassine", 28, 3, 7, 11);
    public static Enemy CreateMiniGolem() => new Enemy("Mini-Golem (Boss)", 60, 5, 8, 25);

    // ---------- D-Rang ----------
    public static Enemy CreateOrc() => new Enemy("Ork", 48, 4, 8, 14);
    public static Enemy CreateCaveWolf() => new Enemy("Höhlen-Wolf", 44, 4, 7, 13);
    public static Enemy CreateOrcChief() => new Enemy("Ork-Häuptling (Boss)", 80, 7, 10, 40);

    // ---------- C-Rang ----------
    public static Enemy CreateLizardman() => new Enemy("Lizardman", 60, 6, 9, 20);
    public static Enemy CreateKobold() => new Enemy("Kobold", 56, 5, 8, 18);
    public static Enemy CreateLizardChief() => new Enemy("Lizardman-Chief (Boss)", 100, 9, 12, 70);

    // ---------- B-Rang ----------
    public static Enemy CreateOgre() => new Enemy("Oger", 75, 7, 11, 28);
    public static Enemy CreateMinotaur() => new Enemy("Minotaurus", 85, 8, 12, 32);
    public static Enemy CreateMinotaurBoss() => new Enemy("Minotaurus-Boss", 120, 11, 14, 110);

    // ---------- A-Rang ----------
    public static Enemy CreateSnowElf() => new Enemy("Schnee-Elfe", 95, 9, 13, 42);
    public static Enemy CreateIceGolem() => new Enemy("Eis-Golem", 110, 10, 14, 48);
    public static Enemy CreateSnowElfKing() => new Enemy("Schnee-Elfen-König (Boss)", 160, 13, 16, 180);

    // ---------- S-Rang ----------
    public static Enemy CreateAntSoldier() => new Enemy("Ameisen-Soldat", 120, 12, 16, 65);
    public static Enemy CreateAntWarrior() => new Enemy("Ameisen-Krieger", 140, 13, 18, 85);
    public static Enemy CreateAntKing() => new Enemy("Ameisen-König (Boss)", 220, 16, 20, 300);


}
