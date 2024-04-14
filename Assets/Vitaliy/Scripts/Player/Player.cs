using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Health _health;

    [field: SerializeField]
    public PlayerMovement Movement { get; set; }

    public Health Health => _health;
}
