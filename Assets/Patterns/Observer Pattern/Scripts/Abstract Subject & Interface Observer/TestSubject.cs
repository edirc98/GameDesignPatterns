using UnityEngine;

public class TestSubject : Subject
{

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
