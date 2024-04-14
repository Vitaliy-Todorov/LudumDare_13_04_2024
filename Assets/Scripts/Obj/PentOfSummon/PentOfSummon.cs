using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PentOfSummon : MonoBehaviour
{
    GameController _gameController;
    [SerializeField] GameObject _pentogramToCreate;
    public FirstDay fstD;

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
        if(fstD.count > 0)
        {
            _summonTimeNow = fstD.TimeToPent;
            fstD.count--;
            if(fstD.count <= 0)
            {
                fstD.FirstDayLater();
            }
        }
        else
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
            _gameController.PlayerController.GetComponent<SpriteRenderer>().enabled = false;
            _gameController.PlayerController.enabled = false;
        }
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(5);

        _gameController.CoruptedAll();
        ResetP();
        _summone = false;
        _gameController.PlayerController.GetComponent<SpriteRenderer>().enabled = true;
        _gameController.PlayerController.enabled = true;
    }
}
