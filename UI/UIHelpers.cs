using System;
using Solo_Leveling.Domain;

namespace Solo_Leveling.UI
{
    public static class UiHelpers   // <— statisch + konsistenter Name
    {
        public static void ShowStatusMenu(Player p)
        {
            Console.Clear();
            Console.WriteLine("==== STATUS ====");
            Console.WriteLine($"Name: {p.Name}");
            Console.WriteLine($"HP: {p.HP}/{p.Stats.MaxHP()}");
            Console.WriteLine($"STR: {p.Stats.STR}");
            Console.WriteLine($"VIT: {p.Stats.VIT}");
            Console.WriteLine($"DEX: {p.Stats.DEX}");
            Console.WriteLine($"TP: {p.TP}");
            Console.WriteLine($"Gold: {p.Gold}");
            Console.WriteLine("================\n");

            Console.WriteLine("[1] STR erhöhen");
            Console.WriteLine("[2] VIT erhöhen");
            Console.WriteLine("[3] DEX erhöhen");
            Console.WriteLine("[4] Zurück");
            Console.Write("Auswahl: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    p.Stats.AddSTR(1);
                    Console.WriteLine("STR +1");
                    break;
                case "2":
                    p.Stats.AddVIT(1);
                    p.RecalcHPIfNeeded();
                    Console.WriteLine("VIT +1");
                    break;
                case "3":
                    p.Stats.AddDEX(1);
                    Console.WriteLine("DEX +1");
                    break;
                default:
                    return; // zurück ins Hauptmenü
            }

            Pause();
        }

        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Weiter mit Enter …");
            Console.ReadLine();
        }
    }
}
