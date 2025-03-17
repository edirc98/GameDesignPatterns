using UnityEngine;
using System.Collections.Generic;

public class Subject : MonoBehaviour
{
    //A collection of observers for this subject
    #region OBSERVERS COLLECTION
    private List<IObserver> _observers = new List<IObserver>();
    #endregion

    #region OBSERVER METHODS
    //Adds an observer to the collection
    public void AddObserver(IObserver observer)
    {
        Debug.Log("Added Observer");
        _observers.Add(observer);
    }
    //Removes an observer from the collection
    public void RemoveObserver(IObserver observer)
    {
        Debug.Log("Removed Observer");
        _observers.Remove(observer);
    }
    //Notify each observer that an event has occurred
    protected void NotifyObservers()
    {
        foreach(IObserver observer in _observers)
        {
            observer.OnNotify();
        }
    }
    #endregion
}
