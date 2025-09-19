using Solo_Leveling.Common;
using Solo_Leveling.Domain;
using Solo_Leveling.Domain.Enemies;

namespace Solo_Leveling.Systems;

public static class DungeonSystem
{
    private static readonly Random Rng = new();

    // erstellt nur die Gegnerfolge für einen Run (noch kein Kampf)
    public static List<Enemy> CreateRun(DungeonDifficulty diff)
    {
        // wie viele normale Gegner pro Rang (Boss kommt später)
        int count = diff switch
        {
            DungeonDifficulty.F => 2,
            DungeonDifficulty.E => 3,
            DungeonDifficulty.D => 3,
            DungeonDifficulty.C => 4,
            DungeonDifficulty.B => 4,
            DungeonDifficulty.A => 5,
            DungeonDifficulty.S => 5,
            _ => 2
        };

        // Quelle-Liste je Rang
        List<Enemy> source = diff switch
        {
            DungeonDifficulty.F => EnemyLibrary.F_Rank,
            DungeonDifficulty.E => EnemyLibrary.E_Rank,
            DungeonDifficulty.D => EnemyLibrary.D_Rank,
            DungeonDifficulty.C => EnemyLibrary.C_Rank,
            DungeonDifficulty.B => EnemyLibrary.B_Rank,
            DungeonDifficulty.A => EnemyLibrary.A_Rank,
            DungeonDifficulty.S => EnemyLibrary.S_Rank,
            _ => EnemyLibrary.F_Rank
        };

        // Gegner zufällig ziehen (als Kopien, damit HP je Run frisch ist)
        var run = new List<Enemy>();
        for (int i = 0; i < count; i++)
        {
            var template = source[Rng.Next(source.Count)];
            run.Add(new Enemy(template.Name, template.HP, template.MinDamage, template.MaxDamage, template.GoldReward));
        }

        // Boss hinzufügen (ein passender Boss pro Rang)
        Enemy boss = diff switch
        {
            DungeonDifficulty.F => Enemy.CreateGoblinChief(),
            DungeonDifficulty.E => Enemy.CreateMiniGolem(),
            DungeonDifficulty.D => Enemy.CreateOrcChief(),
            DungeonDifficulty.C => Enemy.CreateLizardChief(),
            DungeonDifficulty.B => Enemy.CreateMinotaurBoss(),
            DungeonDifficulty.A => Enemy.CreateSnowElfKing(),
            DungeonDifficulty.S => Enemy.CreateAntKing(),
            _ => Enemy.CreateGoblinChief()
        };
        run.Add(boss);

        return run;
    }

    // Schritt 1: nur Vorschau anzeigen
    public static void PreviewRun(Player p, DungeonDifficulty diff)
    {
        var enemies = CreateRun(diff);

        Console.Clear();
        Console.WriteLine($"=== {diff}-Rang Dungeon (Vorschau) ===\n");
        Console.WriteLine($"Spieler: {p.Name}  HP: {p.HP}/{p.Stats.MaxHP()}  STR:{p.Stats.STR}  VIT:{p.Stats.VIT}  DEX:{p.Stats.DEX}\n");

        for (int i = 0; i < enemies.Count; i++)
        {
            var e = enemies[i];
            string tag = (i == enemies.Count - 1) ? " (BOSS)" : "";
            Console.WriteLine($"{i + 1}. {e.Name}{tag}  | HP:{e.HP}  DMG:{e.MinDamage}-{e.MaxDamage}  Gold:{e.GoldReward}");
        }

        Console.WriteLine("\n(Später: Kämpfe nacheinander – hier erstmal nur Vorschau)");
        Console.WriteLine("Enter → zurück …");
        Console.ReadLine();
    }

    public static void Run(Player p, DungeonDifficulty diff)
    {
        var enemies = CreateRun(diff);
        int totalGold = 0;

        Console.Clear();
        Console.WriteLine($"=== {diff}-Rang Dungeon: Start! ===\n");

        foreach (var enemy in enemies)
        {
            // frische Kopie (falls CreateRun Vorlagen nutzt)
            var e = new Enemy(enemy.Name, enemy.HP, enemy.MinDamage, enemy.MaxDamage, enemy.GoldReward);

            var (won, gold) = BattleSystem.RunFight(p, e, Rng);
            if (!won)
            {
                Console.WriteLine("\nDungeon fehlgeschlagen. Du kehrst zurück …");
                Console.WriteLine("Enter …"); Console.ReadLine();
                return;
            }
            totalGold += gold;
        }

        // Dungeon geschafft
        p.AddGold(totalGold);
        Console.WriteLine($"\n=== Dungeon geschafft! Insgesamt +{totalGold} Gold ===");
        Console.WriteLine($"Dein Gold: {p.Gold}");
        Console.WriteLine("Enter zurück ins Menü …");
        Console.ReadLine();
    }
}
