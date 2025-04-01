using UnityEngine;

public class DeactivatePoolObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PoolObject"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
