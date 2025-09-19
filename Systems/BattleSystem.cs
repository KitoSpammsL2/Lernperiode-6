using Solo_Leveling.Domain;
using Solo_Leveling.Domain.Enemies;

namespace Solo_Leveling.Systems;

public static class BattleSystem
{
    public static (bool won, int goldEarned) RunFight(Player p, Enemy e, Random rng)
    {
        Console.Clear();
        Console.WriteLine($"=== Kampf gegen {e.Name} ===");

        int round = 1;
        while (p.HP > 0 && e.HP > 0)
        {
            Console.WriteLine($"\n--- Runde {round} ---");
            Console.WriteLine($"Spieler: {p.HP}/{p.Stats.MaxHP()}  |  Gegner: {e.HP}");

            // Spielerzug (nur Angriff)
            int playerDmg = CalcPlayerDamage(p, rng, out bool crit);
            e.HP = Math.Max(0, e.HP - playerDmg);
            Console.WriteLine(crit ? $">> Kritischer Treffer! Du machst {playerDmg} Schaden."
                                   : $">> Du triffst für {playerDmg} Schaden.");

            if (e.HP <= 0) break;

            // Gegnerzug (Ausweichchance)
            if (rng.NextDouble() < p.Stats.DEX * 0.01)  // 1% je DEX
            {
                Console.WriteLine(">> Du weichst aus! Kein Schaden erhalten.");
            }
            else
            {
                int enemyDmg = rng.Next(e.MinDamage, e.MaxDamage + 1);
                p.TakeDamage(enemyDmg);
                Console.WriteLine($">> {e.Name} trifft dich für {enemyDmg} Schaden.");
            }

            round++;
            Console.WriteLine("Enter für nächste Runde …");
            Console.ReadLine();
        }

        bool won = e.HP <= 0;
        int gold = won ? e.GoldReward : 0;
        if (won) Console.WriteLine($"\n*** {e.Name} besiegt! (+{gold} Gold) ***");
        else Console.WriteLine($"\n*** Du wurdest besiegt … ***");
        return (won, gold);
    }

    // Basis: STR + kleiner Random; Crit über DEX
    private static int CalcPlayerDamage(Player p, Random rng, out bool crit)
    {
        int baseRoll = rng.Next(1, 4);               // „Waffenwürfel“ (später echte Waffe)
        int raw = p.Stats.STR + baseRoll;            // STR skaliert den Schaden
        double critChance = 0.05 + p.Stats.DEX * 0.01;
        crit = rng.NextDouble() < critChance;
        if (crit) raw = (int)Math.Round(raw * 1.5);
        return Math.Max(1, raw);
    }
}
