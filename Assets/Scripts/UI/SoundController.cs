using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public static int volume = 1;
    bool On = true;
    public Sprite Off, Ons;

    public void OffSound()
    {
        if (On)
        {
            gameObject.GetComponent<Image>().sprite = Off;
            volume = 0;
            On = false;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = Ons;
            volume = 1;
            On = true;
        }
    }
}
