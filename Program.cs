using Solo_Leveling.Domain;
using Solo_Leveling.UI;

namespace Solo_Leveling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var player = new Player("Rice");
            Menu.ShowMain(player);


        }
    }
}
