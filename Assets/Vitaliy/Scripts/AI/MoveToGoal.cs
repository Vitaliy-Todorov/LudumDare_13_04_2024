using System;
using Infrastructure;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class MoveToGoal : IBehaviorNode, ISetAnimator
{
    [SerializeField] 
    protected NavMeshAgent _agent;
    [SerializeField] 
    private float _agraRadius;
    [SerializeField] 
    private float _maxAgraRadius;

    [SerializeReference, Space] 
    protected IBehaviorNode _nextNod;

    protected Transform _target;

    private bool _agra;
    private AnimatorController _animatorController;
    protected DependencyInjection _diContainer;

    public IBehaviorNode NextNod => _nextNod;

    public virtual void Construct(DependencyInjection diContainer)
    {
        _diContainer = diContainer;
        
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    public void SetAnimator(AnimatorController animatorController) => 
        _animatorController = animatorController;

    public virtual bool Condition()
    {
        if (_target == null)
            return false;
        
        Vector2 distanceToTarget = _target.transform.position - _agent.transform.position;
        if (!_agra && distanceToTarget.magnitude > _agraRadius)
            return false;

        _agra = true;

        if (distanceToTarget.magnitude > _maxAgraRadius)
        {
            _agra = false;
            return false;
        }

        return true;
    }

    public virtual void Action()
    {
        _agent.SetDestination(_target.transform.position);
        Vector2 direction = (_agent.pathEndPosition - _agent.transform.position).normalized;
        _animatorController.Move(direction);
    }
}
