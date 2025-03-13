using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    [Header("Events")]
    public Event PickupCreated;
    [Header("Radar Icon")]
    public Image PickupIcon;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PickupCreated.Ocurred(gameObject);
    }
}
