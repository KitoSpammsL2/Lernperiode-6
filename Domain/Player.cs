using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solo_Leveling.Domain
{
    public class Player
    {
        public string Name { get; }
        public Stats Stats { get; } = new();

        public int HP { get; private set; }
        public int Gold { get; private set; } = 0;

        public int TP { get; private set; } = 0;

        public Player(string name)
        {
            Name = name;
            HP = Stats.MaxHP();
        }

        // Methoden
        public void Heal(int amount)
        {
            HP = Math.Min(Stats.MaxHP(), HP + amount);
        }

        public void TakeDamage(int dmg)
        {
            HP = Math.Max(0, HP - dmg);
        }

        public void AddGold(int amount) => Gold += amount;
        public bool SpendGold(int amount)
        {
            if (Gold < amount) return false;
            Gold -= amount;
            return true;
        }

        // wichtig wenn VIT steigt:
        public void RecalcHPIfNeeded()
        {
            if (HP > Stats.MaxHP()) HP = Stats.MaxHP();
        }

        public void GainTP(int amount) { TP += Math.Max(0, amount); }
        public bool SpendTP(int amount)
        {
            if (TP < amount) return false;
            TP -= amount;
            return true;
        }
    }
}
