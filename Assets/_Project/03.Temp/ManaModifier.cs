using LumosLib.RPG;
using UnityEngine;

public class ManaModifier : IUnitEffectModifier
{
    public int Priority => 900;
    public void Modify(UnitEffectContext ctx)
    {
        for (int i = 0; i < ctx.Effects.Count; i++)
        {
            var effect = ctx.Effects[i]; 
            if (effect.VitalTypeID == (int)VitalType.MP)
            {
                effect.Value = Mathf.Max(0, effect.Value * 0.8f);
                ctx.Effects[i] = effect;
            }
        }
    }
}