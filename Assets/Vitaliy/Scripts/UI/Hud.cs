using Infrastructure;
using UnityEngine;

public class Hud : MonoBehaviour
{
    [SerializeField] 
    private HPBar _hpBar;
    
    public void Construct(DependencyInjection diContainer)
    {
        Player player = diContainer.GetDependency<EntityFactory>().Player;
        _hpBar.Construct(player.Health);
    }
}
