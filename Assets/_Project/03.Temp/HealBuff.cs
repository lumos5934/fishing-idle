using LumosLib.RPG;

public class HealBuff : BaseBuff
{
    protected override void OnApply()
    {
    }

    protected override void OnRemove()
    {
    }

    protected override void OnTick()
    {
        var ctx = UnitEffectSystem.GetContext(Target, Target, Effects);
        UnitEffectSystem.Apply(ctx);
    }

    protected override void OnStack()
    {
        Timer = Duration;
    }
}