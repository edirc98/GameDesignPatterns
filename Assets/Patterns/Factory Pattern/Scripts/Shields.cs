using UnityEngine;

public interface IShield
{
    void Defend();

    static IShield CreateDefault()
    {
        return new Shield();
    }
}

public class Shield : IShield
{
    public void Defend()
    {
        Debug.Log("Shield Defend");
    }
}
