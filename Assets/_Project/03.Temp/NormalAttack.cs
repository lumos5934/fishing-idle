using System.Collections.Generic;
using LumosLib.RPG;

public class NormalAttack : BaseAttackAction
{
    public NormalAttack(string name, List<UnitEffect> effects, List<UnitEffectCost> costs) : base(name, effects, costs)
    {
        
    }

    protected override void OnAttack(IUnit source, IUnit target)
    {
        float dmg = 0;
        
        var atk = source.Stats.Get((int)StatType.Atk);
        if (atk != null)
        {
            dmg = atk.Value;
        }

        var effects = new List<UnitEffect>(Effects);
        for (int i = 0; i < effects.Count; i++)
        {
            var effect = effects[i];
            effect.Value = dmg;
            effects[i] = effect;
        }
        
        var ctx = UnitEffectSystem.GetContext(source, target, effects);
        UnitEffectSystem.Apply(ctx);
    }
}