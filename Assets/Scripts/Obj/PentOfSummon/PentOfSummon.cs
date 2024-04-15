using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using TMPro;

public class PentOfSummon : MonoBehaviour
{
    GameController _gameController;
    [SerializeField] GameObject _pentogramToCreate;
    public FirstDay fstD;

    float _randBtwSummon;

    [SerializeField] float SummonTime;
    float _summonTimeNow;

    public GameObject panel;
    public TextMeshProUGUI txt;

    public SpawnEnemies spawnEnemies;
    public Transform Pentogram, OutoGram;

    bool temp;


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
        panel.SetActive(false);
        temp = false;
        TimeSet();
    }

    void TimeSet()
    {
        if(fstD.count > 0)
        {
            _summonTimeNow = fstD.TimeToPent;
            if(fstD.count <= 0)
            {
                fstD.FirstDayLater();
            }
            fstD.count--;
        }
        else
            _summonTimeNow = SummonTime;
        _randBtwSummon = Random.Range(15, 25);
        _summone = false;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = (int)_summonTimeNow + "";
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
            
            _isSummoning = true;       
        }

        if (_isSummoning && _summonTimeNow > 0)
        {
            panel.SetActive(true);
            _summonTimeNow -= Time.deltaTime;
            
        }
        else if(_summonTimeNow <= 0)
        {
            panel.SetActive(false);
            _summone = true;
        }

        if (_summone && !temp)
        {
            _gameController.PlayerController.gameObject.transform.position = OutoGram.transform.position;
            spawnEnemies.RandomSpawn();    
            temp = true;
        }
    }

    public void AllBe()
    {
        _gameController.PlayerController.gameObject.transform.position = Pentogram.transform.position;
        _gameController.CoruptedAll();
        ResetP();
        _isSummoning = false;
        _summone = false;
    }
}
