using Cysharp.Threading.Tasks;
using LumosLib;
using UnityEngine;

public class GameManager : MonoBehaviour, IPreInitializable
{
    private void Awake()
    {
        Services.Register(this);
    }

    
    public async UniTask<bool> InitAsync(PreInitContext ctx)
    {
        return true;
    }
}