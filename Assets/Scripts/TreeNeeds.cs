using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreeNeeds : MonoBehaviour
{
    bool _playerStay, _doIt;

    public bool corupted;
    public int countCorupted;

    GameController _gameController;

    public Sprite[] TreeSprite, TreeSpriteCorupted, SpriteDead;
    [SerializeField] int[] PoopNeed, BerryNeed;
    int _counter;

    [SerializeField] GameObject PanelToSee;
    [SerializeField] TextMeshProUGUI PoopText, BerryText;


    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _playerStay = true;
        if (PoopNeed[_counter] != 0 || BerryNeed[_counter] != 0)
        {
            PanelToSee.SetActive(true);
            if(_gameController.PoopCount > 0 || _gameController.BerryCount > 0)
            {
                _gameController.UseButton.SetActive(true);
            }
            else
                _gameController.UseButton.SetActive(false);
        }
        else
        {
            PanelToSee.SetActive(false);
            _gameController.UseButton.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerStay = false;
        PanelToSee.SetActive(false);
        _gameController.UseButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerStay)
        {
            if(Input.GetButtonDown("Use"))
            {
                int m = 0;
                if (_gameController.PoopCount > 0)
                {
                    if (PoopNeed[_counter] - _gameController.PoopCount >= 0)
                    {
                        PoopNeed[_counter] -= _gameController.PoopCount;
                        _gameController.PoopCount = 0;
                    }
                    else
                    {
                        m = _gameController.PoopCount - PoopNeed[_counter];
                        _gameController.PoopCount = m;
                        PoopNeed[_counter] = 0;
                    }
                }

                if (_gameController.BerryCount > 0)
                {
                    if (BerryNeed[_counter] - _gameController.BerryCount >= 0)
                    {
                        BerryNeed[_counter] -= _gameController.BerryCount;
                        _gameController.BerryCount = 0;
                    }
                    else
                    {
                        m = _gameController.BerryCount - BerryNeed[_counter];
                        _gameController.BerryCount = m;
                        BerryNeed[_counter] = 0;
                    }
                }              
            }
        }

        if(countCorupted >= 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = TreeSpriteCorupted[_counter];
        }
        if(countCorupted > 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteDead[_counter];
            _gameController.Loose();
        }

        if (_doIt)
        {
            _gameController.Win();
        }

        if (BerryNeed[_counter] <= 0 && PoopNeed[_counter] <= 0)
        {
            NextCount();
        }

        PoopText.text = "- " + PoopNeed[_counter];
        BerryText.text = "- " + BerryNeed[_counter];
    }

    void NextCount()
    {
        if(_counter < PoopNeed.Length-1)
        {
            _counter++;
            gameObject.GetComponent<SpriteRenderer>().sprite = TreeSprite[_counter];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = TreeSprite[TreeSprite.Length - 1];
            PanelToSee.SetActive(false);
            _gameController.UseButton.SetActive(false);
            _doIt = true;
        }
    }
}
