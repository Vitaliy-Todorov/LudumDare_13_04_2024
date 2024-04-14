using Infrastructure;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    public abstract void Activate();

    public abstract void Close();

    public abstract void Construct(DependencyInjection diContainer);
}