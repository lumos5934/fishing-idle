using System;

public enum CurrencyType
{
    Gold,
}


public enum StatType
{
    HP,
    MP,
    Atk,
    Def,
    Crit,
}


public enum VitalType
{
    HP,
    MP,
}


[Flags]
public enum EffectAttribute
{
    None = 0,
    Positive    = 1 << 0, 
    Negative = 1 << 1,
    Neutral    = 1 << 2,

    // [8~15번 비트] 공격/효과 타입
    Physical   = 1 << 8,
    Magic      = 1 << 9,
    True       = 1 << 10,
    
    // [16~23번 비트] 상세 분류
    Melee      = 1 << 16,
    Ranged     = 1 << 17,
    Fire       = 1 << 18,
    Ice        = 1 << 19,
    Heal       = 1 << 20,
}


[Flags]
public enum HitType
{
    None = 0,
    Crit = 1 << 1,
    Heal = 1 << 2,
}