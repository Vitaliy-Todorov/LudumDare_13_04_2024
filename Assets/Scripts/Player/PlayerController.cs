using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int _speed;
    Rigidbody2D _rb;
    Animator anim;
    public bool _waterHad;
    [SerializeField] float WaterFadeSpeed;
    float _nowWaterFade;

    [SerializeField] GameObject Bucket, Timer;
    [SerializeField] TextMeshProUGUI text;

    void Start()
    {
        _nowWaterFade = WaterFadeSpeed;

        anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (int)_nowWaterFade + "";
        Animations();
        _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * _speed;
        if (_waterHad && _nowWaterFade > 0)
        {
            Bucket.SetActive(true);
            Timer.SetActive(true);
            _nowWaterFade -= Time.deltaTime;
            //анимка с ведром
        }
        else
        {
            Timer.SetActive(false);
            Bucket.SetActive(false);
            //анимка без ведра
            _waterHad = false;
            _nowWaterFade = WaterFadeSpeed;
        }
    }

    public void Animations()
    {
        //anim.SetBool("Walk", _walk);
    }
}
