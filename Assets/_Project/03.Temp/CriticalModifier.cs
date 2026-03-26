using LumosLib.RPG;
using UnityEngine;

public class CriticalModifier : IUnitEffectModifier
{
    public int Priority => 1;
    public void Modify(UnitEffectContext ctx)
    {
        //만약 ctx 플래그가 힐이나 블럭, 회피 등인지 먼저 검사하는 모디파이어를 통해
        //더 앞선 우선순위에서 미리 거르게함

        bool isCrit = false;
        
        for (int i = 0; i < ctx.Effects.Count; i++)
        {
            var effect = ctx.Effects[i];
            if ((effect.AttributeFlags & (int)EffectAttribute.Negative) != 0 &&
                (effect.AttributeFlags & (int)EffectAttribute.Physical) != 0 &&
                (effect.AttributeFlags & (int)EffectAttribute.Melee) != 0 &&
                effect.VitalTypeID == (int)VitalType.HP)
            {
                var crit = ctx.Source.Stats.Get((int)StatType.Crit);
                if (crit == null)
                    continue;

                var critChance = Random.Range(0f, 100f);
                if (critChance > crit.Value)
                    continue;
                
                effect.Value *= 1.5f; // 임시 1.5배 데미지
                ctx.Effects[i] = effect;
                isCrit = true;
            }
        }

        if (isCrit)
        {
            ctx.HitFlags |= (int)HitType.Crit;
        }
    }
}