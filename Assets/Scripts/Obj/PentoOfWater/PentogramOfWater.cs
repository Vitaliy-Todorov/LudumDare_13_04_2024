using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentogramOfWater : MonoBehaviour
{
    [SerializeField] GameObject[] _transformPoints;
    [SerializeField] float TimeToDo;
    float TimeToCount;

    GameController _gameController;

    int n;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

        _transformPoints = new GameObject[gameObject.transform.childCount];

        TimeToCount = TimeToDo;

        for(int i = 0; i < _transformPoints.Length; i++)
        {
            _transformPoints[i] = gameObject.transform.GetChild(i).gameObject;
        }
        
    }

    public void StartSummonWater()
    {
        _transformPoints[0].SetActive(true);
        _transformPoints[0].GetComponent<PointOfWaterPentogram>()._isMe = true;
    }

    public void Next()
    {
        if(n < _transformPoints.Length - 1 && gameObject.transform.parent.GetComponent<SummonWater>()._isPentogramm == true)
        {
            n++;
            _transformPoints[n].SetActive(true);
            _transformPoints[n].GetComponent<PointOfWaterPentogram>()._isMe = true;
        }
        else
        {
            _gameController.PlayerController._waterHad = true;
            Reset();
        }
    }

    void Reset()
    {
        for (int i = 0; i < _transformPoints.Length; i++)
        {
            _transformPoints[i].SetActive(false);
        }
        gameObject.transform.parent.GetComponent<SummonWater>()._isPentogramm = false;
        n = 0;
        TimeToCount = TimeToDo;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeToCount > 0 && gameObject.transform.parent.GetComponent<SummonWater>()._isPentogramm == true)
        {
            TimeToCount -= Time.deltaTime;
        }
        else
        {
            //анимку в случае проигрыша
            Reset();
        }
    }
}
