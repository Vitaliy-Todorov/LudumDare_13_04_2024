using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentogrammMiniGame : MonoBehaviour
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

        for (int i = 0; i < _transformPoints.Length; i++)
        {
            _transformPoints[i] = gameObject.transform.GetChild(i).gameObject;
        }

    }

    public void StartSummonWater()
    {
        _transformPoints[0].SetActive(true);
        _transformPoints[0].GetComponent<PointEvent>()._isMe = true;
    }

    public void Next()
    {
        if (n < _transformPoints.Length - 1 && gameObject.transform.parent.GetComponent<PentOfSummon>()._isSummoning == true)
        {
            n++;
            _transformPoints[n].SetActive(true);
            _transformPoints[n].GetComponent<PointEvent>()._isMe = true;
        }
        else
        {
            gameObject.transform.parent.GetComponent<PentOfSummon>().ResetP();
            Reset();
        }
    }

    void Reset()
    {
        for (int i = 0;i < _transformPoints.Length; i++)
        {
            _transformPoints[i].SetActive(false);
        }
        gameObject.transform.parent.GetComponent<PentOfSummon>()._isSummoning = false;
        n = 0;
        TimeToCount = TimeToDo;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeToCount > 0 && gameObject.transform.parent.GetComponent<PentOfSummon>()._isSummoning == true)
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
