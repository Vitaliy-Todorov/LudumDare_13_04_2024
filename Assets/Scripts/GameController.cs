using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class GameController : MonoBehaviour
{
    public PlayerController PlayerController;
    public GameObject UseButton, ObjToGive, ObjPoopToGive, Tree;
    public int WaterWeight, BerryCount, PoopCount;
    public TextMeshProUGUI BerryText, PoopText;

    private void Start()
    {

    }

    private void Update()
    {
        BerryText.text = "-" + BerryCount;
        PoopText.text = "-" + PoopCount;
    }

    public void Win()
    {
        PlayerController.gameObject.GetComponent<Animator>().SetBool("Win", true);
        PlayerController.enabled = false;
    }

    public void Loose()
    {
        PlayerController.gameObject.GetComponent<Animator>().SetBool("Lose", true);
        PlayerController.enabled = false;
    }

    public void CoruptedAll()
    {
        ObjToGive.GetComponent<ObjToGive>().corupted = true;
        ObjToGive.GetComponent<ObjToGive>().coruptedCount++;
        ObjPoopToGive.GetComponent<ObjPoopToGive>().corupted = true;
        ObjPoopToGive.GetComponent<ObjPoopToGive>().coruptedCount++;

        Tree.GetComponent<TreeNeeds>().corupted = true;
        Tree.GetComponent<TreeNeeds>().countCorupted++;
    }
}
