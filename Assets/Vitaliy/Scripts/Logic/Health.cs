using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private int _maxValue;
    [SerializeField] 
    private int _value;
    [SerializeField] 
    private int _regeneration;
    [SerializeField] 
    private float _regenerationTime;

    private Coroutine _regenerationCoroutine;
    private Coroutine _periodicChanges;

    public int MaxValue => _maxValue;
    public int Value => _value;

    public Coroutine RegenerationCoroutine => _regenerationCoroutine;

    public event Action<Health> HealthAdd;

    private void Awake() => 
        _value = _maxValue;

    public void TakeDamage(int damage)
    {
        AddHealth(-damage);
        /*if(_value <= _maxValue) 
            _regenerationCoroutine ??= StartCoroutine(Regeneration(_regeneration, _regenerationTime));*/

        if (_value <= 0)
        {
            // StopCoroutine(_regenerationCoroutine);
            Destroy(gameObject);
        }
    }

    public void StartPeriodicChanges(int takenHealth, float takeTime)
    {
        /*if(_regenerationCoroutine != null)
        {
            StopCoroutine(_regenerationCoroutine);
            _regenerationCoroutine = null;
        }*/
        AddHealth(takenHealth);
        _periodicChanges = StartCoroutine(Regeneration(takenHealth, takeTime));
    }

    public void StopPeriodicChanges()
    {
        if(_regenerationCoroutine != null || _periodicChanges == null)
            return;
        StopCoroutine(_periodicChanges);
        // _regenerationCoroutine = StartCoroutine(Regeneration(_regeneration, _regenerationTime));
    }

    private IEnumerator Regeneration(int takenHealth, float takeTime)
    {
        while (_value < _maxValue)
        {
            yield return new WaitForSeconds(takeTime);
            AddHealth(takenHealth);
        }

        // _regenerationCoroutine = null;
    }

    private void AddHealth(int value)
    {
        _value += value;
        HealthAdd?.Invoke(this);
    }
}
