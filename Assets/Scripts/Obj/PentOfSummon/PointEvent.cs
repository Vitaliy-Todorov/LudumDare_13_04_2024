using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvent : MonoBehaviour
{
    PentogrammMiniGame _pento;
    public bool _isMe;

    private void Start()
    {
        _pento = gameObject.transform.parent.GetComponent<PentogrammMiniGame>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isMe)
        {
            _isMe = false;
            _pento.Next();
            print("yes");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
