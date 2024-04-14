using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private AIController _aiController;

    public void Construct(DependencyInjection diContainer)
    {
        _aiController.Construct(diContainer);
    }
}
