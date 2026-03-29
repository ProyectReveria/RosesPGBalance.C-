using System;

namespace RosesPGBalance_Library;

class RPGRosesFramework 
{
    //! Default Value:
    public static float Default_float = 0f;
    public static int default_int = 0; 
    //!Variables
    public static float Object_Health { get; set; } = 100f;
    public static float Object_Player_Damage { get; set; } = Default_float; 
    public static float Object_Enemy_Healt { get; set; } = 100f;

    //?Data definitions

    //?Memory Slots for Stadistics
    public struct Data_Storage
    {
        public float Health;
        public float Player_Damage;
    }
    public struct Stadistic_Storage
    {
        public Data_Storage[] Storage_Component;
    }
    //?Data Operations 

    //?  Struct 

    //! DamageType Struct by List
    //*Main
    static void Main()
    {
        //! Definiticiones
        Stadistic_Storage NewClass_Stadistics = new Stadistic_Storage();
        NewClass_Stadistics.Storage_Component = new Data_Storage[8];
        NewClass_Stadistics.Storage_Component[1].Health = Object_Health;
            ;
        NewClass_Stadistics.Storage_Component[1].Player_Damage = Object_Player_Damage;

    }
}
