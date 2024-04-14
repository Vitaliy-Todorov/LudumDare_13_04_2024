using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _runningSpeed;

    [SerializeField, Space]
    private AnimatorController _animatorController;

    public bool IsRunning { get; private set; }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 moveTo = new Vector2(x, y);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (_animatorController != null) 
                _animatorController.Move(moveTo);
            _rigidbody.velocity = moveTo * _runningSpeed;
            IsRunning = true;
        }
        else
        {
            if (_animatorController != null)
                _animatorController.Move(moveTo);
            _rigidbody.velocity = moveTo * _speed;
            IsRunning = false;
        }
    }
}