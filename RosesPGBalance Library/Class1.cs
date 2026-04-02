using System;
using System.IO;
using System.Text.Json;

namespace RosesPGBalance_Library;

public static class Memory
{
    public static Stadistic_Storage Stadistics = new Stadistic_Storage()
    {
        Storage_Component = new Data_Storage[8]
    };

    public static Enemy_Storage Enemies = new Enemy_Storage()
    {
        E_Data_Storage = new Enemy_Data[8]
    };

    public static Skill_or_Attack_Storage_Information Skills = new Skill_or_Attack_Storage_Information()
    {
        Storage_Component_ForSkills = new attack_information[8]
    };

    public static void Init()
    {
        for (int i = 0; i < 8; i++)
        {
            Stadistics.Storage_Component[i] = new Data_Storage();
            Enemies.E_Data_Storage[i] = new Enemy_Data();
            Skills.Storage_Component_ForSkills[i] = new attack_information();
        }
    }
}
public class onEven_Handler
{
    public struct slot_number
    {
        public int Memory_Slot_onmemory;
    }

    public static slot_number CreateSlot(int slot)
    {
        if (slot < 0 || slot >= 8)
        {
            Console.WriteLine("Invalid slot (0-7)");
            return new slot_number();
        }

        return new slot_number { Memory_Slot_onmemory = slot };
    }
}

public class Data_Storage
{
    public float Health;
    public float Player_Damage;
    public float Crit_Rate;
    public float Crit_Damage;
    public int Defence;
    public float Damage_Reduction;
    public bool Alive_status;
}

public class Enemy_Data
{
    public float Enemy_Healt;
    public float Enemy_Damage;
}

public class attack_information
{
    public int attack_id;
    public string attack_type;
    public int attacks;
    public int ElementalAttackId;
    public float ElementalAttackMultiplier;
}

public class Stadistic_Storage
{
    public Data_Storage[] Storage_Component;
}

public class Enemy_Storage
{
    public Enemy_Data[] E_Data_Storage;
}

public class Skill_or_Attack_Storage_Information
{
    public attack_information[] Storage_Component_ForSkills;
}

public static class RosesPGBalance
{
    public static float Object_Health = 100f;
    public static float Object_Player_Damage = 10f;
    public static float object_Crit_Rate = 10f;
    public static float object_crit_damage = 1.5f;
    public static int Attack_Cast_Number = 1;

    public static void Store(onEven_Handler.slot_number slot)
    {
        var data = Memory.Stadistics.Storage_Component[slot.Memory_Slot_onmemory];

        data.Health = Object_Health;
        data.Player_Damage = Object_Player_Damage;
        data.Crit_Rate = object_Crit_Rate;
        data.Crit_Damage = object_crit_damage;
    }

    public static void StoreAttack(onEven_Handler.slot_number slot)
    {
        var atk = Memory.Skills.Storage_Component_ForSkills[slot.Memory_Slot_onmemory];

        atk.attacks = Attack_Cast_Number;
        atk.ElementalAttackId = 1;
        atk.ElementalAttackMultiplier = 1.5f;
    }
}

public static class Calculation_Node
{
    static float Crit(float rate, float hits) => rate * hits;
    static float DPS(float dmg, float hits) => dmg * hits;

    public static void Compute(onEven_Handler.slot_number slot)
    {
        var Stadistics = Memory.Stadistics.Storage_Component[slot.Memory_Slot_onmemory];
        var SkillStorage = Memory.Skills.Storage_Component_ForSkills[slot.Memory_Slot_onmemory];

        float crit = Crit(Stadistics.Crit_Rate, SkillStorage.attacks);
        float dps = DPS(Stadistics.Player_Damage, SkillStorage.attacks);

        Console.WriteLine($"[RESULT] Crit: {crit} | DPS: {dps}");
    }
}
public static class SaveSystem
{
    public static void Save()
    {
        var json = JsonSerializer.Serialize(Memory.Stadistics);
        File.WriteAllText("save.json", json);
    }

    public static void Load()
    {
        if (!File.Exists("save.json")) return;

        var json = File.ReadAllText("save.json");
        Memory.Stadistics = JsonSerializer.Deserialize<Stadistic_Storage>(json);
    }
}

public class Program
{
    public static void Main()
    {
        Memory.Init();

        var slot = onEven_Handler.CreateSlot(0);

        RosesPGBalance.Store(slot);
        RosesPGBalance.StoreAttack(slot);

        Calculation_Node.Compute(slot);

        SaveSystem.Save();
    }
}
