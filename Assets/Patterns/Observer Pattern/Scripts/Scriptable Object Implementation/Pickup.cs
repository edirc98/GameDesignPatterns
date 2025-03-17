using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    [Header("Events")]
    public Event PickupCreated;
    public Event PickupCollected; 
    [Header("Radar Icon")]
    public Image PickupIcon;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PickupCreated.Ocurred(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickupCollected.Ocurred(gameObject);
            gameObject.SetActive(false);
            Destroy(gameObject,2);
        }
    }
}
