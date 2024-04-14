using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] 
    private Image _fill;
    [SerializeField]
    private Health _health;

    public void Construct(Health health)
    {
        _health = health;
        _health.HealthAdd += HealthAdd;
    }

    private void HealthAdd(Health health)
    {
         _fill.fillAmount = (float)_health.Value / _health.MaxValue;
    }
}