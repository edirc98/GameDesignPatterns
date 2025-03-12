using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float forceAmount = 5;
    [SerializeField] private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _rb.AddForce(new Vector3(0,0,1) * forceAmount);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _rb.AddForce(new Vector3(0, 0, -1) * forceAmount);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _rb.AddForce(new Vector3(-1, 0, 0) * forceAmount);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _rb.AddForce(new Vector3(1, 0, 0) * forceAmount);
        }
    }
}
