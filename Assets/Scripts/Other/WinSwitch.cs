using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSwitch : MonoBehaviour
{
    public void Enter()
    {
        SceneManager.LoadScene(1);
    }
}
