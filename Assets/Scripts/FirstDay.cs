using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class FirstDay : MonoBehaviour
{
    public int TimeToPent;
    [SerializeField] PlayerController _firstDay;
    public int count = 3;

    public GameObject Diologue;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void FirstDayLater()
    {
        Diologue.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
