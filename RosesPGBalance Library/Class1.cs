using System;

namespace RosesPGBalance_Library;

public class onEven_Handler
{
    public struct slot_number
    {
        public int Memory_Slot_onmemory;
    }
    public delegate void onSlotUpdate(int Player_Stadistic_Memory_Slot);
    public static event onSlotUpdate onNewSlot;
   public static void TriggerUpdate(int Player_Stadistic_Memory_)
    {
        if (Player_Stadistic_Memory_ <= 0)
        {
            Console.WriteLine("Error on Memory Slot use, Limit to (min 1, max 8)");
            return;
        }
        if (Player_Stadistic_Memory_ >= 8)
        {
            Console.WriteLine("Error on Memory Slot use, Limit to (min 1, max 8)");
            return;
        }
        onNewSlot?.Invoke(Player_Stadistic_Memory_);
        slot_number MemorySlot = new slot_number();

        MemorySlot.Memory_Slot_onmemory = Player_Stadistic_Memory_;
    }

}

public class RosesPGBalance_Library
{
    //! Data call on "onSlotUpdate"

    //! Status Conditional 

    //! Default Value:
    public static float Default_float = 0f;
    public static int default_int { get; set; } = 0;
    public static float default_Multiplicator { get; set; } = 1.5f;

    public static bool default_bool = true;

    //!Variables

    //!Stadistics
    public static float Object_Health { get; set; } = 100f;
    public static float Object_Player_Damage { get; set; } = Default_float;

    public static int Object_Defence { get; set; } = default_int;
    public static float Object_Damage_Reduction { get; set; } = 0f;

    public static bool object_alive_status { get; set; } = default_bool;

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
        public bool Alive_status; 
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
    public static void Storage(onEven_Handler.slot_number Memory_Slot)
    {
        //Memory Slot
        int Memory_Slot_number = Memory_Slot.Memory_Slot_onmemory;

        //! Definiticiones
        Stadistic_Storage NewClass_Stadistics = new Stadistic_Storage();
        NewClass_Stadistics.Storage_Component = new Data_Storage[8];
        NewClass_Stadistics.Storage_Component[Memory_Slot_number].Health = Object_Health;
        NewClass_Stadistics.Storage_Component[Memory_Slot_number].Player_Damage = Object_Player_Damage;
        NewClass_Stadistics.Storage_Component[Memory_Slot_number].Crit_Rate = object_Crit_Rate;
        NewClass_Stadistics.Storage_Component[Memory_Slot_number].Crit_Damage = object_crit_damage;
        NewClass_Stadistics.Storage_Component[Memory_Slot_number].Damage_Reduction = Object_Damage_Reduction;
        NewClass_Stadistics.Storage_Component[Memory_Slot_number].Defence = Object_Defence;


    }

    public static void Storage_for_enemy(onEven_Handler.slot_number Memory_Slot)
    {
        //Memory Slot
        int Memory_Slot_number = Memory_Slot.Memory_Slot_onmemory;

        Enemy_Storage Enemy_Data_Class = new Enemy_Storage();
        Enemy_Data_Class.E_Data_Storage = new Enemy_Data[8];
    }

    public static void Storage_Attack_Information (onEven_Handler.slot_number Memory_Slot)
    {
        //Memory Slot
        int Memory_Slot_number = Memory_Slot.Memory_Slot_onmemory;
        Skill_or_Attack_Storage_Information New_Attack_Data = new Skill_or_Attack_Storage_Information();
        New_Attack_Data.Storage_Component_ForSkills = new attack_information[8];
        New_Attack_Data.Storage_Component_ForSkills[Memory_Slot_number].attacks = Attack_Cast_Number;
        New_Attack_Data.Storage_Component_ForSkills[Memory_Slot_number].ElementalAttackId = elemental_Id_Damage._Fire_Attack;
    }
    


}

public class Calculation_Node
{
    public struct calculation_Results
    {
        public float Crit_Ratio;
        public float DPS; 
    }

    public struct Calculation_Storage_Results
    {
        public calculation_Results[] Storage_Component; 
    }
    static float crit_Ratio(float crit_Rate, float Attack_Number)
    {
        return crit_Rate * Attack_Number;
    }
    static float DPS(float Damage, float Attack_Number )
    {
        return Damage * Attack_Number ;
    }
    static float DPS_Reduced_by_Reduction(float DPS,float damage_reduction)
    {
        return DPS * damage_reduction;
    }

    public static void Storage_Data(RosesPGBalance_Library.Stadistic_Storage storage,RosesPGBalance_Library.Skill_or_Attack_Storage_Information Skill_Storage,RosesPGBalance_Library.Enemy_Storage Enemy_Library, onEven_Handler.slot_number Memory_Slot)
    {
        Calculation_Storage_Results Calculation_Storage_result = new Calculation_Storage_Results();
        Calculation_Storage_result.Storage_Component = new calculation_Results[8];
        //Data extraction
        int Memory_Slot_number = Memory_Slot.Memory_Slot_onmemory;
        var Player_data = storage.Storage_Component[Memory_Slot_number];
        var Skill_Slot1 = Skill_Storage.Storage_Component_ForSkills[Memory_Slot_number];
        var Enemy_Data = Enemy_Library.E_Data_Storage[Memory_Slot_number];
        //Slot 1
        float Crit_Rate = Player_data.Crit_Rate;
        float Damage = Player_data.Player_Damage;
        //Skill Storage

        float attack_number = Skill_Slot1.attacks;

        
        Calculation_Storage_result.Storage_Component[Memory_Slot_number].Crit_Ratio = crit_Ratio(Crit_Rate, attack_number);
        Calculation_Storage_result.Storage_Component[Memory_Slot_number].DPS = DPS(Damage,attack_number);

    }
}





