using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName ="New Event", menuName = "Game Event")]
public class Event : ScriptableObject
{
    private List<EventListener> listeners = new List<EventListener>();

    public void Register(EventListener listener)
    {
        listeners.Add(listener);
    }
    public void Unregister(EventListener listener) 
    { 
        listeners.Remove(listener);
    }
    public void Ocurred(GameObject go)
    {
        foreach (EventListener listener in listeners)
        {
            listener.OnEventOccurs(go);
        }
    }
}
