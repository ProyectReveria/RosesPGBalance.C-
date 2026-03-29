using System;
using System.Diagnostics.Contracts;

namespace RosesPGBalance_Library;

class RPGRosesFramework 
{

    //!Variables
    public static float Contract_Health { get; set; } = 100f;
    public static float Contract_Enemy_Healt { get; set; } = 100f;

    //?Data definitions
    public struct NeedDAta
    {
        public float Enemy_Health;
        public float Player_Life;
        public bool Game_Active;
        public float Player_Damage;
        public float Enemy_Damage;
    }
    //?Data Operations 

    //?  Struct 

    //! DamageType Struct by List
    //*Main
    static void Main()
    {
        //! Definiticiones
        NeedDAta Enemy_Health_OnStorage = new NeedDAta();
        Enemy_Health_OnStorage.Player_Life = Contract_Health; 
        
        Console.WriteLine(Enemy_Health_OnStorage.Player_Life.ToString());



    }
}