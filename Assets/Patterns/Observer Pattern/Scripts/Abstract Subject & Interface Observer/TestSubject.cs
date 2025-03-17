using UnityEngine;

public class TestSubject : Subject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            ThingHappened();
        }
    }

    private void ThingHappened()
    {
        Debug.Log("From " + name + " somethign happened");
        NotifyObservers();
    }
}
