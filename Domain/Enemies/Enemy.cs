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
    public static Enemy CreateGoblin() => new Enemy("Goblin", 20, 1, 3, 5);
    public static Enemy CreateWolf() => new Enemy("Wolf", 25, 2, 4, 7);
    public static Enemy CreateGoblinChief() => new Enemy("Goblin-Chef (Boss)", 35, 3, 6, 18);

    // ---------- E-Rang ----------
    public static Enemy CreateStoneGolem() => new Enemy("Stein-Golem", 32, 3, 5, 10);
    public static Enemy CreateGoblinAssassin() => new Enemy("Goblin-Assassine", 22, 2, 5, 9);
    public static Enemy CreateMiniGolem() => new Enemy("Mini-Golem (Boss)", 45, 4, 7, 22);

    // ---------- D-Rang ----------
    public static Enemy CreateOrc() => new Enemy("Ork", 40, 3, 6, 12);
    public static Enemy CreateCaveWolf() => new Enemy("Höhlen-Wolf", 38, 3, 5, 11);
    public static Enemy CreateOrcChief() => new Enemy("Ork-Häuptling (Boss)", 60, 5, 8, 25);

    // ---------- C-Rang ----------
    public static Enemy CreateLizardman() => new Enemy("Lizardman", 50, 4, 7, 15);
    public static Enemy CreateKobold() => new Enemy("Kobold", 48, 3, 6, 14);
    public static Enemy CreateLizardChief() => new Enemy("Lizardman-Chief (Boss)", 75, 6, 9, 30);

    // ---------- B-Rang ----------
    public static Enemy CreateOgre() => new Enemy("Oger", 65, 5, 8, 20);
    public static Enemy CreateMinotaur() => new Enemy("Minotaurus", 70, 6, 9, 22);
    public static Enemy CreateMinotaurBoss() => new Enemy("Minotaurus-Boss", 90, 7, 10, 40);

    // ---------- A-Rang ----------
    public static Enemy CreateSnowElf() => new Enemy("Schnee-Elfe", 80, 6, 9, 28);
    public static Enemy CreateIceGolem() => new Enemy("Eis-Golem", 85, 7, 10, 30);
    public static Enemy CreateSnowElfKing() => new Enemy("Schnee-Elfen-König (Boss)", 110, 8, 11, 55);

    // ---------- S-Rang ----------
    public static Enemy CreateAntSoldier() => new Enemy("Ameisen-Soldat", 95, 8, 12, 35);
    public static Enemy CreateAntWarrior() => new Enemy("Ameisen-Krieger", 110, 9, 13, 40);
    public static Enemy CreateAntKing() => new Enemy("Ameisen-König (Boss)", 150, 12, 15, 80);


}
