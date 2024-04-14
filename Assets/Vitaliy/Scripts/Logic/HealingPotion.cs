using UnityEngine;
using UnityEngine.Serialization;

public class HealingPotion : MonoBehaviour
{
    [SerializeField]
    private GameObject _activationButtonMessage;
    [SerializeField]
    private int _addHP;

    private bool _onTrigger;
    private Health _triggerHealth;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        _onTrigger = true;
        _activationButtonMessage.SetActive(true);
        _triggerHealth = collider.GetComponent<Health>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _onTrigger && _triggerHealth != null)
        {
            _triggerHealth.TakeDamage(-_addHP);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _onTrigger = false;
        _activationButtonMessage.SetActive(false);
        _triggerHealth = null;
    }
}