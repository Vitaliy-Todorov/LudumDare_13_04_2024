using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentOfSummon : MonoBehaviour
{
    GameController _gameController;
    [SerializeField] GameObject _pentogramToCreate;

    float _randBtwSummon;

    [SerializeField] float SummonTime;
    float _summonTimeNow;

    public bool _playerStay, _isSummoning, _summone;

    void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        TimeSet();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _playerStay = true;
        if (_isSummoning && _gameController.PlayerController._waterHad)
        {
            _gameController.UseButton.SetActive(true);
        }
        else
        {
            _gameController.UseButton.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerStay = false;
        _gameController.UseButton.SetActive(false);
    }

    public void ResetP()
    {
        _isSummoning = false;
        TimeSet();
    }

    void TimeSet()
    {
        _summonTimeNow = SummonTime;
        _randBtwSummon = Random.Range(15, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if(_isSummoning && _gameController.PlayerController._waterHad && _playerStay)
        {
            if (Input.GetButtonDown("Use"))
            {
                _pentogramToCreate.GetComponent<PentogrammMiniGame>().StartSummonWater();
                _gameController.PlayerController._waterHad = false;
            }
        }

        if(_randBtwSummon > 0 && !_isSummoning)
        {
            _randBtwSummon -= Time.deltaTime;
        }
        else
        {
            if (!_isSummoning)
            {
                _isSummoning = true;
                TimeSet();
            }
        }

        if (_isSummoning && _summonTimeNow > 0)
        {
            _summonTimeNow -= Time.deltaTime;
        }
        else
        {
            _summone = true;
        }

        if (_summone)
        {
            //телепорт и ресет после задания с ResetP 
            _summone = false;
        }
    }
}
