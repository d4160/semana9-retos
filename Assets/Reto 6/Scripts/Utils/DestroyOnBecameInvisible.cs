using UnityEngine;

public class DestroyOnBecameInvisible : MonoBehaviour
{
    public GameObject toDestroyObject;

    void OnBecameInvisible()
    {
        Destroy(toDestroyObject);
    }
}
