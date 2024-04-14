using System;
using Infrastructure;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject _activationButtonMessage; 
    [SerializeField]
    private string _heading; 
    [SerializeField]
    private string _message;

    private bool _playerNear;
    
    private WindowManager _windowManager;

    public void Construct(WindowManager windowManager) => 
        _windowManager = windowManager;

    private void OnTriggerEnter2D(Collider2D col)
    {
        _playerNear = true;
        _activationButtonMessage.SetActive(true);
    }

    private void Update()
    {
        if(_playerNear && Input.GetKeyDown(KeyCode.E))
        {
            if(_windowManager.CurrenWindow is WindowMessage)
                _windowManager.CloseWindow();
            else
            {
                WindowMessage windowMessage = _windowManager.OpenWindow(typeof(WindowMessage)) as WindowMessage;
                windowMessage.SetMassage(_heading, _message);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _playerNear = false;
        _activationButtonMessage.SetActive(false);
        _windowManager.CloseWindow();
    }
}
