using System;

namespace RosesPGBalance_Library;

public class RosesPGBalance_Library
{
    //! Default Value:
    public static float Default_float = 0f;
    public static int default_int = 0; 
    //!Variables
    //!Stadistics
    public static float Object_Health { get; set; } = 100f;
    public static float Object_Player_Damage { get; set; } = Default_float; 
    public static float Object_Enemy_Healt { get; set; } = 100f;
        //Crit rate!
    public static float object_Crit_Rate { get; set; } = default_int;
    public static void CritOverload()

    {
        if (object_Crit_Rate > 100)
        {

            object_Crit_Rate = 100f;

        }
    }
    //!Attack
    public static int Attack_Cast_Number { get; set; } = default_int;


    //?Data definitions

    //?Memory Slots for Stadistics

    public struct attack_information
    {
        public int attack_id;
        public string attack_type;
        public int attacks; //! Be how much attacks on single skill or attack
    }
    
    //!Player data Storage and Enemy Data Storage
    public struct Data_Storage
    {
        public float Health;
        public float Player_Damage;
        public float Enemy_Healt; 
        public float Enemy_Player_Damage;
        public float Crit_Rate; 
    }
    //!Slots 
    public struct Stadistic_Storage
    {
        public Data_Storage[] Storage_Component;
    }

    public struct Skill_or_Attack_Storage_Information
    {
        public attack_information[] Storage_Component_ForSkills; 
    }
    //?Data Operations 


    //! DamageType Struct by List
    //*Main
    public static void Storage()
    {
        //! Definiticiones
        Stadistic_Storage NewClass_Stadistics = new Stadistic_Storage();
        NewClass_Stadistics.Storage_Component = new Data_Storage[8];
        NewClass_Stadistics.Storage_Component[1].Health = Object_Health;
        NewClass_Stadistics.Storage_Component[1].Player_Damage = Object_Player_Damage;

        NewClass_Stadistics.Storage_Component[1].Crit_Rate = object_Crit_Rate;
 
    }

    public static void Storage_Attack_Information ()
    {
        Skill_or_Attack_Storage_Information New_Attack_Data = new Skill_or_Attack_Storage_Information();
        New_Attack_Data.Storage_Component_ForSkills[1].attacks = Attack_Cast_Number;
    }
    


}

public class Calculation_Node
{
    static void crit_Ratio(float crit_Rate, float Attack_Number)
    {
        float Crit_Ratio = crit_Rate * Attack_Number;
    }

    public static void Storage_Data(RosesPGBalance_Library.Stadistic_Storage storage,RosesPGBalance_Library.Skill_or_Attack_Storage_Information Skill_Storage)
    {
        var Slot1 = storage.Storage_Component[1];
        var Skill_Slot1 = Skill_Storage.Storage_Component_ForSkills[1];
        float Crit_Rate = Slot1.Crit_Rate;
        float attack_number = Skill_Slot1.attacks;
        crit_Ratio(Crit_Rate, attack_number); 
    }
}


