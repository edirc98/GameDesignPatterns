using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private float rotationAmount = 15.0f;
    [SerializeField] private float movementAmount = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += transform.forward * movementAmount;
        }
        else if (Input.GetKeyDown(KeyCode.A)) 
        {
            transform.Rotate(new Vector3(0, -rotationAmount, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(new Vector3(0,rotationAmount,0));
        }
    }
}
