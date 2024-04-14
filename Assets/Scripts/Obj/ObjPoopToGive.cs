using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjPoopToGive : MonoBehaviour
{
    GameController _gameController;

    [SerializeField] public bool corupted;
    [SerializeField] public int coruptedCount;

    [SerializeField] GameObject Pumpk;

    [SerializeField] GameObject coruptedTask;
    [SerializeField] TextMeshProUGUI coruptedText;

    [SerializeField] int HowManyCountNeed;

    int _count;

    bool _playerStay;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _playerStay = true;
        if (!corupted)
        {
            if (_gameController.BerryCount > 0)
                _gameController.UseButton.SetActive(true);
            else
                _gameController.UseButton.SetActive(false);
        }
        else
        {
            if(_gameController.BerryCount > coruptedCount)
                _gameController.UseButton.SetActive(true);
            else
                _gameController.UseButton.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerStay = false;
        _gameController.UseButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!corupted)
        {
            coruptedTask.SetActive(false);
            Pumpk.SetActive(true);
            if (_gameController.BerryCount >= HowManyCountNeed)
            {
                if (_playerStay && Input.GetButtonDown("Use"))
                {
                    _gameController.PoopCount++;
                    _gameController.BerryCount -= HowManyCountNeed;
                }
            }
        }
        else
        {
            Pumpk.SetActive(false);
            coruptedTask.SetActive(true);
            coruptedText.text = "x" + coruptedCount;

            if (coruptedCount > 0)
            {
                if(_playerStay && Input.GetButtonDown("Use") && _gameController.BerryCount > coruptedCount)
                {
                    _gameController.BerryCount -= coruptedCount;
                    coruptedCount = 0;
                }
            }
            else
            {
                corupted = false;
            }
        }
    }
}
