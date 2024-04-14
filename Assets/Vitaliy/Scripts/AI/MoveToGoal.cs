using System;
using Infrastructure;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class MoveToGoal : IBehaviorNode, ISetAnimator
{
    [SerializeField] 
    protected Rigidbody2D _rigidbody;
    [SerializeField] 
    private float _agraRadius;
    [SerializeField] 
    private float _maxAgraRadius;

    [SerializeReference, Space] 
    protected IBehaviorNode _nextNod;
    [SerializeField] 
    private float _speed = 5;

    [SerializeReference, Space] 
    protected Transform _target;

    private bool _agra;
    private AnimatorController _animatorController;
    protected DependencyInjection _diContainer;

    public IBehaviorNode NextNod => _nextNod;

    public virtual void Construct(DependencyInjection diContainer)
    {
        _diContainer = diContainer;
        _target = _diContainer.GetDependency<EntityFactory>().Player.transform;
    }

    public void SetAnimator(AnimatorController animatorController) => 
        _animatorController = animatorController;

    public virtual bool Condition()
    {
        if (_target == null)
            return false;
        
        Vector2 distanceToTarget = _target.transform.position - _rigidbody.transform.position;
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
        Vector3 vectorToTarget = _target.position - _rigidbody.transform.position;
        
        _rigidbody.velocity = - vectorToTarget.normalized * _speed;
        /*_agent.SetDestination(_target.transform.position);
        Vector2 direction = (_agent.pathEndPosition - _agent.transform.position).normalized;
        _animatorController.Move(direction);*/
    }
}
