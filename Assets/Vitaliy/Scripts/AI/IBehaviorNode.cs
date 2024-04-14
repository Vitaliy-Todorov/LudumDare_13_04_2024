using Infrastructure;

public interface IBehaviorNode
{
    public IBehaviorNode NextNod { get; }
    public void Construct(DependencyInjection diContainer);
    public bool Condition();
    public void Action();
}