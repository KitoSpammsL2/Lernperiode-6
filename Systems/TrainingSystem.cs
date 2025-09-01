using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo_Leveling.Systems
{
    public class TrainingSystem
    {
        public static int DoSession()
        {
            int durationMs = 30000;  // 30 Sekunden
            int steps = 30;          // 30 kleine Schritte → 1 pro Sekunde
            int stepTime = durationMs / steps;

            Console.Clear();
            Console.WriteLine("Training gestartet... 💪");
            Console.Write("["); // Start des Balkens

            for (int i = 0; i < steps; i++)
            {
                System.Threading.Thread.Sleep(stepTime); // warten
                Console.Write("#"); // Fortschritt
            }

            Console.WriteLine("]"); // Ende des Balkens
            Console.WriteLine("Training abgeschlossen!");

            return 1; // Gibt 1 TP zurück
        }
    }
}
