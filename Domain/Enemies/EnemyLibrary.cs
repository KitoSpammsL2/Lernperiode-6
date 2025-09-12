namespace Solo_Leveling.Domain.Enemies;

public static class EnemyLibrary
{
    
    public static List<Enemy> F_Rank = new List<Enemy>
    {
        Enemy.CreateGoblin(),
        Enemy.CreateWolf(),
        Enemy.CreateGoblin()
    };

    public static List<Enemy> E_Rank = new List<Enemy>
    {
        Enemy.CreateStoneGolem(),
        Enemy.CreateGoblinAssassin(),
        Enemy.CreateStoneGolem()
    };

    public static List<Enemy> D_Rank = new List<Enemy>
    {
    Enemy.CreateOrc(),
    Enemy.CreateCaveWolf(),
    Enemy.CreateOrc()
    };

    public static List<Enemy> C_Rank = new List<Enemy>
    {
    Enemy.CreateLizardman(),
    Enemy.CreateKobold(),
    Enemy.CreateLizardman()
    };

    public static List<Enemy> B_Rank = new List<Enemy>
    {
    Enemy.CreateOgre(),
    Enemy.CreateMinotaur(),
    Enemy.CreateOgre()
    };

    public static List<Enemy> A_Rank = new List<Enemy>
    {
    Enemy.CreateSnowElf(),
    Enemy.CreateIceGolem(),
    Enemy.CreateSnowElf()
    };

    public static List<Enemy> S_Rank = new List<Enemy>
    {
    Enemy.CreateAntSoldier(),
    Enemy.CreateAntWarrior(),
    Enemy.CreateAntSoldier()
    };

}
