using Solo_Leveling.Domain;
using Solo_Leveling.UI;

namespace Solo_Leveling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var player = new Player("Rice");


            Console.WriteLine("=== F-Rang Gegner ===");
            foreach (var enemy in Solo_Leveling.Domain.Enemies.EnemyLibrary.F_Rank)
            {
                enemy.ShowInfo();
            }

            Console.WriteLine("\n=== E-Rang Gegner ===");
            foreach (var enemy in Solo_Leveling.Domain.Enemies.EnemyLibrary.E_Rank)
            {
                enemy.ShowInfo();
            }

            Console.WriteLine("=== D-Rang Gegner ===");
            foreach (var enemy in Solo_Leveling.Domain.Enemies.EnemyLibrary.D_Rank)
                enemy.ShowInfo();

            Console.WriteLine("=== C-Rang Gegner ===");
            foreach (var enemy in Solo_Leveling.Domain.Enemies.EnemyLibrary.C_Rank)
                enemy.ShowInfo();

            Console.WriteLine("=== B-Rang Gegner ===");
            foreach (var enemy in Solo_Leveling.Domain.Enemies.EnemyLibrary.B_Rank)
                enemy.ShowInfo();

            Console.WriteLine("\n=== A-Rang Gegner ===");
            foreach (var enemy in Solo_Leveling.Domain.Enemies.EnemyLibrary.A_Rank)
                enemy.ShowInfo();

            Console.WriteLine("\n=== S-Rang Gegner ===");
            foreach (var enemy in Solo_Leveling.Domain.Enemies.EnemyLibrary.S_Rank)
                enemy.ShowInfo();

            Console.ReadLine();


            Console.WriteLine("\nEnter für Menü …");
            Console.ReadLine();


            Menu.ShowMain(player);

           
        }
    }
}
