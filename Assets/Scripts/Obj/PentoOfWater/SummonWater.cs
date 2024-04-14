using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonWater : MonoBehaviour
{
    GameController _gameController;
    [SerializeField] GameObject _pentogramToCreate;
    bool _playerStay, _pentogram;
    public bool _isPentogramm;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _playerStay = true;
        if (!_gameController.PlayerController._waterHad && !_isPentogramm)
            _gameController.UseButton.SetActive(true);
        else
            _gameController.UseButton.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerStay = false;
        _gameController.UseButton.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerStay)
        {
            if (!_gameController.PlayerController._waterHad && !_isPentogramm)
            {
                if(Input.GetAxis("Use") != 0)
                {
                    _pentogram = true;
                    _isPentogramm = true;
                }
            }
        }

        if(_pentogram && _isPentogramm)
        {
            CreatePentogramm();
            _pentogram = false;
        }
    }

    void CreatePentogramm()
    {
        _pentogramToCreate.SetActive(true);
        _pentogramToCreate.GetComponent<PentogramOfWater>().StartSummonWater();
    }
}
