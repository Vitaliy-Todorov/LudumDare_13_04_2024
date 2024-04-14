using Infrastructure;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeReference]
    private IBehaviorNode _rootNode = new Vision();
    [SerializeReference]
    private IBehaviorNode _currentNode;

    [SerializeField, Space] 
    private AnimatorController _animatorController;

    private DependencyInjection _diContainer;

    public void Construct(DependencyInjection diContainer)
    {
        _diContainer = diContainer;
        
        _currentNode = _rootNode;
        while (_currentNode != null)
        {
            _currentNode.Construct(_diContainer);
            
            if(_currentNode is ISetAnimator setAnimator)
                setAnimator.SetAnimator(_animatorController);
            
            _currentNode = _currentNode.NextNod;
        }

        _currentNode = _rootNode;
    }

    private void Update()
    {
        _currentNode = _rootNode;
        while (_currentNode != null)
        {
            if(_currentNode.Condition()) 
                _currentNode.Action();
            _currentNode = _currentNode.NextNod;
        }

        _currentNode = _rootNode;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _currentNode = _rootNode;
        while (_currentNode != null)
        {
            if(_currentNode is Vision vision)
                vision.OnTriggerEnter2D(col);
            _currentNode = _currentNode.NextNod;
        }

        _currentNode = _rootNode;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _currentNode = _rootNode;
        while (_currentNode != null)
        {
            if(_currentNode is Vision vision)
                vision.OnTriggerExit2D(other);
            _currentNode = _currentNode.NextNod;
        }

        _currentNode = _rootNode;
    }
}