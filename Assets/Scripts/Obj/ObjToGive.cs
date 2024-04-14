using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjToGive : MonoBehaviour
{
    GameController _gameController;

    [SerializeField] public bool corupted;
    [SerializeField] public int coruptedCount;

    //[SerializeField] float TimeToWater;
    //float _nowTime;
    [SerializeField] float HowManyWaterNeed, FadeSpeed;
    [SerializeField] int HowManyCountNeed;
    float _waterNow;
    int _count;
    GameObject _panelToWater;

    [SerializeField] GameObject Task, Bucket, CoruptedTask;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] Sprite HasPlods, CoruptedSprite, NormalSprite;
    [SerializeField] GameObject[] obj;

    Slider _waterIndex;

    bool _playerStay;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        //_give = true;
        _panelToWater = gameObject.transform.GetChild(0).transform.GetChild(0).gameObject;

        //_nowTime = TimeToWater;
        _waterIndex = _panelToWater.GetComponent<Slider>();
        _waterIndex.maxValue = HowManyWaterNeed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _playerStay = true;
        if (!corupted)
        {
            if (_gameController.PlayerController._waterHad && _count < HowManyCountNeed)
                _gameController.UseButton.SetActive(true);
            else
                _gameController.UseButton.SetActive(false);
        }
        else
        {
            if (_gameController.PlayerController._waterHad)
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

    void StartWater()
    {
        Bucket.SetActive(false);
        _panelToWater.SetActive(true);
    }

    private void Reset()
    {
        Bucket.SetActive(true);
        _panelToWater.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _waterIndex.value = _waterNow;

        if (!corupted)
        {
            CoruptedTask.SetActive(false);

            if (_count >= HowManyCountNeed)
            {
                Bucket.SetActive(false);
                for (int i = 0; i < obj.Length; i++)
                {
                    obj[i].GetComponent<SpriteRenderer>().sprite = HasPlods;
                }

                Task.SetActive(true);

                if (_playerStay && Input.GetButtonDown("Use"))
                {
                    _gameController.BerryCount++;
                    _count = 0;
                }
            }
            else
            {
                Task.SetActive(false);

                for (int i = 0; i < obj.Length; i++)
                {
                    obj[i].GetComponent<SpriteRenderer>().sprite = NormalSprite;
                }

                if (_playerStay && _gameController.PlayerController._waterHad)
                {
                    //print("mw");
                    if (Input.GetButtonDown("Use") && _gameController.PlayerController._waterHad)
                    {
                        _waterNow += _gameController.WaterWeight;
                        _gameController.PlayerController._waterHad = false;
                    }
                }
            }

            if (_waterNow > 0)
            {
                StartWater();
                _waterNow -= Time.deltaTime * FadeSpeed;
            }
            else
            {
                Reset();
            }

            if (_waterNow >= HowManyWaterNeed)
            {
                _count++;
                _waterNow = 0;
            }
        }
        else
        {
            CoruptedTask.SetActive(true) ;
            Bucket.SetActive(false);
            text.text = "x"+coruptedCount;

            for(int i = 0; i < obj.Length;  i++)
            {
                obj[i].GetComponent<SpriteRenderer>().sprite = CoruptedSprite;
            }

            if (coruptedCount > 0)
            {
                if (Input.GetButtonDown("Use") && _gameController.PlayerController._waterHad)
                {
                    coruptedCount--;
                    _gameController.PlayerController._waterHad = false;
                }
            }
            else
            {
                corupted = false;
            }
        }
    }
}
