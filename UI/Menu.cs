using System;
using Solo_Leveling.Domain;   // für Player
using Solo_Leveling.Systems;
namespace Solo_Leveling.UI
{
    public static class Menu
    {
        public static void ShowMain(Player p)   // <-- Player rein
        {
            while (true)
            {
                Console.Clear();
                DrawHeader("⚔️  SOLO RPG  ⚔️");

                WriteLineColor(" [1] Dungeon betreten", ConsoleColor.Red);
                WriteLineColor(" [2] Trainieren", ConsoleColor.Green);
                WriteLineColor(" [3] Inventar", ConsoleColor.White);
                WriteLineColor(" [4] Shop", ConsoleColor.Magenta);
                WriteLineColor(" [5] Status", ConsoleColor.Blue);
                WriteLineColor(" [6] Speichern / Laden", ConsoleColor.Yellow);
                WriteLineColor(" [7] Beenden", ConsoleColor.Gray);

                Line();
                Console.Write("Wähle eine Option (1-7): ");
                var input = Console.ReadLine()?.Trim();

                switch (input)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.WriteLine("Dungeon-Rang wählen: F / E / D / C / B / A / S");
                            Console.Write("Eingabe: ");
                            string? inputRank = Console.ReadLine()?.Trim().ToUpper();

                            Solo_Leveling.Common.DungeonDifficulty diff = inputRank switch
                            {
                                "F" => Solo_Leveling.Common.DungeonDifficulty.F,
                                "E" => Solo_Leveling.Common.DungeonDifficulty.E,
                                "D" => Solo_Leveling.Common.DungeonDifficulty.D,
                                "C" => Solo_Leveling.Common.DungeonDifficulty.C,
                                "B" => Solo_Leveling.Common.DungeonDifficulty.B,
                                "A" => Solo_Leveling.Common.DungeonDifficulty.A,
                                "S" => Solo_Leveling.Common.DungeonDifficulty.S,
                                _ => Solo_Leveling.Common.DungeonDifficulty.F
                            };

                            Solo_Leveling.Systems.DungeonSystem.Run(p, diff);
                            break;
                        }

                    case "2":
                        int gained = TrainingSystem.DoSession();
                        p.GainTP(gained);
                        Info($"+{gained} Trainingspunkt erhalten!", ConsoleColor.Green);
                        Pause();
                        break;

                    case "3":
                        Info("Inventar (Platzhalter).", ConsoleColor.White);
                        Pause();
                        break;

                    case "4":
                        Info("Shop (Platzhalter).", ConsoleColor.Magenta);
                        Pause();
                        break;

                    case "5":
                        UiHelpers.ShowStatusMenu(p);   // <-- jetzt korrekt
                        break;

                    case "6":
                        Info("Speichern/Laden (Platzhalter).", ConsoleColor.Yellow);
                        Pause();
                        break;

                    case "7":
                        Info("Bis bald! 👋", ConsoleColor.Cyan);
                        return;

                    default:
                        Info("Ungültige Eingabe. Bitte 1–7.", ConsoleColor.Red);
                        Pause();
                        break;
                }
            }
        }

        // ---------- Untermenü: Dungeon-Rang ----------
        private static void HandleDungeonMenu()
        {
            Console.Clear();
            DrawHeader("Dungeon betreten");

            Console.WriteLine("Rang wählen: [F] [E] [D] [C] [A] [S]");
            Console.Write("Eingabe: ");
            var choice = Console.ReadLine()?.Trim().ToUpper();

            if (choice is "F" or "E" or "D" or "C" or "A" or "S")
                Info($"Du hast Rang {choice}-Dungeon gewählt. (Platzhalter-Run)", ConsoleColor.Red);
            else
                Info("Ungültiger Rang. Bitte F/E/D/C/A/S.", ConsoleColor.Red);
        }

        // ---------- kleine UI-Helfer ----------
        private static void DrawHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Line();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Center(title);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Line();
            Console.ResetColor();
        }

        private static void Line() => Console.WriteLine(new string('=', 36));

        private static void Center(string text)
        {
            int width = 36;
            int pad = Math.Max(0, (width - text.Length) / 2);
            Console.WriteLine(new string(' ', pad) + text);
        }

        private static void WriteLineColor(string text, ConsoleColor color)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = old;
        }

        private static void Info(string msg, ConsoleColor color)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = old;
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Weiter mit Enter …");
            Console.ReadLine();
        }
    }
}
