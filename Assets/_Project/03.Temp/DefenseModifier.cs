using LumosLib.RPG;
using UnityEngine;

public class DefenseModifier : IUnitEffectModifier
{
    public int Priority => 0;
    public void Modify(UnitEffectContext ctx)
    {
        var defense = ctx.Target.Stats.Get((int)StatType.Def).Value;

        for (int i = 0; i < ctx.Effects.Count; i++)
        {
            var effect = ctx.Effects[i]; 
            if (effect.VitalTypeID == (int)VitalType.HP)
            {
                effect.Value = Mathf.Max(0, effect.Value - defense);
                ctx.Effects[i] = effect;
            }
        }
    }
}