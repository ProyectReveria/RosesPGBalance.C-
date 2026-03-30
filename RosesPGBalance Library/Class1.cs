using System;

namespace RosesPGBalance_Library;

public class RosesPGBalance_Library
{
    //! Default Value:
    public static float Default_float = 0f;
    public static int default_int { get; set; } = 0;
    public static float default_Multiplicator { get; set; } = 1.5f;

    //!Variables

    //!Stadistics
    public static float Object_Health { get; set; } = 100f;
    public static float Object_Player_Damage { get; set; } = Default_float;

    public static int Object_Defence { get; set; } = default_int;
    public static float Object_Damage_Reduction { get; set; } = 0f;

    //Enemy
    public static float Object_Enemy_Healt { get; set; } = 100f;
    public static float object_Enemy_Damage { get; set; } = Default_float; 
        //Crit rate!
    public static float object_Crit_Rate { get; set; } = default_int;
    public static float object_crit_damage {  get; set; } = default_Multiplicator;
    
    //!ElementalType and ElementalID

    enum elemental_Id_Damage
    {
        _void_Attack_Data = 000000,
        _Fire_Attack = 000001,
    }
    public static dynamic _default_ID = elemental_Id_Damage._void_Attack_Data;
    public static dynamic attack_Damage_Type { get; set; } = _default_ID; 
    public static float Fire_Attack_Multiplier { get; set; } = default_Multiplicator; 

    //! Crit Overload Verification
    public static void CritOverload()

    {
        if (object_Crit_Rate > 100)
        {

            object_Crit_Rate = 100f;

        }
        if (object_Crit_Rate < 0)
        {
            object_Crit_Rate = 0; 
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
        public dynamic ElementalAttackId;
        public int ElementalAttackMultiplier; 
    }
    
    //!Player data Storage and Enemy Data Storage

    public struct Enemy_Data
    {
        public float Enemy_Healt;
        public float Enemy_Damage;
    }
    public struct Data_Storage
    {
        public float Health;
        public float Player_Damage;
        public float Crit_Rate;
        public float Crit_Damage;
        public int Defence;
        public float Damage_Reduction;
    }
    //!Slots 
    public struct Stadistic_Storage
    {
        public Data_Storage[] Storage_Component;
    }

    public struct Enemy_Storage
    {
        public Enemy_Data[] E_Data_Storage;
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
        NewClass_Stadistics.Storage_Component[1].Crit_Damage = object_crit_damage;
        NewClass_Stadistics.Storage_Component[1].Damage_Reduction = Object_Damage_Reduction;
        NewClass_Stadistics.Storage_Component[1].Defence = Object_Defence;


    }

    public static void Storage_for_enemy()
    {
        Enemy_Storage Enemy_Data_Class = new Enemy_Storage();
        Enemy_Data_Class.E_Data_Storage = new Enemy_Data[8];
    }

    public static void Storage_Attack_Information ()
    {
        Skill_or_Attack_Storage_Information New_Attack_Data = new Skill_or_Attack_Storage_Information();
        New_Attack_Data.Storage_Component_ForSkills = new attack_information[8];
        New_Attack_Data.Storage_Component_ForSkills[1].attacks = Attack_Cast_Number;
        New_Attack_Data.Storage_Component_ForSkills[1].ElementalAttackId = elemental_Id_Damage._Fire_Attack;
    }
    


}

public class Calculation_Node
{
    public struct calculation_Results
    {
        public float Crit_Ratio; 
    }

    public struct Calculation_Storage_Results
    {
        public calculation_Results[] Storage_Component; 
    }
    static void crit_Ratio(float crit_Rate, float Attack_Number)
    {
        float Crit_Ratio = crit_Rate * Attack_Number;
    }
    static void DPS(float Damage, float Attack_Number, float Damage_Reduction)
    {
        float DPS = Damage * Attack_Number / Damage_Reduction;
    }

    public static void Storage_Data(RosesPGBalance_Library.Stadistic_Storage storage,RosesPGBalance_Library.Skill_or_Attack_Storage_Information Skill_Storage,RosesPGBalance_Library.Enemy_Storage Enemy_Library)
    {
        var Slot1 = storage.Storage_Component[1];
        var Skill_Slot1 = Skill_Storage.Storage_Component_ForSkills[1];
        float Crit_Rate = Slot1.Crit_Rate;
        float attack_number = Skill_Slot1.attacks;
        crit_Ratio(Crit_Rate, attack_number); 
    }
}


