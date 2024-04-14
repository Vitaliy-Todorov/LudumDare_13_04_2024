using System;
using Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : Window
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _exit;
    
    private WindowManager _windowManager;

    public override void Construct(DependencyInjection diContainer)
    {
        _windowManager = diContainer.GetDependency<WindowManager>();
    }

    void Start()
    {
        _restart.onClick.AddListener(Restart);
        _exit.onClick.AddListener(Exit);
    }

    public override void Activate()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public override void Close()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void Restart() => 
        SceneManager.LoadScene("Main");

    private void Exit() => 
        Application.Quit();
}