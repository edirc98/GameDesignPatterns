using UnityEngine;

public interface IObserver
{
    //Subject will use this method to comunicate to the observers
    //sugested names: OnNotify, OnOccured, Invoke, etc
    public void OnNotify(); //Paramteres can be added to this Method depending on the data needed to be sended trought. 
    //public void OnNotify(int value);
    //public void OnNotify(float value);

}
