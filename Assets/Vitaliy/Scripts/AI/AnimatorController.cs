using System;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField, Space]
    private Animator _animator;

    public void Move(Vector2 moveTo) 
    {
        if (moveTo.y > Mathf.Abs(moveTo.x))
            _animator.Play("Up");
        else if (Mathf.Abs(moveTo.y) > Mathf.Abs(moveTo.x))
            _animator.Play("Bottom");
        else if (moveTo.x > 0)
            _animator.Play("Right");
        else if (moveTo.x < 0)
            _animator.Play("Left");
        else
            _animator.Play("Stand");
    }
}