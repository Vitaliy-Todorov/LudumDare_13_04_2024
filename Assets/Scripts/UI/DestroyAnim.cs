using UnityEngine;

public class DestroyAnim : MonoBehaviour
{
    public GameObject setTrue;

    public void DestroyAnimator()
    {
        setTrue.SetActive(true);
        Destroy(gameObject.GetComponent<Animator>());
    }
}
