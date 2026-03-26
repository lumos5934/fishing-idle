using LumosLib.RPG;
using UnityEngine;

public class Fish : IUnit
{
    public StatHandler Stats { get; }
    public StateHandler States { get; }
    public VitalHandler Vitals { get;}
    
    
    public Fish()
    {
        Stats = new();
        States = new();
        Vitals = new();
        
        var statHP = new Stat(100000);
        var statMP = new Stat(100000);
        var def = new Stat(1);
        Stats.Register((int)StatType.HP, statHP);
        Stats.Register((int)StatType.MP, statMP);
        Stats.Register((int)StatType.Def, def);

        var vitalHP = new Vital(statHP);
        var vitalMP = new Vital(statMP);
        Vitals.Register((int)VitalType.HP, vitalHP);
        Vitals.Register((int)VitalType.MP, vitalMP);
    }
    
    
    public void OnApplyEffect(UnitEffectContext ctx)
    {
        var source = ctx.Source;
        
        Debug.Log($"---------- {source.GetType()} ----------");
        var hitFlag = ctx.HitFlags;

        if ((hitFlag & (int)HitType.Crit) != 0)
        {
            Debug.Log("치명타 성공!");
        }
        
        foreach (var effect in ctx.Effects)
        {
            if ((effect.AttributeFlags & (int)EffectAttribute.Negative) != 0)
            {
                Debug.Log($"공격 성공!");
                Debug.Log($"대상 : {ctx.Target} - {(VitalType)effect.VitalTypeID}");
                Debug.Log($"데미지 : {effect.Value}");
            }
        }
            
        Debug.Log($"HP : {source.Vitals.Get((int)VitalType.HP).Current}");
        Debug.Log($"MP : {source.Vitals.Get((int)VitalType.MP).Current}");
        
        
        Debug.Log("---------- Fish ----------");

        foreach (var effect in ctx.Effects)
        {
            if ((effect.AttributeFlags & (int)EffectAttribute.Negative) != 0)
            {
                var vital = Vitals.Get(effect.VitalTypeID);
                if (vital != null)
                {
                    Debug.Log($"{(VitalType)effect.VitalTypeID} - 피격!");
                    Debug.Log($"남은 {(VitalType)effect.VitalTypeID}: {vital.Current}");
                }
            }
        }
    }
}
