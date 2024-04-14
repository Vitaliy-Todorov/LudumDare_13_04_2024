using System;
using Infrastructure;
using UnityEngine;

[Serializable]
public class Hearing : MoveToGoal
{
    [SerializeField] 
    private PlayerMovement _player;
    
    public override void Construct(DependencyInjection diContainer)
    {
        base.Construct(diContainer);
        _player = _diContainer.GetDependency<EntityFactory>().Player.Movement;
        _target = _player.transform;
    }
    
    public override bool Condition() => 
        _player.IsRunning && base.Condition();
}