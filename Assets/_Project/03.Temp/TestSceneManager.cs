using System.Collections.Generic;
using System.Reflection;
using LumosLib.RPG;
using UnityEditor;
using UnityEngine;


public class TestSceneManager : MonoBehaviour
{
    private Player _player;
    private Fish _fish;
    private NormalAttack _normalAttack;
    private HealBuff _healBuff;
    [SerializeField] private BuffManager _buffManager;
    
    private void Start()
    {
        _player = new();
        _fish = new();
        
        /*EffectSystem.RegisterModifier(new DefenseEffectModifier());
        EffectSystem.RegisterModifier(new ManaEffectModifier());
        EffectSystem.RegisterModifier(new CriticalEffectModifier());*/

        int hpFlag = 0;
        hpFlag |= (int)EffectAttribute.Negative;
        hpFlag |= (int)EffectAttribute.Physical;
        hpFlag |= (int)EffectAttribute.Melee;
        
        int mpFlag = 0;
        mpFlag |= (int)EffectAttribute.Negative;
        
        //임시 세팅 추후 외부 데이터 주입
        _normalAttack = new(
            "일반 공격",
            new List<UnitEffect>()
            {
                new UnitEffect()
                {
                    VitalTypeID = (int)VitalType.HP,
                    AttributeFlags = hpFlag,
                    IsNegative = true,
                },
                new UnitEffect()
                {
                    VitalTypeID = (int)VitalType.MP,
                    AttributeFlags = mpFlag,
                    IsNegative = true,
                }
            },
            new List<UnitEffectCost>()
            {
                new UnitEffectCost()
                {
                    VitalTypeID = (int)VitalType.MP,
                    Value = 1f
                },
                new UnitEffectCost()
                {
                    VitalTypeID = (int)VitalType.HP,
                    Value = 2f
                }
            });


        _healBuff = new()
        {
            ID = 0,
            Name = "Heal",
            Duration = 10,
            Interval = 0.5f,
            Effects = new List<UnitEffect>()
            {
                new UnitEffect()
                {
                    AttributeFlags = (int)EffectAttribute.Heal,
                    VitalTypeID = (int)VitalType.HP,
                    Value = 10f
                }
            }
        };
    }


    [ContextMenu("테스트 데미지 실행")]
    private void Attack()
    {
        var assembly = Assembly.GetAssembly(typeof(Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
        
        _normalAttack.Attack(_player, _fish);
    }
    
    [ContextMenu("테스트 힐 실행")]
    private void Heal()
    {
        var assembly = Assembly.GetAssembly(typeof(Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
        
        _buffManager.Add(_player, _healBuff);
    }
}
