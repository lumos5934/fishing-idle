using LumosLib;
using LumosLib.RPG;
using UnityEngine;

public class Player : IUnit
{
    public CurrencyHandler Currency { get; }
    public StatHandler Stats { get; }
    public StateHandler States { get; }
    public VitalHandler Vitals { get; }


    public Player()
    {
        Currency = new();
        Stats = new();
        Vitals = new();
        States = new();
        
        var statHP = new Stat(100000);
        var statMP = new Stat(10);
        var def = new Stat(1);
        var atk = new Stat(2);
        var crit = new Stat(50);
        Stats.Register((int)StatType.HP, statHP);
        Stats.Register((int)StatType.MP, statMP);
        Stats.Register((int)StatType.Atk, atk);
        Stats.Register((int)StatType.Def, def);
        Stats.Register((int)StatType.Crit, crit);

        var vitalHP = new Vital(statHP);
        var vitalMP = new Vital(statMP);
        Vitals.Register((int)VitalType.HP, vitalHP);
        Vitals.Register((int)VitalType.MP, vitalMP);
        
        Vitals.Apply((int)StatType.HP, - 50000f);
    }

    
    public void OnApplyEffect(UnitEffectContext ctx)
    {
        Debug.Log(Vitals.Get((int)StatType.HP).Current);
    }
}
