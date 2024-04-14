using UnityEngine;

public class DestroyAnim : MonoBehaviour
{
    public void DestroyAnimator()
    {
        Destroy(gameObject.GetComponent<Animator>());
    }
}
