using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo_Leveling.Domain
{
    public class Stats
    {
        public int STR { get; private set; } = 1;  // Stärke = Schaden
        public int VIT { get; private set; } = 1;  // Vitalität = HP
        public int DEX { get; private set; } = 0;  // Geschick = Ausweichchance (oder Luck für Crit)

        public void AddSTR(int pts) => STR += pts;
        public void AddVIT(int pts) => VIT += pts;
        public void AddDEX(int pts) => DEX += pts;

        // Abgeleitet
        public int MaxHP() => 20 + VIT * 5;
        public int DamageBase() => 1 + STR;

        // Chance-Werte
        public double DodgeChance() => DEX * 0.01;    // 1% pro Punkt
        public double CritChance() => DEX * 0.01;    // falls du es für Crit nutzen willst

    }
}
