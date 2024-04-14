using System;
using Infrastructure;
using UnityEngine;

[Serializable]
public class Vision : MoveToGoal
{
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private float _distance = 3;
    
    private const string PLAYER_LAYER = "Player";
    private const string TRANSPARENT_LAYER = "Obstacle";

    private int _layerPlayer;
    private int _transparentLayers;
    private Vector3 TransformPosition => _rigidbody.transform.position;

    public override void Construct(DependencyInjection diContainer)
    {
        // _nextNod = new Hearing();
        base.Construct(diContainer);
        _layerPlayer = LayerMask.NameToLayer(PLAYER_LAYER);
        _transparentLayers = (1 << LayerMask.NameToLayer(PLAYER_LAYER)) | (1 << LayerMask.NameToLayer(TRANSPARENT_LAYER));
    }

    public override bool Condition()
    {
        if(_target == null)
            return false;

        Vector2 direction = (_target.position - TransformPosition).normalized;
        RaycastHit2D hit = Physics2D.Raycast(_transform.position, direction, _distance, _transparentLayers);
        Debug.DrawRay(_transform.position, direction * _distance, Color.green);

        if (hit.collider != null && hit.transform.gameObject.layer == _layerPlayer)
            return base.Condition();
        
        return false;
    }

    public void OnTriggerEnter2D(Collider2D collider) => 
        _target = collider.transform;

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.transform == _target)
            _target = null;
    }
}